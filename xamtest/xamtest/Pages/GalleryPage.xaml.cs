using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using xamtest.Data;

namespace xamtest.Pages
{
    public partial class GalleryPage : BasePage
    {
        public GalleryPage()
        {
            InitializeComponent();

            TestErrorReporterBtn.Clicked += (s, e) => TestErrorReporting();
            TestAnotherErrorReporterBtn.Clicked += (s, e) => TestErrorReportingAgain();
        }

        private async void TestErrorReporting()
        {
            try
            {
                int someNumber = 3;
                int impossibleResult = someNumber / 0;

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ErrorsReporter.CreateErrorReport(ex), "ok");
            }
        }

        private async void TestErrorReportingAgain()
        {
            try
            {
                throw new NullReferenceException("Something's not right here");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ErrorsReporter.CreateErrorReport(ex), "ok");
            }
        }

        private async void ShowLoader()
        {
            await App.AnimationsController.ShowLoader(Wrapper);
        }

        private async void HideLoader()
        {
            await App.AnimationsController.HideLoader(Wrapper);
        }

        protected override void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if ((int)width != App.ScreenWidth || (int)height != App.ScreenHeight)
            {
                App.ScreenWidth = (int)width;
                App.ScreenHeight = (int)height;
                if (width > height)
                {
                    ShowLoader();
                    Gallery.ReloadContent();
                    HideLoader();
                }
            }
        }
        
    }
}
