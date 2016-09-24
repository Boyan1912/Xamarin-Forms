using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace xamtest.CustomViews
{
    public partial class Feedback : StackLayout
    {
        public Feedback()
        {
            InitializeComponent();

            feed.Clicked += (s, e) => App.HockeyAppService.ShowFeedback();
        }

        
    }
}
