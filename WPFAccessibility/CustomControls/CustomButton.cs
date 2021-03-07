using System.Windows.Automation.Peers;
using System.Windows.Controls;
using WPFAccessibility.UIAutomation;

namespace WPFAccessibility.CustomControls
{
    public class CustomButton : Button
    {
        protected override AutomationPeer OnCreateAutomationPeer()
        {
            return new CustomButtonAutomationPeer(this);
        }
    }
}
