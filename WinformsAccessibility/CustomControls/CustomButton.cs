using System.Windows.Automation.Provider;
using System.Windows.Forms;
using WinformsAccessibility.UIAutomation;

namespace WinformsAccessibility.CustomControls
{
    public class CustomButton : Button
    {
        private CustomButtonRawElementProviderSimple _buttonRawElementProviderSimple;

        // Returns the provider object if the proper window message arrives from a UIAutomation client
        protected override void WndProc(ref Message m)
        {
            const int WmGetobject = 0x003D;

            if (m.Msg == WmGetobject && (long)m.LParam == AutomationInteropProvider.RootObjectId)
            {
                m.Result = AutomationInteropProvider.ReturnRawElementProvider(
                    Handle,
                    m.WParam,
                    m.LParam,
                    _buttonRawElementProviderSimple ?? (_buttonRawElementProviderSimple = new CustomButtonRawElementProviderSimple(this)));
                return;
            }

            base.WndProc(ref m);
        }
    }
}
