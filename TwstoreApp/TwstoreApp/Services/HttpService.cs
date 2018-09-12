using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TwstoreApp.Services
{
	public class HttpService : ContentView
	{
        /// <summary>
        /// 非同步讀取JSON資料
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static async Task<String> GetWebContent(string url)
        {
            var httpClient = new HttpClient();
            return await httpClient.GetStringAsync(url);
        }

    }
}