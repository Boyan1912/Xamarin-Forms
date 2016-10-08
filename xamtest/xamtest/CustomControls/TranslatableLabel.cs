using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace xamtest.CustomControls
{
    public class TranslatableLabel : Label
    {
        public TranslatableLabel()
        {

        }

        public string TranslateKey { get; set; }
    }
}
