using Newtonsoft.Json;
using System;
using System.Net;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EDM_SITEK
{
    public class FIAS_API
    {
        static string FIAS_Url = "https://fias.nalog.ru/WebServices/Public/GetLastDownloadFileInfo";
        string Tmp_Dir = "//Tmp_Dir//";

        static HttpClient httpClient = new  HttpClient();
        public async Task<FIAS_Url_Data> API_Call() {
            HttpResponseMessage response = (await httpClient.GetAsync(FIAS_Url)).EnsureSuccessStatusCode();
            var ResponseBody = await response.Content.ReadAsStringAsync();
            FIAS_Url_Data data = JsonConvert.DeserializeObject<FIAS_Url_Data>(ResponseBody);
            return data;
        }
    }
}
