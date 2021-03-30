using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinFormsPushDemo.Controllers
{
    public class CustomButton : Button
    {
        public CustomButton()
        {
            CornerRadius = 8;
            TextColor = Color.Black;
            BackgroundColor = Xamarin.Essentials.ColorConverters.FromHex("#d9d9d9");
            FontSize = 12;
            //TextTransform = TextTransform.None;
        }
    }
}
