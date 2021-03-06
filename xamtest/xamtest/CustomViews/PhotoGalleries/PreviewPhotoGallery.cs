﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xamtest.CustomViews.PhotoGalleries
{
    class PreviewPhotoGallery : ScrollView
    {
        readonly StackLayout _imageStack;

        public PreviewPhotoGallery()
        {
            this.Orientation = ScrollOrientation.Horizontal;

            _imageStack = new StackLayout
            {
                Orientation = StackOrientation.Horizontal
            };

            this.Content = _imageStack;
        }

        public IList<View> Children
        {
            get
            {
                return _imageStack.Children;
            }
        }

        public static readonly BindableProperty ItemsSourceProperty = BindableProperty.Create(nameof(ItemsSource), typeof(IList), typeof(PreviewPhotoGallery), default(IList), BindingMode.TwoWay,
        propertyChanging: (bindableObject, oldValue, newValue) =>
        {
            ((PreviewPhotoGallery)bindableObject).ItemsSourceChanging();
        },
        propertyChanged: (bindableObject, oldValue, newValue) =>
        {
            ((PreviewPhotoGallery)bindableObject).ItemsSourceChanged(bindableObject, (IList)oldValue, (IList)newValue);
        });

        public IList ItemsSource
        {
            get
            {
                return (IList)GetValue(ItemsSourceProperty);
            }
            set
            {
                SetValue(ItemsSourceProperty, value);
            }
        }

        void ItemsSourceChanging()
        {
            if (ItemsSource == null)
                return;
        }

        void ItemsSourceChanged(BindableObject bindable, IList oldValue, IList newValue)
        {
            if (ItemsSource == null)
                return;

            var notifyCollection = newValue as INotifyCollectionChanged;
            if (notifyCollection != null)
            {
                notifyCollection.CollectionChanged += (sender, args) => {
                    if (args.NewItems != null)
                    {
                        foreach (var newItem in args.NewItems)
                        {

                            var view = (View)ItemTemplate.CreateContent();
                            var bindableObject = view as BindableObject;
                            if (bindableObject != null)
                                bindableObject.BindingContext = newItem;
                            _imageStack.Children.Add(view);
                        }
                    }
                    if (args.OldItems != null)
                    {
                        // not supported
                        _imageStack.Children.RemoveAt(args.OldStartingIndex);
                    }
                };
            }

            //			_imageStack.Children.Clear ();
            //			foreach (var item in ItemsSource) {
            //				var view = (View)ItemTemplate.CreateContent ();
            //				var bindableObject = view as BindableObject;
            //				if (bindableObject != null)
            //					bindableObject.BindingContext = item;
            //				_imageStack.Children.Add (view);
            //			}				
        }

        public DataTemplate ItemTemplate
        {
            get;
            set;
        }

        public static readonly BindableProperty SelectedItemProperty =
            BindableProperty.Create(nameof(SelectedItem), typeof(object), typeof(PreviewPhotoGallery), null, BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) => {
                    ((PreviewPhotoGallery)bindable).UpdateSelectedIndex();
                }
            );

        public object SelectedItem
        {
            get
            {
                return GetValue(SelectedItemProperty);
            }
            set
            {
                SetValue(SelectedItemProperty, value);
            }
        }

        void UpdateSelectedIndex()
        {
            if (SelectedItem == BindingContext)
                return;

            SelectedIndex = Children
                .Select(c => c.BindingContext)
                .ToList()
                .IndexOf(SelectedItem);
        }

        public static readonly BindableProperty SelectedIndexProperty =
            BindableProperty.Create(nameof(SelectedIndex), typeof(int), typeof(PreviewPhotoGallery), default(int), BindingMode.TwoWay,
                propertyChanged: (bindable, oldValue, newValue) => {
                    ((PreviewPhotoGallery)bindable).UpdateSelectedItem();
                }
            );

        public int SelectedIndex
        {
            get
            {
                return (int)GetValue(SelectedIndexProperty);
            }
            set
            {
                SetValue(SelectedIndexProperty, value);
            }
        }

        void UpdateSelectedItem()
        {
            SelectedItem = SelectedIndex > -1 ? Children[SelectedIndex].BindingContext : null;
        }
    }
}
