using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamtest.CustomControls;
using xamtest.Data;
using xamtest.Localization;

namespace xamtest.Behaviors
{
    public class TranslateTextBehavior : Behavior<Label>
    {
        const string ResourceId = "xamtest.Localization.Translations";
        Label bound;

        public TranslateTextBehavior()
        {
            Resmgr = new ResourceManager(ResourceId, typeof(TranslateTextBehavior).GetTypeInfo().Assembly);
        }
        
        public Picker LanguagePicker { get; set; }

        public ResourceManager Resmgr { get; set; }

        public string TranslateKey { get; set; }

        protected override void OnAttachedTo(Label bindable)
        {
            bound = bindable;
            LanguagePicker.SelectedIndexChanged += LanguagePicker_SelectedIndexChanged;
        }

        private void LanguagePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.LanguageController.SetCurrentCulture(((Picker)sender).SelectedIndex);
            string translatedText = Resmgr.GetString(TranslateKey, Translations.Culture);
            bound.SetValue(Label.TextProperty, translatedText);
        }

        protected override void OnDetachingFrom(Label bindable)
        {
            //LanguagePicker.SelectedIndexChanged -= LanguagePicker_SelectedIndexChanged;
        }
    }
}
