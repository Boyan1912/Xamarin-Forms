using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using xamtest.Localization;

namespace xamtest.Data
{
    public class LanguageController : INotifyPropertyChanged
    {
        private int selectedCultureId;

        public LanguageController()
        {
            AvailableCultures = new List<AppCulture>
            {
                new AppCulture(0, "en-US"),
                new AppCulture(1, "de-DE"),
                new AppCulture(2, "bg-BG")
            };

            var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
            var availableCult = AvailableCultures.FirstOrDefault(x => x.Culture == ci);
            if (availableCult != null)
                SelectedCultureId = availableCult.Id;
            else
                SetCurrentCulture(ci);
        }
        
        public event PropertyChangedEventHandler PropertyChanged;

        public List<AppCulture> AvailableCultures { get; set; }

        public int SelectedCultureId
        {
            get { return selectedCultureId; }
            set
            {
                if (selectedCultureId != value)
                {
                    selectedCultureId = value;
                    OnPropertyChanged("SelectedCultureId");
                    OnPropertyChanged("SelectedCulture");
                    SetCurrentCulture(SelectedCulture.Culture);
                }
            }
        }

        public AppCulture SelectedCulture
        {
            get { return AvailableCultures[SelectedCultureId]; }
        }

        public void SetCurrentCulture(CultureInfo ci = null)
        {
            // Localization:
            if (Device.OS == TargetPlatform.iOS || Device.OS == TargetPlatform.Android || Device.OS == TargetPlatform.WinPhone)
            {
                Translations.Culture = ci; // set the RESX for resource localization
                DependencyService.Get<ILocalize>().SetLocale(ci); // set the Thread for locale-aware methods
            }
        }

        public void SetCurrentCulture(int id = 0)
        {
            if (id > -1 && id < AvailableCultures.Count)
            {
                this.SelectedCultureId = id;
            }
        }

        protected virtual void OnPropertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        
    }
    
    public class AppCulture
    {
        public AppCulture(int id, string codeName)
        {
            Id = id;
            Culture = new CultureInfo(codeName);
            ImageSrc = "flag_" + Culture.TwoLetterISOLanguageName.ToLower() + ".png";
        }

        public int Id { get; set; }
        
        public CultureInfo Culture { get; set; }

        public string ImageSrc { get; set; }
    }
}
