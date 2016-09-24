using System;
using System.Threading.Tasks;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms;


namespace xamtest.Droid
{
    [Activity(Label = "xamtest", Icon = "@drawable/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            
            App.ScreenHeight = (int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density);
            App.ScreenWidth = (int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density);

            base.OnCreate(savedInstanceState);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            var hockeyService = new HockeyAppService(ApplicationContext);
            //hockeyService.Register(this, "$Your_App_Id");
            //hockeyService.CheckForUpdates(this);
            //HockeyApp.Android.LoginManager.Register(this, "$APP_SECRET", HockeyApp.Android.LoginManager.LoginModeEmailPassword);
            //HockeyApp.Android.LoginManager.VerifyLogin(this, Intent);
            //hockeyService.EnableCrashReporting();
            

            LoadApplication(new App(hockeyService));
        }


        protected override void OnPause()
        {
            base.OnPause();
            (App.HockeyAppService as HockeyAppService).UnregisterManagers();
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            (App.HockeyAppService as HockeyAppService).UnregisterManagers();
        }
    }
}


