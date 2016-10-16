﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamtest.CustomViews;
using xamtest.Data;
using xamtest.Localization;

namespace xamtest.Pages
{
    public class RedbitPage : ContentPage
    {
        private RelativeLayout _layout;
        private StackLayout _panel;

        public RedbitPage()
        {
            // create the layout
            _layout = new RelativeLayout
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            
            CreateButton();
            CreatePanel();

            // set the content
            this.Content = _layout;
        }

        private void CreateButton()
        {
            
            // create the button
            _layout.Children.Add(
                new AnimatedButton("LangChoice", AnimatePanel)
                {
                    BackgroundColor = Color.Olive,
                    TextColor = Color.Black,
                    Padding = 20,
                },
                    Constraint.RelativeToParent((p) =>
                    {
                        return 5;
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        return 10;
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        return p.Width / 2 - 5;
                    }),

                    Constraint.RelativeToParent((p) =>
                    {
                        return p.Height / 6;
                    })
                );

            _layout.Children.Add(
                new xamtest.Models.MyButton()
                {
                    BackgroundColor = Color.Maroon,
                    TextColor = Color.Black,
                    TranslateKey = "ShowLoader",
                    Command = new Command(async () => 
                    {
                        //this.IsBusy = !this.IsBusy;
                        //if (this.IsBusy)
                            await App.AnimationsController.ShowLoader(_layout);
                        //else
                        //    await App.AnimationsController.HideLoader(_layout);
                    })
                },
                    Constraint.RelativeToParent((p) =>
                    {
                        return p.Width / 2 + 5;
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        return p.Height - p.Width / 4;
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        return p.Width / 2 - 15;
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        return p.Height / 6;
                    })
                );

            _layout.Children.Add(
                new xamtest.Models.Entry()
                {
                    BackgroundColor = Color.Red,
                    TextColor = Color.White,
                    TranslateKey = "FlyOutAnim"
                },
                    Constraint.RelativeToParent((p) =>
                    {
                        return 10;
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        return p.Height / 2;
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        return p.Width / 2;
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        return p.Height / 6;
                    })
                );
            _layout.Children.Add(
                new xamtest.Models.Label()
                {
                    TextColor = Color.Black,
                    TranslateKey = "hi"
                },
                    Constraint.RelativeToParent((p) =>
                    {
                        return p.Width / 2;
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        return p.Height / 2;
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        return 50;
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        return 30;
                    })
                );
        }

        private double _panelWidth = -1;
        /// <summary>
        /// Creates the right side menu panel
        /// </summary>
        private void CreatePanel()
        {
            if (_panel == null)
            {
                _panel = new StackLayout
                {
                    Children = {
                        new Label {
                            Text = "Options",
                            HorizontalOptions = LayoutOptions.Start,
                            VerticalOptions = LayoutOptions.Start,
                            HorizontalTextAlignment = TextAlignment.Center,
                            TextColor = Color.White
                        },
                        new AnimatedButton ("English", () => {
                            AnimatePanel();
                            //ChangeBackgroundColorReddish();
                            App.LanguageController.SetCurrentCulture(0);
                        }, "flag_en.png"),
                        new AnimatedButton ("Deutsch", () => {
                            AnimatePanel();
                            //ChangeBackgroundColorBlueish();
                            App.LanguageController.SetCurrentCulture(1);
                        }, "flag_de.png"),
                        new AnimatedButton ("Български", () => {
                            AnimatePanel();
                            //ChangeBackgroundColorGreenish();
                            App.LanguageController.SetCurrentCulture(2);
                        }, "flag_bg.png"),
                        new AnimatedButton ("Black to White Anim", () => {
                            AnimatePanel();
                            ChangeBackgroundColor();
                        }),
                    },
                    Padding = 15,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.EndAndExpand,
                    BackgroundColor = Color.FromRgba(0, 0, 0, 180)
                };

                // add to layout
                _layout.Children.Add(_panel,
                    Constraint.RelativeToParent((p) =>
                    {
                        return _layout.Width - (this.PanelShowing ? _panelWidth : 0);
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        return 0;
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        if (_panelWidth == -1)
                            _panelWidth = p.Width / 3;
                        return _panelWidth;
                    }),
                    Constraint.RelativeToParent((p) =>
                    {
                        return p.Height;
                    })
                );
            }
        }

        private bool _PanelShowing = false;
        /// <summary>
        /// Gets a value to determine if the panel is showing or not
        /// </summary>
        /// <value><c>true</c> if panel showing; otherwise, <c>false</c>.</value>
        private bool PanelShowing
        {
            get
            {
                return _PanelShowing;
            }
            set
            {
                _PanelShowing = value;
            }
        }

        /// <summary>
        /// Animates the panel in our out depending on the state
        /// </summary>
        private async void AnimatePanel()
        {

            // swap the state
            this.PanelShowing = !PanelShowing;

            // show or hide the panel
            if (this.PanelShowing)
            {
                // hide all children
                foreach (var child in _panel.Children)
                {
                    child.Scale = 0;
                }

                // layout the panel to slide out
                var rect = new Rectangle(_layout.Width - _panel.Width, _panel.Y, _panel.Width, _panel.Height);
                await this._panel.LayoutTo(rect, 500, Easing.CubicIn);

                // scale in the children for the panel
                foreach (var child in _panel.Children)
                {
                    await child.ScaleTo(1.3, 50, Easing.CubicIn);
                    await child.ScaleTo(1, 50, Easing.CubicOut);
                }
            }
            else
            {

                // layout the panel to slide in
                var rect = new Rectangle(_layout.Width, _panel.Y, _panel.Width, _panel.Height);
                await this._panel.LayoutTo(rect, 500, Easing.CubicOut);

                // hide all children
                foreach (var child in _panel.Children)
                {
                    child.Scale = 0;
                }
            }
        }

        /// <summary>
        /// Changes the background color of the relative layout
        /// </summary>
        private void ChangeBackgroundColor()
        {
            var repeatCount = 0;
            this._layout.Animate(
                // set the name of the animation
                name: "changeBG",

                // create the animation object and callback
                animation: new Xamarin.Forms.Animation((val) =>
                {
                    // val will be a value from 0 - 1 and uses that to set the BG color
                    if (repeatCount == 0)
                        this._layout.BackgroundColor = Color.FromRgb(1 - val, 1 - val, 1 - val);
                    else
                        this._layout.BackgroundColor = Color.FromRgb(val, val, val);
                }),

                // set the length
                length: 750,

                // set the repeat action to update the repeatCount
                finished: (val, b) =>
                {
                    repeatCount++;
                },

                // determine if we should repeat
                repeat: () =>
                {
                    return repeatCount < 1;
                }
            );
        }

        private void ChangeBackgroundColorReddish()
        {
            var repeatCount = 0;
            this._layout.Animate(
                // set the name of the animation
                name: "changeBGRedTransition",

                // create the animation object and callback
                animation: new Xamarin.Forms.Animation((val) =>
                {
                    // val will be a value from 0 - 1 and uses that to set the BG color
                    if (repeatCount == 0)
                        this._layout.BackgroundColor = Color.FromRgb(val, 1 - val, 1 - val);
                    else
                        this._layout.BackgroundColor = Color.FromRgb(val, val, val);
                }),

                // set the length
                length: 750,

                // set the repeat action to update the repeatCount
                finished: (val, b) =>
                {
                    repeatCount++;
                },

                // determine if we should repeat
                repeat: () =>
                {
                    return repeatCount < 1;
                }
            );
        }

        private void ChangeBackgroundColorGreenish()
        {
            var repeatCount = 0;
            this._layout.Animate(
                // set the name of the animation
                name: "changeBGGreenTransition",

                // create the animation object and callback
                animation: new Xamarin.Forms.Animation((val) =>
                {
                    // val will be a value from 0 - 1 and uses that to set the BG color
                    if (repeatCount == 0)
                        this._layout.BackgroundColor = Color.FromRgb(1 - val, val, 1 - val);
                    else
                        this._layout.BackgroundColor = Color.FromRgb(val, val, val);
                }),

                // set the length
                length: 750,

                // set the repeat action to update the repeatCount
                finished: (val, b) =>
                {
                    repeatCount++;
                },

                // determine if we should repeat
                repeat: () =>
                {
                    return repeatCount < 1;
                }
            );
        }

        private void ChangeBackgroundColorBlueish()
        {
            var repeatCount = 0;
            this._layout.Animate(
                // set the name of the animation
                name: "changeBGBlueTransition",

                // create the animation object and callback
                animation: new Xamarin.Forms.Animation((val) =>
                {
                    // val will be a value from 0 - 1 and uses that to set the BG color
                    if (repeatCount == 0)
                        this._layout.BackgroundColor = Color.FromRgb(1 - val, 1 - val, val);
                    else
                        this._layout.BackgroundColor = Color.FromRgb(val, val, val);
                }),

                // set the length
                length: 750,

                // set the repeat action to update the repeatCount
                finished: (val, b) =>
                {
                    repeatCount++;
                },

                // determine if we should repeat
                repeat: () =>
                {
                    return repeatCount < 1;
                }
            );
        }
    }
}
