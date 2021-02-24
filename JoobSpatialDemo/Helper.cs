using System.Windows.Forms;

namespace JoobSpatialDemo
{
    static class Helper
    {
        public static void DisplayError(this ErrorProvider errProvider, Control ctrl, string error)
        {
            if (error != null)
            {
                if (ctrl is Button)
                {
                    errProvider.SetIconAlignment(ctrl, ErrorIconAlignment.MiddleRight);
                }
                else
                {
                    errProvider.SetIconAlignment(ctrl, ErrorIconAlignment.TopRight);
                }

                errProvider.SetIconPadding(ctrl, 1);
            }

            errProvider.SetError(ctrl, error);
        }
    }
}
