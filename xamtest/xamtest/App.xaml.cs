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
using xamtest.AbsoluteLayoutPages;

namespace xamtest
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            AnimationsController = new AnimationsController();

            LanguageController = new LanguageController();
            LanguageController.SetCurrentCulture(0);

            var rootPage = new NavigationPage(new CarouselPage
            {
                Children =
                {
                    new AbsoluteLayoutTestPage(),
                    //new GalleryPage(),
                    //new ShowItemFromOutside(),
                    //new RandomAnimations(),
                    //new RedbitPage(),
                    //new WebViewsPage()
                    //new AnimSettings(),
                    
                }
            });

            App.Navigation = rootPage.Navigation;

            MainPage = rootPage;
        }

        public App(Data.IHockeyAppService hockey) : this()
        {
            HockeyAppService = hockey;
        }

        public static AnimationsController AnimationsController { get; set; }

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
