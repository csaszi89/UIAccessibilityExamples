using Interop.UIAutomationClient;
using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Threading;

namespace WinformsAccessibility.Test.UITests
{
    [TestFixture]
    public class WinformsAccessibilityTest
    {
        private Process _application;
        private IUIAutomation _automation;
        private IUIAutomationElement _mainWindow;

        [SetUp]
        public void SetUp()
        {
            var psi = new ProcessStartInfo(@".\..\..\..\..\WinformsAccessibility\bin\Debug\WinformsAccessibility.exe")
            {
                WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory
            };

            // Start application
            _application = Process.Start(psi);

            // Wait for application main window
            while (_application.MainWindowHandle == IntPtr.Zero)
            {
                Thread.Sleep(100);
            }

            // Create UIAutomation (UIA3) entry point
            _automation = new CUIAutomation8();
            _mainWindow = _automation.ElementFromHandle(_application.MainWindowHandle);
        }

        [TearDown]
        public void TearDown()
        {
            _application.CloseMainWindow();
            _application.WaitForExit();
        }

        [Test]
        [Description("ValuePattern is available, current value and read-only state is available, button text can be changed.")]
        public void TestThatCustomButtonControlHasValuePattern()
        {
            // Find the custom button
            var customButton = _mainWindow.FindFirst(TreeScope.TreeScope_Children, _automation.CreatePropertyCondition(UIA_PropertyIds.UIA_AutomationIdPropertyId, "customButtonId"));
            Assert.IsNotNull(customButton);

            // Get Value pattern
            var valuePattern = customButton.GetCurrentPattern(UIA_PatternIds.UIA_ValuePatternId) as IUIAutomationValuePattern;
            Assert.IsNotNull(valuePattern);

            // Verify text and read-only state
            Assert.AreEqual("CustomButtonText", valuePattern.CurrentValue);
            Assert.IsTrue(valuePattern.CurrentIsReadOnly == 0);

            // Set button text and verify
            valuePattern.SetValue("ModifiedText");
            Assert.AreEqual("ModifiedText", valuePattern.CurrentValue);
        }

        [Test]
        [Description("Custom button control has information about text alignment.")]
        public void TestThatCustomButtonControlTextAlignStateCanBeRead()
        {
            // Find the custom button
            var customButton = _mainWindow.FindFirst(TreeScope.TreeScope_Children, _automation.CreatePropertyCondition(UIA_PropertyIds.UIA_AutomationIdPropertyId, "customButtonId"));
            Assert.IsNotNull(customButton);

            // Verify TextAlign
            Assert.IsTrue(customButton.CurrentHelpText.Contains("TextAlign=MiddleCenter"));
        }
    }
}
