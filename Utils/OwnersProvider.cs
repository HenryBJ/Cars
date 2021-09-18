using System.Collections.Generic;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Cars.Models;

namespace Cars.Utils
{
    public class OwnersProvider
    {
        private List<OwnerModel> _list =new List<OwnerModel>();
        private const string URL = "https://reqres.in/api/users?page={0}";
        private readonly int NUMBER_PAGES = 3;

        public IEnumerable<OwnerModel> Owners 
        { 
            get
            {
                if(_list.Count == 0) LoadData().Wait();
                return _list.ToArray();
            }
        }

        private async Task LoadData()
        {
            using (HttpClient _client = new HttpClient())
            {
                for (int i = 1; i < NUMBER_PAGES + 1; i++)
                {
                    var pageString = await _client.GetStringAsync(string.Format(URL,i));
                    var page = JsonConvert.DeserializeObject<PageModel>(pageString);  
                    _list.AddRange(page.Data);                  
                }
            }            
        }

    }
}