using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace Xamarin.Forms
{
    public partial class BasePage : ContentPage
    {
        public BasePage()
        {
            InitializeComponent();
            
        }

        public RelativeLayout PgWrapper { get { return PageWrapper; } set { PageWrapper = value; } }

    }
}
