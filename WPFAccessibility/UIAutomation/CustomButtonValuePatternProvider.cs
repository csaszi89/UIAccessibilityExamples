using System.Windows.Automation.Provider;
using WPFAccessibility.CustomControls;

namespace WPFAccessibility.UIAutomation
{
    public class CustomButtonValuePatternProvider : IValueProvider
    {
        private readonly CustomButton _button;

        public CustomButtonValuePatternProvider(CustomButton button)
        {
            _button = button;
        }

        public string Value => _button.Content.ToString();

        public bool IsReadOnly => false;

        public void SetValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            _button.Content = value;
        }
    }
}
