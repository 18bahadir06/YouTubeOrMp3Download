using BusinessLayer.Abstarct;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DataAccessLayer;
using System.Net.Http;
using Newtonsoft.Json;

namespace BusinessLayer.Concrete
{
    public class YoutubeManager : IYoutubeService
    {
        FileRepository _fileRepository;
        private FileRepository fileRepository;
        private readonly string apiUrl = "http://localhost:5000/download"; // Mikroservisin URL'si

        public YoutubeManager(FileRepository fileRepository, string apiUrl)
        {
            _fileRepository = fileRepository;
            this.apiUrl = apiUrl;
        }

        public YoutubeManager(FileRepository fileRepository)
        {
            this.fileRepository = fileRepository;
        }

        public async Task<string> ConvertYoutubeToMp3(string youtubeUrl)
        {
            using (HttpClient client = new HttpClient())
            {
                var requestData = new { url = youtubeUrl };
                var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

                var response = await client.PostAsync(apiUrl, content);
                response.EnsureSuccessStatusCode();

                string result = await response.Content.ReadAsStringAsync();
                return result; // API'nin döndüğü yanıt
            }
        }
    }
}
