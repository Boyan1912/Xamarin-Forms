using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace xamtest.Pages
{
    public partial class FormattedTextsTestPage : ContentPage
    {
        public FormattedTextsTestPage()
        {
            InitializeComponent();

            LangWrapper.BindingContext = BindingContext = App.LanguageController; 
        }
    }
}
