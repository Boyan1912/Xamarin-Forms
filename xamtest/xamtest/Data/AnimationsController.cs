using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamtest.CustomViews;
using xamtest.Extensions;
using xamtest.Localization;
using xamtest.Models;

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
                loadIndicator.Backdrop.FadeTo(0.7, 3000, Easing.Linear));
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

        public async Task RotateChangingText(ITextContainer control)
        {
            View textView = control as View;
            textView.AnchorX = 0.5;
            textView.AnchorY = 0.5;
            string translation = Translations.ResourceManager.GetString(control.TranslateKey);
            if (translation != null)
            {
                await textView.RotateXTo(90, 300, Easing.CubicOut);
                control.Text = translation;
                await Task.Delay(50);
                await textView.RotateXTo(0, 500, Easing.CubicOut);
            }
            else
            {
                await textView.RotateXTo(90, 300, Easing.CubicOut);
                control.Text = control.TranslateKey;
                await Task.Delay(50);
                await textView.RotateXTo(0, 500, Easing.CubicOut);
            }
        }

        public async Task ShowPanel(RelativeLayout layout, View panel, Side from)
        {
            switch (from)
            {
                case Side.Left:
                        layout.Children.Add(panel,
                        Constraint.RelativeToParent((p) => p.Width * -1),
                        Constraint.RelativeToParent((p) => 0),
                        Constraint.RelativeToParent((p) => p.Width),
                        Constraint.RelativeToParent((p) => p.Height));
                        break;
                case Side.Top:
                        layout.Children.Add(panel,
                        Constraint.RelativeToParent((p) => 0),
                        Constraint.RelativeToParent((p) => p.Height * -1),
                        Constraint.RelativeToParent((p) => p.Width),
                        Constraint.RelativeToParent((p) => p.Height));
                        break;
                case Side.Right:
                        layout.Children.Add(panel,
                        Constraint.RelativeToParent((p) => p.Width + 10),
                        Constraint.RelativeToParent((p) => 0),
                        Constraint.RelativeToParent((p) => p.Width),
                        Constraint.RelativeToParent((p) => p.Height));
                        break;
                case Side.Bottom:
                        layout.Children.Add(panel,
                        Constraint.RelativeToParent((p) => 0),
                        Constraint.RelativeToParent((p) => p.Height + 10),
                        Constraint.RelativeToParent((p) => p.Width),
                        Constraint.RelativeToParent((p) => p.Height));
                        break;
            }

            Rectangle showPosition = new Rectangle(layout.X, layout.Y, layout.Width, layout.Height);
            await panel.LayoutTo(showPosition, 500, Easing.CubicOut);
            layout.SetBounds(panel);
        }

        public async Task HidePanel(RelativeLayout layout, View panel, Side to)
        {
            Rectangle hidePosition = new Rectangle(layout.Width * -1, layout.Y, layout.Width, layout.Height);

            switch (to)
            {
                case Side.Top:
                    hidePosition.X = layout.X;
                    hidePosition.Y = layout.Height * -1;
                    break;
                case Side.Right:
                    hidePosition.X = layout.Width + 10;
                    hidePosition.Y = layout.Y;
                    break;
                case Side.Bottom:
                    hidePosition.X = layout.X;
                    hidePosition.Y = layout.Height + 10;
                    break;
            }

            await panel.LayoutTo(hidePosition, 500, Easing.CubicIn);
            layout.SetBounds(panel);
        }

        public async Task PopUpFromTop(string message, RelativeLayout layout)
        {

            Xamarin.Forms.Label text = new Xamarin.Forms.Label
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = message,
                TextColor = Color.Maroon,
                HorizontalTextAlignment = TextAlignment.Center,
                VerticalTextAlignment = TextAlignment.Center
            };
            Frame pop = new Frame
            {
                BackgroundColor = Color.FromRgba(0.7, 0.7, 0.7, 1),
                Padding = new Thickness(10),
                Opacity = 0,
            };
            pop.Content = text;

            layout.Children.Add(pop, Constraint.RelativeToParent((p) => p.Width / 2 - text.Text.Length * 4),
                    Constraint.RelativeToParent((p) => 0),
                    Constraint.RelativeToParent((p) => text.Text.Length * 8),
                    Constraint.RelativeToParent((p) => 40));

            Rectangle endPosition = new Rectangle(pop.X - 30, pop.Y + layout.Height / 12, pop.Width + 30, pop.Height + 20);

            await Task.WhenAll(
                pop.FadeTo(1, 1500, Easing.CubicOut),
                pop.LayoutTo(endPosition, 1500, Easing.CubicOut));

            layout.SetBounds(pop);

            await pop.FadeTo(0, 1500, Easing.CubicIn);
            layout.Children.Remove(pop);
        }
    }

    public enum Side
    {
        Left,
        Top,
        Right,
        Bottom
    }
}
