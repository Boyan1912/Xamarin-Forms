using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using xamtest.Models;

namespace xamtest.Pages
{
    public partial class AnimSettings : ContentPage
    {
        public AnimSettings()
        {
            InitializeComponent();

            //BindingContext = new AnimSetViewModel();   
            BackgroundColor = Color.White;
        }

        private async void Slider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            Slider slider = sender as Slider;

            await Task.Run(() => slider.Animate<double>("Increase", (x) => { return slider.Value + x; }, x => slider.Value = e.NewValue));
        }
    }
}
