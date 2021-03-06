using System.Windows.Automation.Provider;
using WinformsAccessibility.CustomControls;

namespace WinformsAccessibility.UIAutomation
{
    /// <summary>
    /// Implements <see cref="IRawElementProviderSimple"/> to provide basic operations.
    /// </summary>
    public class CustomButtonRawElementProviderSimple : IRawElementProviderSimple
    {
        private readonly CustomButton _button;

        /// <summary>
        /// Initializes a new instance by storing the button control.
        /// </summary>
        /// <param name="button"></param>
        public CustomButtonRawElementProviderSimple(CustomButton button)
        {
            _button = button;
        }

        public ProviderOptions ProviderOptions => ProviderOptions.ServerSideProvider;

        public IRawElementProviderSimple HostRawElementProvider => null;

        public object GetPatternProvider(int patternId)
        {
            // https://docs.microsoft.com/en-us/windows/win32/winauto/uiauto-controlpattern-ids
            int valuePatternId = 10002;

            if (patternId == valuePatternId)
            {
                return new CustomButtonValuePatternProvider(_button);
            }

            // Other patterns can be implemented too...

            return null;
        }

        public object GetPropertyValue(int propertyId)
        {
            // https://docs.microsoft.com/en-us/windows/win32/winauto/uiauto-automation-element-propids
            int localizedControlTypePropId = 30004;
            int helpTextPropId = 30013;

            if (propertyId == localizedControlTypePropId)
            {
                return "button";
            }
            if (propertyId == helpTextPropId)
            {
                return $"TextAlign={_button.TextAlign}";
            }

            // Other properties can be implemented too...

            return null;
        }
    }
}
