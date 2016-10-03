using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using xamtest.Pages;

using Xamarin.Forms;
using xamtest.Data;

using xamtest.Localization;
using System.Reflection;
using System.Globalization;

namespace xamtest
{
    public partial class App : Application
    {

        public App(Data.IHockeyAppService hockey)
        {
            HockeyAppService = hockey;
            LanguageController = new LanguageController();

            var rootPage = new NavigationPage(new CarouselPage
            {
                Title = "Carousel Page",
                Children =
                {
                    //new RedbitPage(),
                    //new RandomAnimations(),
                    //new AnimSettings(),
                    new FormattedTextsTestPage()
                }
            });

            App.Navigation = rootPage.Navigation;

            MainPage = rootPage;
        }

        public static LanguageController LanguageController { get; set; }

        public static INavigation Navigation { get; set; }

        public static IHockeyAppService HockeyAppService { get; set; }

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
