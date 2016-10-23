using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamtest.Data;
using xamtest.Localization;

namespace xamtest.Models
{
    public interface ITextContainer
    {
        string Text { get; set; }

        string TranslateKey { get; set; }
    }
    
    public class Label : Xamarin.Forms.Label, ITextContainer
    {
        public Label()
        {
            MessagingCenter.Subscribe<LanguageController>(this, "CultureChanged", async (sender) =>
            {
                await App.AnimationsController.RotateChangingText(this);
            });
        }

        public string TranslateKey { get; set; }
    }

    public class Entry : Xamarin.Forms.Entry, ITextContainer
    {
        public Entry()
        {
            MessagingCenter.Subscribe<LanguageController>(this, "CultureChanged", async (sender) =>
            {
                await App.AnimationsController.RotateChangingText(this);
            });
        }

        public string TranslateKey { get; set; }
    }

    public class MyButton : Xamarin.Forms.Button, ITextContainer
    {
        public MyButton()
        {
            MessagingCenter.Subscribe<LanguageController>(this, "CultureChanged", async (sender) =>
            {
                await App.AnimationsController.RotateChangingText(this);
            });
        }

        public string TranslateKey { get; set; }
    }
    
}
