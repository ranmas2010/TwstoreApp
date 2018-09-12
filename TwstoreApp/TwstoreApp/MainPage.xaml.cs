using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;
using System.Collections.ObjectModel;
using TwstoreApp.Services;
using TwstoreApp.Models;
using SQLite;
using System.IO;
using XFSQLite;


namespace TwstoreApp
{
    public partial class MainPage : ContentPage
    {
        DoggyDatabase fooDoggyDatabase = new DoggyDatabase();

        public MainPage()
        {
            InitializeComponent();

        }

        /// <summary>
        /// 取得列表
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        public async Task LoadJsonAsync(View v)
        {

            string html = await HttpService.GetWebContent("https://www.twstore.tw/app/app.php?func=getNews");
            List<MyRecord> data = JsonConvert.DeserializeObject<List<MyRecord>>(html);

            //SQLite操作
            fooDoggyDatabase.DeleteAll();
            //寫入資料庫
            foreach (var item in data)
            {
                fooDoggyDatabase.SaveItem(item);
            }

            ObservableCollection<MyRecord> trends = new ObservableCollection<MyRecord>(data);
            listView.ItemsSource = trends;

        }

        /// <summary>
        /// 點選詳細資料
        /// </summary>
        /// <param name="v"></param>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void ViewInfo(Button v, object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Views.Page2(int.Parse(v.ClassId.ToString())));
        }


    }
}
