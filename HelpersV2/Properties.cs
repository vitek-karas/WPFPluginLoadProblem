using System.Windows;
using System.Windows.Controls.Primitives;

namespace Helpers
{
    public class PropertiesVersion2
    {
        public static readonly DependencyProperty ButtonNameProperty;

        static PropertiesVersion2()
        {
            ButtonNameProperty = DependencyProperty.RegisterAttached("ButtonName", typeof(string), typeof(PropertiesVersion2));
        }

        public static void SetButtonName(ButtonBase button, string name)
            => button.SetValue(ButtonNameProperty, name);

        public static string GetButtonName(ButtonBase button)
            => (string)button.GetValue(ButtonNameProperty);
    }
}
