using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace xamtest.Models
{
    public class AnimationSettingsVM
    {
        const int MAX_COLOR_VALUE = 255;
        private int redValue = 1;
        private int greenValue = 1;
        private int blueValue = 1;

        public AnimationSettingsVM()
        {
            
        }

        public int RedValue { get { return redValue / MAX_COLOR_VALUE; } set { redValue = value; } }

        public int GreenValue { get { return greenValue / MAX_COLOR_VALUE; } set { greenValue = value; } }

        public int BlueValue { get { return blueValue / MAX_COLOR_VALUE; } set { blueValue = value; } }

        public Color MajorColor { get { return Color.FromRgb(redValue, greenValue, blueValue); } set { this.MajorColor = value; } }
    }
}
