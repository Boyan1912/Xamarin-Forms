using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace xamtest.Pages
{
    public partial class RandomAnimations : ContentPage
    {
        Random rnd = new Random();
        Easing[] easings = new[] { Easing.BounceIn, Easing.BounceOut, Easing.CubicIn, Easing.CubicInOut, Easing.CubicOut, Easing.Linear, Easing.SinIn, Easing.SinInOut, Easing.SinOut, Easing.SpringIn, Easing.SpringOut };


        public RandomAnimations()
        {
            InitializeComponent();
            Title = "Animations";
            LoadContent();
        }

        private Color GetRandomColor(int margin = 256)
        {
            return Color.FromRgba(rnd.Next(margin), rnd.Next(margin), rnd.Next(margin), (rnd.Next(margin))).WithHue(rnd.NextDouble()).WithLuminosity(rnd.NextDouble()).WithSaturation(rnd.NextDouble());
        }

        private void LoadContent()
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    var btn = new Button
                    {
                        Command = this.AnimateBtn,
                        BackgroundColor = GetRandomColor()
                    };

                    btn.CommandParameter = btn;
                    grid.Children.Add(btn, j, i);
                }
            }

            grid.BackgroundColor = GetRandomColor();
            //Device.StartTimer(System.TimeSpan.FromMilliseconds(200), () => {
                
            //}
        }

        public ICommand AnimateBtn
        {
            get
            {
                return new Command<View>(async delegate (View item)
                {
                    (item as Button).Text = xamtest.Localization.Translations.FlyOutAnim;
                    (item as Button).TextColor = Color.Pink;
                    (item as Button).FontSize = 8;
                    //start random animation
                    await Task.WhenAll(
                            item.RotateXTo(rnd.Next(500), (uint)rnd.Next(100, 4000), easings[rnd.Next(easings.Length)]),
                            item.RotateYTo(rnd.Next(500), (uint)rnd.Next(100, 4000), easings[rnd.Next(easings.Length)]),
                            item.FadeTo(rnd.NextDouble() + .4, (uint)rnd.Next(100, 4000), easings[rnd.Next(easings.Length)]),
                            item.TranslateTo(rnd.Next(-App.ScreenWidth + (int)item.X, App.ScreenWidth - (int)item.X), rnd.Next(-App.ScreenHeight + (int)item.Y, App.ScreenHeight - (int)item.Y), (uint)rnd.Next(100, 4000), easings[rnd.Next(easings.Length)]),
                            item.ScaleTo(rnd.NextDouble() * 7, (uint)rnd.Next(100, 4000), easings[rnd.Next(easings.Length)])
                        );
                    // change color
                    item.BackgroundColor = GetRandomColor();
                    (item as Button).Text = xamtest.Localization.Translations.FlyInAnim;
                    (item as Button).TextColor = Color.Purple;
                    // go back to where it came from:
                    await Task.WhenAll(
                            item.RotateXTo(0, (uint)rnd.Next(100, 4000), easings[rnd.Next(easings.Length)]),
                            item.RotateYTo(0, (uint)rnd.Next(100, 4000), easings[rnd.Next(easings.Length)]),
                            item.FadeTo(1, (uint)rnd.Next(100, 4000), easings[rnd.Next(easings.Length)]),
                            item.TranslateTo(0, 0, (uint)rnd.Next(100, 4000), easings[rnd.Next(easings.Length)]),
                            item.ScaleTo(1, (uint)rnd.Next(100, 4000), easings[rnd.Next(easings.Length)])
                        );

                    (item as Button).Text = "";
                });
            }
        }
    }
}
