﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using xamtest.Data;
using xamtest.Localization;
using xamtest.Models;
using xamtest.Extensions;

namespace xamtest.Pages
{
    public partial class RandomAnimations : ContentPage
    {
        Random rnd = new Random();
        Easing[] easings = new[] { Easing.BounceIn, Easing.BounceOut, Easing.CubicIn, Easing.CubicInOut, Easing.CubicOut, Easing.Linear, Easing.SinIn, Easing.SinInOut, Easing.SinOut, Easing.SpringIn, Easing.SpringOut };

        private int successful;
        private int failed;
        private string successCount;
        private string failCount;


        public RandomAnimations()
        {
            InitializeComponent();
            Title = "Random Animations";
            BindingContext = this;
            LoadContent();
            
        }

        public string SuccessCount { get { return successCount; } set { successCount = "Kicked in the ass: \n" + value; OnPropertyChanged(); } }

        public string FailCount { get { return failCount; } set { failCount = "Punched in the nose: \n" + value; OnPropertyChanged(); }
        }

        private Color GetRandomColor()
        {
            return Color.FromRgba(rnd.NextDouble(), rnd.NextDouble(), rnd.NextDouble(), (1)).WithHue(rnd.NextDouble()).WithLuminosity(rnd.NextDouble()).WithSaturation(rnd.NextDouble());
        }

        private void LoadContent()
        {
            int rows = rnd.Next(7, 16);
            int cols = rnd.Next(3, 8);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    var btn = new Button
                    {
                        Command = this.AnimateBtn,
                        BackgroundColor = GetRandomColor(),
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        //Image = "sexy" + rnd.Next(0, 11) + ".jpg",
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
                    successful++;
                    if (successful > 100)
                        await App.Navigation.PushAsync(new RandomAnimations());

                    SuccessCount = successful.ToString();
                    (item as Button).Text = Translations.FlyOutAnim;
                    (item as Button).TextColor = GetRandomColor();
                    (item as Button).FontSize = 5;
                    //(item as Button).IsEnabled = false;
                    grid.RaiseChild((item as Button));
                    (item as Button).Command = new Command(() => { failed++; FailCount = failed.ToString(); });
                    //start random animation
                try
                    {
                        await Task.WhenAll(
                        item.ColorTo(item.BackgroundColor, GetRandomColor(), x => item.BackgroundColor = x, 4000, easings[rnd.Next(easings.Length)]),
                            item.RotateXTo(rnd.Next(500), (uint)rnd.Next(100, 4000), easings[rnd.Next(easings.Length)]),
                            item.RotateYTo(rnd.Next(500), (uint)rnd.Next(100, 4000), easings[rnd.Next(easings.Length)]),
                            item.FadeTo(1, (uint)rnd.Next(100, 4000), easings[rnd.Next(easings.Length)]),
                            item.TranslateTo(rnd.Next(-App.ScreenWidth + (int)item.X, App.ScreenWidth - (int)item.X), rnd.Next(-App.ScreenHeight + (int)item.Y, App.ScreenHeight - (int)item.Y), (uint)rnd.Next(100, 4000), easings[rnd.Next(easings.Length)]),
                            item.ScaleTo(rnd.NextDouble() * 6, (uint)rnd.Next(100, 4000), easings[rnd.Next(easings.Length)])
                        );
                        // change color
                        item.BackgroundColor = GetRandomColor();
                        (item as Button).Text = xamtest.Localization.Translations.FlyInAnim;
                        (item as Button).TextColor = GetRandomColor();
                        // go back to where it came from:
                        await Task.WhenAll(
                                item.RotateXTo(0, (uint)rnd.Next(100, 4000), easings[rnd.Next(easings.Length)]),
                                item.RotateYTo(0, (uint)rnd.Next(100, 4000), easings[rnd.Next(easings.Length)]),
                                //item.FadeTo(1, (uint)rnd.Next(100, 4000), easings[rnd.Next(easings.Length)]),
                                item.TranslateTo(0, 0, (uint)rnd.Next(100, 4000), easings[rnd.Next(easings.Length)]),
                                item.ScaleTo(1, (uint)rnd.Next(100, 4000), easings[rnd.Next(easings.Length)]),
                                item.ColorTo(item.BackgroundColor, GetRandomColor(), x => item.BackgroundColor = x, 4000, easings[rnd.Next(easings.Length)])
                            );
                    }
                    catch (Exception) { }

                    (item as Button).Text = "";
                    //(item as Button).IsEnabled = true;
                    (item as Button).Command = AnimateBtn;
                });
            }
        }
    }
}
