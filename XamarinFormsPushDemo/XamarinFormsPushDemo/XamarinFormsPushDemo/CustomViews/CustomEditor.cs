using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XamarinFormsPushDemo.Controllers
{
    public class CustomEditor : Editor
    {
        public CustomEditor()
        {
            BackgroundColor = Color.White;
            TextColor = Color.Black;
            HorizontalOptions = LayoutOptions.Center;
            AutoSize = EditorAutoSizeOption.TextChanges;
            Margin = new Thickness(-4);
        }
    }
}
