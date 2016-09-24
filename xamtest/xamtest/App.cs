using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using xamtest.Pages;

using Xamarin.Forms;
using xamtest.Data;

namespace xamtest
{
    public class App : Application
    {
        public App(Data.IHockeyAppService hockey)
        {
            HockeyAppService = hockey;

            Feedback = new Button { BackgroundColor = Color.FromRgba(2, 9, 6, .7), Text = "Send Feedback", TextColor = Color.Red, BorderColor = Color.Silver, BorderRadius = 40, BorderWidth = 5, FontSize = 20, IsVisible = true, Opacity = .4, IsEnabled = true, RotationX = -50, HeightRequest = 80, WidthRequest = 50 };

            Feedback.Clicked += (s, e) => { App.HockeyAppService.ShowFeedback(); };

            // Localization:
            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android)
            {
                var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
                Localization.Translations.Culture = ci; // set the RESX for resource localization
                DependencyService.Get<ILocalize>().SetLocale(ci); // set the Thread for locale-aware methods
            }




            var pageOne = new ContentPage
            {
                Title = "HockeyApp Test",
                BackgroundColor = Color.Black,
                Content = new ScrollView
                {
                    Content = new StackLayout
                    {
                        Padding = new Thickness(20, 0),
                        VerticalOptions = LayoutOptions.StartAndExpand,
                        Orientation = StackOrientation.Vertical,
                        WidthRequest = 500,

                        Children = {
                                Feedback,
                                new Image{
                                    Source=ImageSource.FromFile("dari.jpg"), HorizontalOptions=LayoutOptions.Center, VerticalOptions=LayoutOptions.StartAndExpand, Aspect=Aspect.AspectFill, Rotation = -15, RotationX = -5, RotationY = -20, HeightRequest=250
                                },
                                new Label {
                                    HorizontalTextAlignment = TextAlignment.Center,
                                    Text = "Hockey App Test :)!",
                                    TextColor = Color.Purple,
                                    FontAttributes = FontAttributes.Bold,
                                    FontFamily = "Droid Sans Mono",
                                    FontSize = 30,
                                    Margin = new Thickness(10, 20)
                                },
                                new Image{
                                    Source=ImageSource.FromFile("davi.jpg"), HorizontalOptions=LayoutOptions.Center, VerticalOptions=LayoutOptions.StartAndExpand, Aspect=Aspect.AspectFit, Rotation= 10
                                },
                            },
                    }

                }
            };

            MainPage = new TabbedPage
            {
                Children ={
                    pageOne,
                    new RandomAnimations(),
                    //new AnimationsSettings(new Models.AnimationSettingsVM()),
                }
            };
        }

        public static Data.IHockeyAppService HockeyAppService { get; set; }

        public static Button Feedback { get; set; }

        public static int ScreenHeight { get; set; }

        public static int ScreenWidth { get; set; }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        
    }
}
