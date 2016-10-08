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
    public class TranslateTextBehavior : Behavior<TranslatableLabel>
    {
        const string ResourceId = "xamtest.Localization.Translations";

        static readonly BindablePropertyKey TranslatedTextKey = BindableProperty.CreateReadOnly("TranslatedText", typeof(string), typeof(TranslateTextBehavior), null);

        public static readonly BindableProperty TranslatedTextProperty = TranslatedTextKey.BindableProperty;

        public TranslateTextBehavior()
        {
            Resmgr = new ResourceManager(ResourceId, typeof(TranslateTextBehavior).GetTypeInfo().Assembly);
        }

        public string TranslatedText
        {
            get { return (string)base.GetValue(TranslatedTextProperty);  }
            private set { base.SetValue(TranslatedTextKey, value); }
        }

        public Picker LanguagePicker { get; set; }

        public ResourceManager Resmgr { get; set; }

        protected override void OnAttachedTo(TranslatableLabel bindable)
        {
            base.OnAttachedTo(bindable);
            if (LanguagePicker.SelectedIndex > -1)
            {
                LanguagePicker.SelectedIndexChanged += LanguagePicker_SelectedIndexChanged;
                TranslatedText = Resmgr.GetString(bindable.TranslateKey, Translations.Culture);
                bindable.Text = TranslatedText;
            }
        }

        private void LanguagePicker_SelectedIndexChanged(object sender, EventArgs e)
        {
            App.LanguageController.SetCurrentCulture(((Picker)sender).SelectedIndex);
        }

        protected override void OnDetachingFrom(TranslatableLabel bindable)
        {
            base.OnDetachingFrom(bindable);
            LanguagePicker.SelectedIndexChanged -= LanguagePicker_SelectedIndexChanged;
        }
    }
}
