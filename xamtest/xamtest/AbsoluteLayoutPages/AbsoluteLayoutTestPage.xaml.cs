using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using xamtest.Data;

namespace xamtest.AbsoluteLayoutPages
{
    public partial class AbsoluteLayoutTestPage : ContentPage
    {
        public AbsoluteLayoutTestPage()
        {
            InitializeComponent();

            MessagingCenter.Subscribe<object, Exception>(this, "Error", async (s, ex) => await DisplayAlert("Error", ErrorsReporter.CreateErrorReport(ex), "I get it"));
            TestButton.Clicked += TestButton_Clicked;
            TestLoadingIndicator.Clicked += TestLoadingIndicator_Clicked;
            TestRotation.Clicked += TestRotation_Clicked;
            TestAlertScaling.Clicked += TestAlertScaling_Clicked;
        }

        private async void TestAlertScaling_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool agree = await Notifier.DisplayAlert(Wrapper, "Logout", "Are you sure you want to leave?", "A-ha", "No way");
                if (agree)
                {
                    App.AnimationsController.PopUpFromTop("You're out!", Wrapper);
                }
                else
                {
                    App.AnimationsController.PopUpFromTop("Good choice...\nhave fun!", Wrapper);
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ErrorsReporter.CreateErrorReport(ex), "I get it");
            }
        }

        private void TestRotation_Clicked(object sender, EventArgs e)
        {
            if (TestRotation.Text == "Stop")
            {
                App.AnimationsController.StopRotating(Img);
                TestRotation.Text = "Rotate";
            }
            else
            {
                App.AnimationsController.RotateView(Img, true);
                TestRotation.Text = "Stop";
            }
        }

        private async void TestLoadingIndicator_Clicked(object sender, EventArgs e)
        {
            App.AnimationsController.ShowLoader(Wrapper);
            await Task.Delay(6000);
            App.AnimationsController.HideLoader(Wrapper);
        }

        private async void TestButton_Clicked(object sender, EventArgs e)
        {
            try
            {
                bool agree = await Notifier.Alert(Wrapper, "Test", "Do you want to get success?", "yes", "no");
                if (agree)
                {
                    App.AnimationsController.PopUpFromTop("Success!", Wrapper);
                }
                else
                {
                    App.AnimationsController.PopUpFromTop("Failure!", Wrapper);
                }
            }
            catch(Exception ex)
            {
                await DisplayAlert("Error", ErrorsReporter.CreateErrorReport(ex), "I get it");
            }
        }
    }
}
