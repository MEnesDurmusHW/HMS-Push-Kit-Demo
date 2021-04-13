using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinFormsPushDemo.Controllers
{
    public class CustomFrame : Frame
    {
        public CustomFrame()
        {
            CornerRadius = 8;
            Padding = new Thickness(0);
            Margin = new Thickness(1);
        }
    }
}
