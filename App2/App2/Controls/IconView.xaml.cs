using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App2.Controls
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class IconView : ContentView
	{
        public event EventHandler IconTapped;

        #region  IconPosition
        public static readonly BindableProperty IconPositionProperty = BindableProperty.Create(
                                                                                    propertyName: "IconPosition",
                                                                                    returnType: typeof(string),
                                                                                    declaringType: typeof(IconView),
                                                                                    defaultBindingMode: BindingMode.TwoWay,
                                                                                    propertyChanged: IconPositionPropertyChanged);

        public string IconPosition
        {
            get { return GetValue(IconPositionProperty).ToString(); }
            set { SetValue(IconPositionProperty, value); }
        }

        private static void IconPositionPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
        }
        #endregion

        #region  ImageSource
        public static readonly BindableProperty ImageSourceProperty = BindableProperty.Create(
                                                                                    propertyName: "ImageSource",
                                                                                    returnType: typeof(string),
                                                                                    declaringType: typeof(IconView),
                                                                                    defaultBindingMode: BindingMode.TwoWay,
                                                                                    propertyChanged: ImageSourcePropertyChanged);

        public string ImageSource
        {
            get { return GetValue(ImageSourceProperty).ToString(); }
            set { SetValue(ImageSourceProperty, value); }
        }

        private static void ImageSourcePropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (IconView)bindable;
            control.IconImage.Source = newValue.ToString();
        }
        #endregion

        #region  ImageHexColor
        public static readonly BindableProperty ImageHexColorProperty = BindableProperty.Create(
                                                                            propertyName: "ImageHexColor",
                                                                            returnType: typeof(string),
                                                                            declaringType: typeof(IconView),
                                                                            defaultBindingMode: BindingMode.TwoWay,
                                                                            propertyChanged: ImageHexColorPropertyChanged);

        public string ImageHexColor
        {
            get { return GetValue(ImageHexColorProperty).ToString(); }
            set { SetValue(ImageHexColorProperty, value); }
        }

        private static void ImageHexColorPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (IconView)bindable;
            control.IconTint.HexColor = newValue.ToString();
        }
        #endregion

        #region  ImageWidthRequest
        public static readonly BindableProperty ImageWidthRequestProperty = BindableProperty.Create(
                                                                            propertyName: "ImageWidthRequest",
                                                                            returnType: typeof(string),
                                                                            declaringType: typeof(IconView),
                                                                            defaultBindingMode: BindingMode.TwoWay,
                                                                            propertyChanged: ImageWidthRequestPropertyChanged);

        public string ImageWidthRequest
        {
            get { return GetValue(ImageWidthRequestProperty).ToString(); }
            set { SetValue(ImageWidthRequestProperty, value); }
        }

        private static void ImageWidthRequestPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (IconView)bindable;
            control.IconImage.WidthRequest = Convert.ToDouble(newValue);
        }
        #endregion

        #region  LabelText
        public static readonly BindableProperty LabelTextProperty = BindableProperty.Create(
                                                                            propertyName: "LabelText",
                                                                            returnType: typeof(string),
                                                                            declaringType: typeof(IconView),
                                                                            defaultBindingMode: BindingMode.TwoWay,
                                                                            propertyChanged: LabelTextPropertyChanged);

        public string LabelText
        {
            get { return GetValue(LabelTextProperty).ToString(); }
            set { SetValue(LabelTextProperty, value); }
        }

        private static void LabelTextPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (IconView)bindable;
            control.IconLabel.Text = newValue.ToString();
        }
        #endregion

        public IconView ()
		{
			InitializeComponent ();
		}

        public void IconLabel_OnAppearing(double scale, uint millisecond)
        {
            IconImage.TranslateTo(0, -1, millisecond, Easing.BounceIn);
            IconLabel.ScaleTo(scale, millisecond, Easing.BounceIn);
            //Label obj = (Label)this.FindByName<Label>(myclass);
            //obj.ScaleTo(scale, millisecond, Easing.BounceIn);
        }

        public void IconLabel_OnDisappearing(double scale, uint millisecond)
        {
            IconImage.TranslateTo(0, +4, millisecond, Easing.BounceIn);
            IconLabel.ScaleTo(scale, millisecond, Easing.BounceIn);
            //Label obj = (Label)this.FindByName<Label>(myclass);
            //obj.ScaleTo(scale, millisecond, Easing.BounceIn);
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            if (IconTapped != null)
            {
                IconTapped(this, EventArgs.Empty);
            }
        }
    }
}