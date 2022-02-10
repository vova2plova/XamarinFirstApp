using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace HomeWork
{
    public class Posts
    {
        public string id { get; set; }
        public string author { get; set; }
        public int width { get; set; }
        public ImageSource image { get; set; }
        public int height { get; set; }
        public string url { get; set; }
        public string download_url { get; set; }
    }
}