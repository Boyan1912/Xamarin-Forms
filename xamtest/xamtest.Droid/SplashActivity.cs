using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Content.PM;
using Android.Support.V7.App;
using Android.Webkit;
using Android.Graphics;

namespace xamtest.Droid
{
    [Activity(Theme = "@style/SplashTheme", MainLauncher = true, NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        public override void OnCreate(Bundle savedInstanceState, PersistableBundle persistentState)
        {
            base.OnCreate(savedInstanceState, persistentState);
            
        }

        protected override void OnResume()
        {
            base.OnResume();

            Task startupWork = new Task(() =>
            {
                //Log.Debug(TAG, "Performing some startup work that takes a bit of time.");

                //Task.Delay(5000);  // Simulate a bit of startup work.
                //Log.Debug(TAG, "Working in the background - important stuff.");
            });

            startupWork.ContinueWith(t =>
            {
                //Log.Debug(TAG, "Work is finished - start Activity1.");
                StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            }, TaskScheduler.FromCurrentSynchronizationContext());

            startupWork.Start();
        }

    }
}