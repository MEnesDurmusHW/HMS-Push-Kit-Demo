using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinFormsPushDemo.Controllers
{
    public class CustomLabel : Label
    {
        public CustomLabel()
        {
            TextColor = Color.Black; 
            VerticalOptions = LayoutOptions.Center; 
            FontAttributes = FontAttributes.Bold;
        }
    }
}
