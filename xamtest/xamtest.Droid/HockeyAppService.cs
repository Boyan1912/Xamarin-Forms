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

using HockeyApp.Android;
using HockeyApp.Android.Metrics;

namespace xamtest.Droid
{
    public class HockeyAppService : Data.IHockeyAppService
    {
        public HockeyAppService(Context applicationContext)
        {
            this.ApplicationContext = applicationContext;
        }

        public Context ApplicationContext { get; set; }

        
        public void Register(Context context, string appId)
        {
            FeedbackManager.Register(context, appId);
        }

        public void ShowFeedback()
        {
            FeedbackManager.ShowFeedbackActivity(ApplicationContext);
        }
        
        public void EnableCrashReporting()
        {
            CrashManager.Register(this.ApplicationContext, "4f6a452f03e641e289ac097c81a3e3c4");
        }

        public void CheckForUpdates(Activity activity)
        {
            // Remove this for store builds!
            UpdateManager.Register(activity, "4f6a452f03e641e289ac097c81a3e3c4");
        }

        public void UnregisterManagers()
        {
            UpdateManager.Unregister();
        }
        
    }
}