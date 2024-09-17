using Newtonsoft.Json;
using System.IO.Compression;
using System.Net;

namespace EDM_SITEK
{
    public class FIAS_API
    {



        HttpClient httpClient = new HttpClient();
        WebClient webClient = new WebClient();
        string FIAS_Url = "https://fias.nalog.ru/WebServices/Public/GetLastDownloadFileInfo";
        string Tmp_Dir = "Tmp_Dir/";
        public async Task<FIAS_Url_Data> API_Call()
        {
            HttpResponseMessage response = (await httpClient.GetAsync(FIAS_Url)).EnsureSuccessStatusCode();
            var ResponseBody = await response.Content.ReadAsStringAsync();
            FIAS_Url_Data data = JsonConvert.DeserializeObject<FIAS_Url_Data>(ResponseBody);
            
            return data;
        }
        public async Task Delta_Data_Download()
        {

            FIAS_Url_Data data = await API_Call();
            DirectoryInfo dirInfo = new DirectoryInfo(Tmp_Dir);
            if(!Directory.Exists(data.Date + "/"))
            {
                dirInfo.CreateSubdirectory(data.Date + "/");
                webClient.DownloadFile(data.GarXMLDeltaURL, Tmp_Dir + data.Date + "/arcive.zip");
            }

        }
        public async Task Unarcive()
        {
            FIAS_Url_Data data = await API_Call();
            string dirpath = Tmp_Dir + data.Date + "/01";
            string[] pattern = Array.Empty<string>(); 
            if (Directory.Exists(dirpath) == false)
            {
                ZipFile.ExtractToDirectory(Tmp_Dir + data.Date + "/arcive.zip", Tmp_Dir + data.Date + "/");
            }
        }
    }
}
