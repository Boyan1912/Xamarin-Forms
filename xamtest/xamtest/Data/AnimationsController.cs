using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamtest.CustomViews;

namespace xamtest.Data
{
    
    public class AnimationsController
    {
        private LoadingIndicator loadIndicator;


        public AnimationsController()
        {
            loadIndicator = new LoadingIndicator();
        }

        public async Task ShowLoader(RelativeLayout layout)
        {
            layout.Children.Add(loadIndicator,
                Constraint.RelativeToParent((p) => 0), 
                Constraint.RelativeToParent((p) => 0),
                Constraint.RelativeToParent((p) => p.Width),
                Constraint.RelativeToParent((p) => p.Height));

            loadIndicator.IsVisible = true;
            
            layout.Children.Add(loadIndicator.Backdrop,
                Constraint.RelativeToParent((p) => 0),
                Constraint.RelativeToParent((p) => 0),
                Constraint.RelativeToParent((p) => p.Width),
                Constraint.RelativeToParent((p) => p.Height));

            loadIndicator.Opacity = 0;
            loadIndicator.Backdrop.Opacity = 0;

            layout.RaiseChild(loadIndicator);

            await Task.WhenAll(
                loadIndicator.FadeTo(1, 100, Easing.Linear).ContinueWith((t) => loadIndicator.Opacity = 1),
                loadIndicator.Backdrop.FadeTo(0.7, 3000, Easing.Linear),
                loadIndicator.ProgressBar.ProgressTo(1, 3000, Easing.Linear));

            await Task.Delay(3000);
            await HideLoader(layout);
        }

        public async Task HideLoader(RelativeLayout layout)
        {
            await Task.WhenAll(
                loadIndicator.FadeTo(1, 300, Easing.Linear).ContinueWith((t) => loadIndicator.Opacity = 1),
                loadIndicator.Backdrop.FadeTo(0, 1000, Easing.Linear));

            layout.Children.Remove(loadIndicator);
            layout.Children.Remove(loadIndicator.Backdrop);
            loadIndicator.ProgressBar.Progress = 0;
        }
    }

    
}
