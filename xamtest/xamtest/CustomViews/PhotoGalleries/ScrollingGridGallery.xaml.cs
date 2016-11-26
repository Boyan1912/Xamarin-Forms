using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace xamtest.CustomViews.PhotoGalleries
{
    public partial class ScrollingGridGallery : ContentView
    {
        private int currentColumn;
        private const int columnsPerPage = 4;
        private const int rows = 2;
        
        private Grid grid;

        public ScrollingGridGallery()
        {
            InitializeComponent();

            Scroll.Scrolled += Scroll_Scrolled;
            AddContent();
        }

        public StackLayout Container { get { return Wrapper; } set { Wrapper = value; } }
        
        private void Scroll_Scrolled(object sender, ScrolledEventArgs e)
        {
            double scrollingSpace = Scroll.ContentSize.Width - Scroll.Width;

            if (scrollingSpace <= e.ScrollX)
            {
                AddContent();
            }
        }

        // always run synchronously! 
        private void AddContent()
        {
            if (currentColumn == 0)
                grid = new Grid();

            for (int i = 0; i < rows; i++)
            {
                for (int j = currentColumn; j < currentColumn + columnsPerPage; j++)
                {
                    Image img = new Image { Source = ("sexy" + ((grid.Children.Count) % 11).ToString()) + ".jpg", Aspect = Aspect.Fill };

                    grid.Children.Add(img, j, i);
                }
            }

            if (currentColumn == 0)
                Wrapper.Children.Add(grid);

            currentColumn += columnsPerPage;
        }

        public void ReloadContent()
        {
            currentColumn = 0;
            AddContent();
        }


    }
}
