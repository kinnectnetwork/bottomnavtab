using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using App2.Controls;
using App2.Models;

namespace App2
{
    public partial class MainPage : ContentPage
    {
        private uint currentTab;

        public MainPage()
        {
            InitializeComponent();

            //Enable Tab1
            var page = new Page1();
            PlaceHolder.Content = page.Content;
            currentTab = 1;

            //Ensure Tab 2 to 4 is disabled
            for(int count = 2; count <=4 ;count++)
            {
                IconView obj = (IconView)this.FindByName<IconView>("Icon" + count.ToString());
                obj.IconLabel_OnDisappearing(0, 0);
            }
        }

        private void Icon_IconTapped(object sender, EventArgs e)
        {
            //Can use Bindable context + event but this will do for now..
            //google dynamically-changing-xamarin-forms-tab-icons-when-select/

            //disable previous tab
            IconView prev_obj = this.FindByName<IconView>("Icon" + currentTab.ToString()) as IconView;
            prev_obj.IconLabel_OnDisappearing(0, 0);

            //enable tab and save new setting
            IconView curr_obj = (IconView)sender;
            curr_obj.IconLabel_OnAppearing(1, 100);
            SearchResultLogic.GetData();

            var searchresults = SearchResultLogic.GetSearchResults();
            
            //Set position
            currentTab = Convert.ToUInt16(curr_obj.IconPosition);

            //Go to new page
            var page = new Page1();
            PlaceHolder.Content = page.Content;
        }
    }

    [ContentProperty(nameof(Source))]
    public class ImageResourceExtension : IMarkupExtension
    {
        public string Source { get; set; }

        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (Source == null)
            {
                return null;
            }

            // Do your translation lookup here, using whatever method you require
            var imageSource = ImageSource.FromResource(Source);

            return imageSource;
        }
    }
}