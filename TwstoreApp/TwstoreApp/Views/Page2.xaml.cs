using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TwstoreApp.Services;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using TwstoreApp.Models;
using XFSQLite;

namespace TwstoreApp.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class Page2 : ContentPage
	{
        DoggyDatabase fooDoggyDatabase = new DoggyDatabase();

        /// <summary>
        /// 內頁顯示
        /// </summary>
        /// <param name="data"></param>
        public Page2(int fromID)
		{
			InitializeComponent();

            //取得資料庫資料
            MyRecord data = fooDoggyDatabase.GetItemFromID(fromID);
            NewsImage.Source = data.image.ToString();
            NewsTitle.Text = data.title.ToString();
            NewsDescription.Text = data.description.ToString();
          
        }

        /// <summary>
        /// 返回上一頁
        /// </summary>
        /// <param name="v"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void BackToList(Button v, object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}