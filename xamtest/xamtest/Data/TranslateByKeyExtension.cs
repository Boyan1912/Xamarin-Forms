using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace xamtest.Data
{

    [ContentProperty("Key")]
    public class TranslateByKeyExtension
    {
        readonly CultureInfo ci;
        const string ResourceId = "xamtest.Localization.Translations";

        public string Key { get; set; }
        
        public object ProvideValue(IServiceProvider serviceProvider)
        {
            ResourceManager resmgr = new ResourceManager(ResourceId
                                , typeof(TranslateExtension).GetTypeInfo().Assembly);

            return resmgr.GetString(Key, ci);
        }
    }
}
