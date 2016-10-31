using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using xamtest.Data;
using xamtest.Extensions;

namespace xamtest.Pages
{
    public partial class ShowItemFromBelow : BasePage
    {
        public ShowItemFromBelow()
        {
            InitializeComponent();

            ShowUpFromBottom.Clicked += async (s, e) => await ShowPanelFromBelow();
            ShowDownFromTop.Clicked += async (s, e) => await ShowPanelFromAbove();
            ShowUpFromLeft.Clicked += async (s, e) => await ShowPanelFromLeft(.8f);

            //ShowUpFromBottom.Clicked += async (s, e) => await App.AnimationsController.ShowPanel(layout, PanelDown, Side.Bottom);
            //ShowDownFromTop.Clicked += async (s, e) => await App.AnimationsController.ShowPanel(layout, PanelUp, Side.Top);
            //ShowUpFromLeft.Clicked += async (s, e) => await App.AnimationsController.ShowPanel(layout, PanelLeft, Side.Left);
            PanelLeftContent.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(async () => await HidePanelLeft()) });
            var rightStack = new StackLayout { Children = { new Label { Text = "Right Panel", TextColor = Color.Purple, FontSize = 40 } }, VerticalOptions = LayoutOptions.CenterAndExpand, HorizontalOptions = LayoutOptions.CenterAndExpand, BackgroundColor = Color.FromRgba(0, 0, 0, 0.5) };
            ShowUpFromRight.Clicked += async (s, e) => await App.AnimationsController.ShowPanel(layout, rightStack, Side.Right);


            PanelDown.BackgroundColor = Color.FromRgba(0, 0, 0, 0.2);
            PanelUp.BackgroundColor = Color.FromRgba(0, 0, 0, 0.2);
            PanelLeft.BackgroundColor = Color.FromRgba(0, 0, 0, 0.3);
            
            Content.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(async () => await PopUpFromTop("Pop...!")) });
        }

        public bool PanelDownShowing { get; set; }

        public bool PanelUpShowing { get; set; }

        private async Task ShowPanelFromBelow()
        {
            PanelDownShowing = !PanelDownShowing;

            if (PanelDownShowing)
            {
                Rectangle showPosition = new Rectangle(0, layout.Height / 5, PanelDown.Width, PanelDown.Height);
                await PanelDown.LayoutTo(showPosition, 500, Easing.CubicOut);
                layout.SetBounds(PanelDown);
            }
            else
            {
                Rectangle hidePosition = new Rectangle(0, layout.Height + 50, PanelDown.Width, PanelDown.Height);
                await PanelDown.LayoutTo(hidePosition, 500, Easing.CubicIn);
                layout.SetBounds(PanelDown);
            }
        }

        private async Task ShowPanelFromAbove()
        {
            PanelUpShowing = !PanelUpShowing;

            if (PanelUpShowing)
            {
                Rectangle showPosition = new Rectangle(0, layout.Height / 8, PanelUp.Width, PanelUp.Height);
                await PanelUp.LayoutTo(showPosition, 500, Easing.CubicOut);
                layout.SetBounds(PanelUp);
            }
            else
            {
                Rectangle hidePosition = new Rectangle(0, layout.Height * -1, PanelUp.Width, PanelUp.Height);
                await PanelUp.LayoutTo(hidePosition, 500, Easing.CubicIn);
                layout.SetBounds(PanelUp);
            }
        }


        private async Task ShowPanelFromLeft(float screenCover = 1f)
        {
            Rectangle showPosition = new Rectangle(layout.X, layout.Y, layout.Width * screenCover, layout.Height);
            await PanelLeft.LayoutTo(showPosition, 500, Easing.CubicOut);
            layout.SetBounds(PanelLeft);
            
        }

        private async Task HidePanelLeft()
        {
            Rectangle hidePosition = new Rectangle(layout.Width * -1, PanelLeft.Y, PanelLeft.Width, PanelLeft.Height);
            await PanelLeft.LayoutTo(hidePosition, 500, Easing.CubicIn);
            layout.SetBounds(PanelLeft);
        }

        private async Task PopUpFromTop(string txt)
        {

            Label text = new Label
            {
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Text = txt,
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

            await pop.FadeTo(0, 1500, Easing.CubicIn);
            layout.Children.Remove(pop);
        }


    }
}
