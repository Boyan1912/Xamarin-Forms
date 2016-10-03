using System;
using System.ComponentModel;

using Xamarin.Forms;

namespace xamtest.Models
{
    public class AnimSetViewModel : INotifyPropertyChanged
    {
        private double redValue, greenValue, blueValue, opacityLevel;
        private Color majorColor;
        
        public event PropertyChangedEventHandler PropertyChanged;

        public AnimSetViewModel()
        {
            OpacityLevel = .5;
            SetNewColor();
        }

        public double RedValue
        {
            set
            {
                if (redValue != value)
                {
                    redValue = value;
                    OnPropertyChanged("RedValue");
                    SetNewColor();
                }
            }   
            get
            {
                return redValue;
            }
        }


        public double GreenValue
        {
            set
            {
                if (greenValue != value)
                {
                    greenValue = value;
                    OnPropertyChanged("GreenValue");
                    SetNewColor();
                }
            }

            get
            {
                return greenValue;
            }
        }

        public double BlueValue
        {
            set
            {
                if (blueValue != value)
                {
                    blueValue = value;
                    OnPropertyChanged("BlueValue");
                    SetNewColor();
                }
            }
            get
            {
                return blueValue;
            }
        }

        public double OpacityLevel
        {
            set
            {
                if (opacityLevel != value)
                {
                    opacityLevel = value;
                    OnPropertyChanged("OpacityLevel");
                    SetNewColor();
                }
            }
            get
            {
                return opacityLevel;
            }
        }

        public Color MajorColor
        {

            set
            {
                if (majorColor != value)
                {
                    majorColor = value;
                    OnPropertyChanged("MajorColor");

                    this.RedValue = value.R;
                    this.GreenValue = value.G;
                    this.BlueValue = value.B;
                    this.OpacityLevel = value.A;
                }
            }
            get
            {
                return majorColor;
            }
        }

        void SetNewColor()
        {
            this.MajorColor = Color.FromRgba(this.RedValue,
                                        this.GreenValue,
                                        this.BlueValue,
                                        this.OpacityLevel);
        }
        
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
