using System.Windows.Automation.Provider;
using WinformsAccessibility.CustomControls;

namespace WinformsAccessibility.UIAutomation
{
    /// <summary>
    /// Implements <see cref="IValueProvider"/> to provide ValuePattern relevant operations.
    /// </summary>
    public class CustomButtonValuePatternProvider : IValueProvider
    {
        private readonly CustomButton _button;

        /// <summary>
        /// Initiializes a new instance by storing the button control.
        /// </summary>
        /// <param name="button"></param>
        public CustomButtonValuePatternProvider(CustomButton button)
        {
            _button = button;
        }

        /// <summary>
        /// Returns the text property.
        /// </summary>
        public string Value => _button.Text;

        /// <summary>
        /// Returns false because the text can be modified.
        /// </summary>
        public bool IsReadOnly => false;

        /// <summary>
        /// Sets the text of the button.
        /// </summary>
        /// <param name="value">The text to set.</param>
        public void SetValue(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return;
            }

            _button.Text = value;
        }
    }
}
