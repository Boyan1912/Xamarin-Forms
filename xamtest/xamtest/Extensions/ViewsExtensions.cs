using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xamtest.Extensions
{
    public static class ViewsExtensions
    {

        public static void SetBounds(this RelativeLayout layout, View element)
        {
            layout.Children.Add(element, Constraint.Constant(element.X),
                    Constraint.Constant(element.Y),
                    Constraint.Constant(element.Width),
                    Constraint.Constant(element.Height));
        }
    }
}
