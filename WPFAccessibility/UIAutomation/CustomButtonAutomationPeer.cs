using System.Windows.Automation.Peers;
using WPFAccessibility.CustomControls;

namespace WPFAccessibility.UIAutomation
{
    public class CustomButtonAutomationPeer : ButtonAutomationPeer
    {
        private readonly CustomButton _button;

        public CustomButtonAutomationPeer(CustomButton button) : base(button)
        {
            _button = button;
        }

        protected override string GetHelpTextCore()
        {
            return $"HorizontalAlignment={_button.HorizontalAlignment};VerticalAlignment={_button.VerticalAlignment}";
        }

        public override object GetPattern(PatternInterface patternInterface)
        {
            if (patternInterface == PatternInterface.Value)
            {
                return new CustomButtonValuePatternProvider(_button);
            }

            return base.GetPattern(patternInterface);
        }
    }
}
