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
        [Test]
        [Description("Tests that custom button control is accessible by a UI test. ValuePattern is available and TextAlign property can be read.")]
        public void CustomButtonTest()
        {
            var psi = new ProcessStartInfo(@".\..\..\..\..\WinformsAccessibility\bin\Debug\WinformsAccessibility.exe")
            {
                WorkingDirectory = AppDomain.CurrentDomain.BaseDirectory
            };

            // Start application
            var application = Process.Start(psi);

            // Wait for application main window
            while (application.MainWindowHandle == IntPtr.Zero)
            {
                Thread.Sleep(100);
            }

            // Create UIAutomation (UIA3) entry point
            var automation = new CUIAutomation8();
            var mainWindow = automation.ElementFromHandle(application.MainWindowHandle);

            // Find the custom button
            var customButton = mainWindow.FindFirst(TreeScope.TreeScope_Children, automation.CreatePropertyCondition(UIA_PropertyIds.UIA_AutomationIdPropertyId, "customButtonId"));
            Assert.IsNotNull(customButton);

            // Verify TextAlign
            Assert.IsTrue(customButton.CurrentHelpText.Contains("TextAlign=MiddleCenter"));

            // Get Value pattern
            var valuePattern = customButton.GetCurrentPattern(UIA_PatternIds.UIA_ValuePatternId) as IUIAutomationValuePattern;
            Assert.IsNotNull(valuePattern);

            // Verify text and read-only state
            Assert.AreEqual("CustomButtonText", valuePattern.CurrentValue);
            Assert.IsTrue(valuePattern.CurrentIsReadOnly == 0);

            // Set button text and verify
            valuePattern.SetValue("ModifiedText");
            Assert.AreEqual("ModifiedText", valuePattern.CurrentValue);

            // Exit
            application.CloseMainWindow();
            application.WaitForExit();
        }
    }
}
