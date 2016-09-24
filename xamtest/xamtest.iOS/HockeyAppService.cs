using HockeyApp.iOS;

namespace xamtest.iOS
{
    public class HockeyAppService : Data.IHockeyAppService
    {

        public HockeyAppService()
        {
            EnableAutoUpdates();
            // Authenticating Users on iOS: https://support.hockeyapp.net/kb/client-integration-ios-mac-os-x-tvos/authenticating-users-on-ios
        }

        private void EnableAutoUpdates()
        {
            // Initialise the Hockey SDK here
            var manager = BITHockeyManager.SharedHockeyManager;
            manager.Configure("$Your_App_Id");
            manager.StartManager();
            manager.Authenticator.AuthenticateInstallation(); // This line is obsolete in crash only builds
        }

        private void DisableAutoUpdates()
        {
            var manager = BITHockeyManager.SharedHockeyManager;
            manager.Configure("$Your_App_Id");
            manager.DisableUpdateManager = true;
            manager.StartManager();
        }

        public void ShowFeedback()
        {
            // This is where the feedback form gets displayed
            var feedbackManager = BITHockeyManager.SharedHockeyManager.FeedbackManager;
            feedbackManager.ShowFeedbackListView();
        }
        
    }
}