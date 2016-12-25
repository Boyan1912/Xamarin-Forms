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

        public async Task AnimateTap(View view)
        {
            await view.ScaleTo(0.95, 50, Easing.CubicOut);
            await view.ScaleTo(1, 50, Easing.CubicIn);
        }


        // The right way - http://xfcomplete.net/xamarin.forms/2016/01/14/layoutto-doesnt-do-what-you-think-it-does/

        public async void ShowLoader(Layout<View> layout)
        {
            AbsoluteLayout.SetLayoutBounds(loadIndicator, new Rectangle(.5, .5, .5, .3));
            AbsoluteLayout.SetLayoutFlags(loadIndicator, AbsoluteLayoutFlags.All);
            loadIndicator.IsVisible = true;

            AbsoluteLayout.SetLayoutBounds(loadIndicator.Backdrop, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(loadIndicator.Backdrop, AbsoluteLayoutFlags.All);

            loadIndicator.Opacity = 0;
            loadIndicator.Backdrop.Opacity = 0;

            Device.BeginInvokeOnMainThread(() =>
            {
                layout.Children.Add(loadIndicator.Backdrop);
                layout.Children.Add(loadIndicator);
            });

            layout.RaiseChild(loadIndicator);

            await Task.WhenAll(
                loadIndicator.FadeTo(1, 200, Easing.Linear),
                loadIndicator.Backdrop.FadeTo(0.8, 3000, Easing.CubicOut));
        }

        public async void HideLoader(Layout<View> layout, LoadingIndicator loadInd = null)
        {
            loadInd = loadInd ?? loadIndicator;

            await Task.WhenAll(
                loadInd.FadeTo(0, 300, Easing.Linear),
                loadInd.Backdrop.FadeTo(0, 1000, Easing.CubicIn));

            layout.Children.Remove(loadInd);
            layout.Children.Remove(loadInd.Backdrop);
            loadIndicator.ProgressBar.Progress = 0;
        }

        public async Task ShowPanel(Layout<View> layout, View panel, Side from, Rectangle wholeSize = default(Rectangle))
        {

            if (wholeSize == default(Rectangle))
                wholeSize = layout.Bounds;

            panel.HeightRequest = wholeSize.Height;
            panel.IsVisible = true;

            try
            {
                await Task.Run(() => Device.BeginInvokeOnMainThread(() =>
                {
                    switch (from)
                    {
                        case Side.Left:
                            layout.Children.Add(panel);
                            var showFromLeft = new Animation(v => panel.TranslationX = v, -wholeSize.Width, 0);
                            showFromLeft.Commit(panel, "ShowFromLeft", 16, 250, Easing.CubicInOut, (v, c) => panel.TranslationX = 0, () => false);
                            break;
                        case Side.Top:
                            layout.Children.Add(panel);
                            var showFromTop = new Animation(v => panel.TranslationY = v, -wholeSize.Height, 0);
                            showFromTop.Commit(panel, "ShowFromTop", 16, 250, Easing.CubicInOut, (v, c) => panel.TranslationY = 0, () => false);
                            break;
                        case Side.Right:
                            layout.Children.Add(panel);
                            var showFromRight = new Animation(v => panel.TranslationX = v, wholeSize.Width, 0);
                            showFromRight.Commit(panel, "ShowFromRight", 16, 250, Easing.CubicInOut, (v, c) => panel.TranslationX = 0, () => false);
                            break;
                        case Side.Bottom:
                            layout.Children.Add(panel);
                            var showFromBottom = new Animation(v => panel.TranslationY = v, wholeSize.Height, 0);
                            showFromBottom.Commit(panel, "ShowFromBottom", 16, 250, Easing.CubicInOut, (v, c) => panel.TranslationY = 0, () => false);
                            break;
                    }
                }));
            }
            catch (Exception ex)
            {
                SendError(ex);
            }
        }

        public async Task HidePanel(Layout<View> layout, View panel, Side to)
        {
            try
            {
                switch (to)
                {
                    case Side.Left:
                        await panel.TranslateTo(-layout.Width, 0, 500, Easing.CubicInOut);
                        break;
                    case Side.Top:
                        await panel.TranslateTo(0, -layout.Height, 500, Easing.CubicInOut);
                        break;
                    case Side.Right:
                        await panel.TranslateTo(layout.Width, 0, 500, Easing.CubicInOut);
                        break;
                    case Side.Bottom:
                        await panel.TranslateTo(0, layout.Height, 500, Easing.CubicInOut);
                        break;
                }

                Device.BeginInvokeOnMainThread(() => layout.Children.Remove(panel));
            }
            catch (Exception ex)
            {
                SendError(ex);
            }
        }

        public async Task ShowPanelScaling(Layout<View> layout, View panel, Rectangle wholeSize = default(Rectangle))
        {

            if (wholeSize == default(Rectangle))
                wholeSize = layout.Bounds;

            panel.HeightRequest = wholeSize.Height;
            panel.WidthRequest = wholeSize.Width;
            AbsoluteLayout.SetLayoutBounds(panel, new Rectangle(0, 0, 1, 1));
            AbsoluteLayout.SetLayoutFlags(panel, AbsoluteLayoutFlags.All);
            panel.Scale = 0;

            try
            {
                Device.BeginInvokeOnMainThread(() => layout.Children.Add(panel));
                try { await panel.ScaleTo(1, 350, Easing.CubicOut); } catch { }
            }
            catch (Exception ex)
            {
                SendError(ex);
            }
        }




        public void PopUpFromTop(string message, Layout<View> layout)
        {

            try
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
                    Padding = new Thickness(15),
                    Opacity = 0,
                };
                pop.Content = text;
                pop.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => pop.CancelAnimation("PopUp")) });

                Device.BeginInvokeOnMainThread(() => layout.Children.Add(pop));

                var parentAnimation = new Animation();
                var fadeInAnimation = new Animation(v => pop.Opacity = v, 0, 1);
                var fadeOutAnimation = new Animation(v => pop.Opacity = v, 1, 0);
                pop.TranslationX = App.ScreenWidth / 3;
                var showFromTopAnimation = new Animation(v => { pop.TranslationY = v; }, layout.Y - 3, App.ScreenHeight * 0.25, Easing.CubicInOut);

                parentAnimation.Add(0, 0.5, fadeInAnimation);
                parentAnimation.Add(0, 1, showFromTopAnimation);
                parentAnimation.Add(0.8, 1, fadeOutAnimation);

                parentAnimation.Commit(pop, "PopUp", 16, 6000, null, (v, c) =>
                {
                    if (c) Device.BeginInvokeOnMainThread(() => layout.Children.Remove(pop));
                }, () => false);

            }
            catch (Exception ex)
            {
                SendError(ex);
            }
        }

        public void RotateView(View view, bool indefinite)
        {
            var animation = new Animation(callback: d => view.Rotation = d,
                                  start: view.Rotation,
                                  end: view.Rotation + 360);
            animation.Commit(view, "LoopRotation", length: 2000, easing: Easing.Linear, repeat: () => indefinite);
        }

        public void StopRotating(View view)
        {
            view.CancelAnimation("LoopRotation");
        }

        private void SendError(Exception ex)
        {
            MessagingCenter.Send<object, Exception>(this, "Error", ex);
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
            Device.BeginInvokeOnMainThread(() =>
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
            });

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
