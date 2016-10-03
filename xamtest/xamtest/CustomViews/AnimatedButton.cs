using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamtest.Data;

namespace xamtest.CustomViews
{
    public class AnimatedButton : ContentView
    {
        private Label _textLabel;
        private StackLayout _layout;
        private Image _image;
        
        /// <summary>
        /// Creates a new instance of the animation button
        /// </summary>
        /// <param name="text">the text to set</param>
        /// <param name="callback">action to call when the animation is complete</param>
        public AnimatedButton(string text, int value = -1, Action callback = null)
        {   
            if (value >= 0)
                this.Value = value;

            this.BindingContext = App.LanguageController;
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
                Scale = .3,
            };

            // create the label
            _textLabel = new Label
            {
                FontSize = Device.GetNamedSize(NamedSize.Small, typeof(Label)),
                Text = text,
                TextColor = Color.White,
                VerticalOptions = LayoutOptions.Center,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                HorizontalTextAlignment = TextAlignment.Center
            };
            _layout.Children.Add(_image);
            _layout.Children.Add(_textLabel);

            // add a gester reco
            this.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async (o) =>
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

        public int Value { get; set; }

        
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

        public virtual string ImageSource
        {
            get
            {
                return _image.Source.ToString();
            }
            set
            {
                _image.Source = value;
            }
        }
    }
}
