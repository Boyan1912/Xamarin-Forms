using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace xamtest.CustomViews
{
    public partial class LanguagePicker : ContentView
    {
        public LanguagePicker()
        {
            InitializeComponent();
            BindingContext = App.LanguageController;
        }
    }
}
