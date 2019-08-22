using System.Windows;
using System.Windows.Controls.Primitives;

namespace Helpers
{
    public class PropertiesVersion1
    {
        public static readonly DependencyProperty ButtonNameProperty;

        static PropertiesVersion1()
        {
            ButtonNameProperty = DependencyProperty.RegisterAttached("ButtonName", typeof(string), typeof(PropertiesVersion1));
        }

        public static void SetButtonName(ButtonBase button, string name)
            => button.SetValue(ButtonNameProperty, name);

        public static string GetButtonName(ButtonBase button)
            => (string)button.GetValue(ButtonNameProperty);
    }
}
