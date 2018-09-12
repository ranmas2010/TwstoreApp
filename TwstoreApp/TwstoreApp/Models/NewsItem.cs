using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TwstoreApp.Models
{
	public class NewsItem : ContentView
    {
		public string id { get; set; } // or whatever
        public string title { get; set; } // or whatever
        public string description { get; set; } // or whatever

        public string image { get; set; } // or whatever

        public string notes { get; set; } // or whatever
    }
}