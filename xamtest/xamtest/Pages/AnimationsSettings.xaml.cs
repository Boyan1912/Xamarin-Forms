using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace xamtest.Pages
{
    public partial class AnimationsSettings : ContentPage
    {
        const int MAX_COLOR_VALUE = 255;
        private Models.AnimationSettingsVM vm;

        public AnimationsSettings(Models.AnimationSettingsVM vm)
        {
            InitializeComponent();
            Title = "Animations Settings";

            this.vm = vm;
            BindingContext = vm;

            feed.Clicked += (s, e) => App.HockeyAppService.ShowFeedback();

            //progBarRed.BackgroundColor = Color.FromRgba(100, 20, 10, 100);
            //progBarGreen.BackgroundColor = Color.FromRgba(10, 20, 100, 100);
            //progBarBlue.BackgroundColor = Color.FromRgba(100, 10, 20, 100);

            //progBarRed.BindingContextChanged += ProgBarRed_BindingContextChanged;
            //progBarGreen.BindingContextChanged += ProgBarGreen_BindingContextChanged;
            //progBarBlue.BindingContextChanged += ProgBarBlue_BindingContextChanged;

            //var tapGestureRecognizer = new TapGestureRecognizer();
            //tapGestureRecognizer.Tapped += (s, e) => {
            //    (s as ProgressBar).ProgressTo((s as ProgressBar).Progress + .1, 250, Easing.Linear);
            //};
            //progBarRed.GestureRecognizers.Add(tapGestureRecognizer);
            //progBarGreen.GestureRecognizers.Add(tapGestureRecognizer);
            //progBarBlue.GestureRecognizers.Add(tapGestureRecognizer);

            picker.Title = "Picker";
            
        }

        //private void ProgBarRed_BindingContextChanged(object sender, EventArgs e)
        //{
        //    (sender as ProgressBar).ProgressTo(vm.RedValue / MAX_COLOR_VALUE, 500, Easing.Linear);
        //}
        //private void ProgBarBlue_BindingContextChanged(object sender, EventArgs e)
        //{
        //    (sender as ProgressBar).ProgressTo(vm.BlueValue / MAX_COLOR_VALUE, 500, Easing.Linear);
        //}
        //private void ProgBarGreen_BindingContextChanged(object sender, EventArgs e)
        //{
        //    (sender as ProgressBar).ProgressTo(vm.GreenValue / MAX_COLOR_VALUE, 500, Easing.Linear);
        //}
    }
}
