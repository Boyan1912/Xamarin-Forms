using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace xamtest.Pages
{
    public partial class MasterDetailPP : MasterDetailPage
    {
        public MasterDetailPP()
        {
            InitializeComponent();

            Master.Title = "master title";
            Detail = new RandomAnimations();
            //IsPresented = false;

            menuItemOne.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => {
                    this.Detail = new RandomAnimations();
                    this.IsPresented = false;
                })
            });
            menuItemTwo.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() => {
                    this.Detail = new RedbitPage();
                    IsPresented = false;
                })
            });
        }
    }
}
