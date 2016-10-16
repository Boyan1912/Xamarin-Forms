using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using xamtest.Models;

namespace xamtest.Pages
{
    public partial class AcrProgressPage : ContentPage
    {
        public AcrProgressPage()
        {
            InitializeComponent();

            this.BindingContext = new ProgressViewModel(UserDialogs.Instance);
        }
    }
}
