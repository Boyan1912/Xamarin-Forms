using System;
using System.Threading.Tasks;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;

using Xamarin.Forms;
using xamtest.Localization;
using System.Reflection;
using Acr.UserDialogs;

namespace xamtest.Droid
{
    [Activity(Label = "@string/app_name", Icon = "@drawable/empty_star", Theme = "@style/MainTheme.Base", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //SetTheme(Resource.Style.MainTheme);

            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);

            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            App.ScreenHeight = (int)(Resources.DisplayMetrics.HeightPixels / Resources.DisplayMetrics.Density);
            App.ScreenWidth = (int)(Resources.DisplayMetrics.WidthPixels / Resources.DisplayMetrics.Density);

            LoadApplication(new App());

            AddShortcut();
            
            //var hockeyService = new HockeyAppService(ApplicationContext);
            //hockeyService.Register(this, "4f6a452f03e641e289ac097c81a3e3c4");
            //hockeyService.CheckForUpdates(this);
            //HockeyApp.Android.LoginManager.Register(this, "eb7057abe50d700a121edbd521b31363", HockeyApp.Android.LoginManager.LoginModeEmailPassword);
            //HockeyApp.Android.LoginManager.VerifyLogin(this, Intent);
            //hockeyService.EnableCrashReporting();

            //UserDialogs.Init(this);
            
        }


        private void AddShortcut()
        {
            //Adding shortcut for MainActivity 
            //on Home screen
            Intent shortcutIntent = new Intent(this, typeof(MainActivity));

            shortcutIntent.SetAction(Intent.ActionMain);

            Intent addIntent = new Intent();
            addIntent.PutExtra(Intent.ExtraShortcutIntent, shortcutIntent);
            addIntent.PutExtra(Intent.ExtraShortcutName, Resource.String.app_name);
            addIntent.PutExtra(Intent.ExtraShortcutIconResource, Intent.ShortcutIconResource.FromContext(this, Resource.Drawable.sexy));

            addIntent.SetAction("com.android.launcher.action.INSTALL_SHORTCUT");
            addIntent.PutExtra("duplicate", false);  //may it's already there so don't duplicate
            this.SendBroadcast(addIntent);
        }
        //protected override void OnPause()
        //{
        //    base.OnPause();
        //    (App.HockeyAppService as HockeyAppService).UnregisterManagers();
        //}

        //protected override void OnDestroy()
        //{
        //    base.OnDestroy();
        //    (App.HockeyAppService as HockeyAppService).UnregisterManagers();
        //}
    }
}


