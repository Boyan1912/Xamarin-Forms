using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace xamtest.Pages
{
    public partial class WebViewsPage : ContentPage
    {
        private RelativeLayout _layout;
        


        public WebViewsPage()
        {
            InitializeComponent();

            _layout = new RelativeLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };



            _layout.Children.Add(
                new WebView
                {
                    Source = "https://www.onlinevideoconverter.com/video-converter#texturl",
                },
                    Constraint.RelativeToParent((p) =>
                    {
                        return 5;
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        return 5;
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        return p.Width;
                    }),

                    Constraint.RelativeToParent((p) =>
                    {
                        return 60;
                    })
                );
            


            var webView = new WebView
            {
                Source = "https://www.youtube.com/feed/subscriptions"
            };

            _layout.Children.Add(webView,
                    Constraint.RelativeToParent((p) =>
                    {
                        return 0;
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        return p.Height / 2 - 200;
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        return p.Width;
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        return p.Height / 2 + 100;
                    })
                );
        }
    }
}
