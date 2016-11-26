using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace xamtest.Pages
{
    public partial class GalleryPage : BasePage
    {
        public GalleryPage()
        {
            InitializeComponent();
        }


        private async void ShowLoader()
        {
            await App.AnimationsController.ShowLoader(Wrapper);
        }

        private async void HideLoader()
        {
            await App.AnimationsController.HideLoader(Wrapper);
        }

        protected override async void OnSizeAllocated(double width, double height)
        {
            base.OnSizeAllocated(width, height);
            if ((int)width != App.ScreenWidth || (int)height != App.ScreenHeight)
            {
                App.ScreenWidth = (int)width;
                App.ScreenHeight = (int)height;
                if (width > height)
                {
                    ShowLoader();
                    await Task.Run(() => Gallery.ReloadContent());
                    HideLoader();
                }
            }
        }
    }
}
