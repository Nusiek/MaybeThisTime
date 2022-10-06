using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MaybeThisTime;
using MaybeThisTime.Common;

namespace SoftAssertions
{
    public class SoftAssertion : Base
    {
        private readonly List<SingleAssert> _verifications = new List<SingleAssert>();

        public string Message(string expected, string actual)
        {
            return $"Expected value: '{expected}'. Actual value: '{actual}'";
        }

        public void Add(string message, string expected, string actual)
        {
            _verifications.Add(new SingleAssert(message, expected, actual));
        }

        public void Add(string message, bool expected, bool actual)
        {
            Add(message, expected.ToString(), actual.ToString());
        }

        public void Add(string message, int expected, int actual)
        {
            Add(message, expected.ToString(), actual.ToString());
        }

        public void AddTrue(string message, bool actual)
        {
            _verifications.Add(new SingleAssert(message, true.ToString(), actual.ToString()));
        }

        public void AssertAll()
        {
            var failed = _verifications.Where(v => v.Failed).ToList();
            failed.Should().BeEmpty();
        }

        private class SingleAssert
        {
            private readonly string _message;
            private readonly string _expected;
            private readonly string _actual;

            public bool Failed { get; }

            public SingleAssert(string message, string expected, string actual)
            {
                _message = message;
                _expected = expected;
                _actual = actual;

                Failed = _expected != _actual;
                if (Failed)
                {
                    ScreenShot.CaptureScreenshot(driver);
                    string screenshotFileName = ScreenShot.ScreenshotFileName();
                    _message += $"Screenshot captured at: {screenshotFileName}";
                }
            }

            public override string ToString()
            {
                return $"'{_message}' assert was expected to be '{_expected}' but was '{_actual}'";
            }
        }
    }
}

