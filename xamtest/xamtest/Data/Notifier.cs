using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamtest.CustomViews;

namespace xamtest.Data
{
    public class Notifier
    {


        [Obsolete]
        public static async Task<bool> Alert(RelativeLayout layout, string title, string message, string agree, string disagree)
        {
            var panel = new AlertPanel(title, message, agree, disagree);

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            Task<bool> task = tcs.Task;

            panel.AgreeText.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    await App.AnimationsController.AnimateTap(panel.AgreeText);
                    tcs.SetResult(true);
                    await App.AnimationsController.HidePanel(layout, panel, Side.Right);
                })
            });
            panel.DisagreeText.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    await App.AnimationsController.AnimateTap(panel.DisagreeText);
                    tcs.SetResult(false);
                    await App.AnimationsController.HidePanel(layout, panel, Side.Right);
                })
            });

            await App.AnimationsController.ShowPanel(layout, panel, Side.Right);
            
            return await task;
        }

        public static async Task<bool> Alert(Layout<View> layout, string title, string message, string agree, string disagree, Side from = Side.Right, Side to = Side.Right)
        {
            var panel = new AlertPanel(title, message, agree, disagree);

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            Task<bool> task = tcs.Task;

            Random rnd = new Random();

            panel.AgreeText.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    await App.AnimationsController.AnimateTap(panel.AgreeText);
                    tcs.SetResult(true);
                    await App.AnimationsController.HidePanel(layout, panel, (Side)rnd.Next(0, 4));
                })
            });
            panel.DisagreeText.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    await App.AnimationsController.AnimateTap(panel.DisagreeText);
                    tcs.SetResult(false);
                    await App.AnimationsController.HidePanel(layout, panel, (Side)rnd.Next(0, 4));
                })
            });

            await App.AnimationsController.ShowPanel(layout, panel, (Side)rnd.Next(0, 4));

            return await task;
        }

        public static async Task<bool> DisplayAlert(Layout<View> layout, string title, string message, string agree, string disagree)
        {
            var panel = new AlertPanel(title, message, agree, disagree);

            TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
            Task<bool> task = tcs.Task;
            
            panel.AgreeText.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    await App.AnimationsController.AnimateTap(panel.AgreeText);
                    try { await panel.ScaleTo(0); } catch { }
                    tcs.SetResult(true);
                    Device.BeginInvokeOnMainThread(() => layout.Children.Remove(panel));
                })
            });
            panel.DisagreeText.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(async () =>
                {
                    await App.AnimationsController.AnimateTap(panel.DisagreeText);
                    try { await panel.ScaleTo(0); } catch { }
                    tcs.SetResult(false);
                    Device.BeginInvokeOnMainThread(() => layout.Children.Remove(panel));
                })
            });

            await App.AnimationsController.ShowPanelScaling(layout, panel);

            return await task;
        }

    }
}
