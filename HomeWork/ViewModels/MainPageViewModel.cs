using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace HomeWork
{
    internal class MainPageViewModel
    {
        private const string url = "https://picsum.photos/v2/list?page=2&limit=15";
        private HttpClient _Client = new HttpClient();


        public async Task<ObservableCollection<Posts>> LoadPost()
        {
            var content = await _Client.GetStringAsync(url);
            var post = JsonConvert.DeserializeObject<List<Posts>>(content);
            return (new ObservableCollection<Posts>(post));
        }
    }
}
