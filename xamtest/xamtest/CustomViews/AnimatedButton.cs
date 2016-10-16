using System;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

using Xamarin.Forms;
using xamtest.Data;
using xamtest.Localization;
using xamtest.Models;

namespace xamtest.CustomViews
{
    public class AnimatedButton : ContentView
    {
        private xamtest.Models.Label _textLabel;
        private StackLayout _layout;
        private Image _image;
        
        /// <summary>
        /// Creates a new instance of the animation button
        /// </summary>
        /// <param name="keyOrText">the text to set</param>
        /// <param name="callback">action to call when the animation is complete</param>
        public AnimatedButton(string keyOrText, Action callback = null, string img = null)
        {
            //MessagingCenter.Subscribe<LanguageController>(this, "CultureChanged", async (sender) =>
            //{
            //    string translation = Translations.ResourceManager.GetString(keyOrText);
            //    if (translation != null)
            //    {
            //        await _textLabel.ScaleTo(0, 50, Easing.SpringIn);
            //        _textLabel.Text = translation;
            //        await _textLabel.ScaleTo(1, 50, Easing.SpringOut);
            //    }
            //});
            
            // create the layout
            _layout = new StackLayout
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Orientation = StackOrientation.Horizontal,
                Padding = 5,
            };
            // create the image
            _image = new Image
            {
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.Start,
                HeightRequest = 20,
                WidthRequest = 25,
                Source = FileImageSource.FromResource("xamtest.Images." + img),
                Aspect = Aspect.AspectFit
            };

            // create the label
            //string text = Translations.ResourceManager.GetString(keyOrText);
            _textLabel = new xamtest.Models.Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Micro, typeof(Xamarin.Forms.Label)),
                //Text = text != null ? text : keyOrText,
                TranslateKey = keyOrText,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center,
                LineBreakMode = LineBreakMode.NoWrap
                
            };
            _textLabel.TranslateText();
            _layout.Children.Add(_image);
            _layout.Children.Add(_textLabel);

            // add a gester reco
            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    await this.ScaleTo(0.95, 50, Easing.CubicOut);
                    await this.ScaleTo(1, 50, Easing.CubicIn);
                    if (callback != null)
                        callback.Invoke();
                })
            });

            // set the content
            this.Content = _layout;
        }
        
        
        /// <summary>
        /// Gets or sets the font size for the text
        /// </summary>
        public virtual double FontSize
        {
            get { return this._textLabel.FontSize; }
            set
            {
                this._textLabel.FontSize = value;
            }
        }

        /// <summary>
        /// Gets or sets the text color for the text
        /// </summary>
        public virtual Color TextColor
        {
            get
            {
                return _textLabel.TextColor;
            }
            set
            {
                _textLabel.TextColor = value;
            }
        }
        
    }
}
