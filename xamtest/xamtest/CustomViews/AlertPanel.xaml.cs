using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace xamtest.CustomViews
{
    public partial class AlertPanel : ContentView
    {
        public AlertPanel(string title, string message, string agree, string disagree)
        {
            InitializeComponent();

            TitleTxt.Text = title;
            MessageTxt.Text = message;
            AgreeTxt.Text = agree;
            DisagreeTxt.Text = disagree;

            RaiseChild(Panel);
            Panel.Opacity = 1;
        }
        
        public Label AgreeText { get { return AgreeTxt; } set { AgreeTxt = value; } }

        public Label DisagreeText { get { return DisagreeTxt; } set { DisagreeTxt = value; } }
    }
}
