using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace xamtest.CustomViews
{
    public partial class LoadingIndicator : ContentView
    {
        public LoadingIndicator()
        {
            InitializeComponent();

            Indicator = new ActivityIndicator()
            {
                IsVisible = true,
                IsRunning = true,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Color = Color.Navy,
                Scale = 2
            };

            TextLabel = new xamtest.Models.Label()
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.StartAndExpand,
                TextColor = Color.Green,
                FontSize = 25,
                RotationX = 20,
                TranslateKey = "load"
            };

            ProgressBar = new ProgressBar()
            {
                HorizontalOptions = LayoutOptions.Fill,
                VerticalOptions = LayoutOptions.StartAndExpand,
                Scale = 3,
                Opacity = 0
            };

            Container = new StackLayout
            {
                BackgroundColor = Color.Transparent,
                Padding = new Thickness(30, 30, 30, 30),
                Children =
                {
                    Indicator,
                    TextLabel,
                    ProgressBar
                }
            };

            Content = Container;

            Backdrop = new StackLayout
            {
                BackgroundColor = Color.White
            };
        }

        public StackLayout Backdrop { get; set; }

        public StackLayout Container { get; set; }

        public ActivityIndicator Indicator { get; set; }

        public xamtest.Models.Label TextLabel { get; set; }

        public ProgressBar ProgressBar { get; set; }
    }
}
