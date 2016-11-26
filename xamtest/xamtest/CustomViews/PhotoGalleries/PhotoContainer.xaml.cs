using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace xamtest.CustomViews.PhotoGalleries
{
    public partial class PhotoContainer : ContentView
    {
        private bool isSelected;

        public PhotoContainer()
        {
            InitializeComponent();
        }

        public bool IsSelected { get { return isSelected; } set {
                isSelected = value;
                if (isSelected)
                    BackgroundColor = Color.Maroon;
                else
                    BackgroundColor = Color.White;
            } }
    }
}
