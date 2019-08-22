using PluginBase;
using System;
using System.IO;
using System.Windows.Markup;
using System.Xml;

namespace FirstPlugin
{
    public class FirstPlugin : IPlugin
    {
        public void Run()
        {
            Console.WriteLine("FirstPlugin: running");
            Helpers.Helpers.Version1Function();

            var xaml = @"
<ResourceDictionary
    xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/presentation""
    xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""
    xmlns:p=""clr-namespace:Helpers;assembly=Helpers"">
    <Style x:Key=""ButtonWithName"" TargetType=""{x:Type Button}"">
        <Setter Property=""p:PropertiesVersion1.ButtonName"" Value=""Frank""/>
    </Style>
</ResourceDictionary>
";
            var reader = new StringReader(xaml);
            var xml = XmlReader.Create(reader);
            XamlReader.Load(xml);
        }
    }
}
