using EDM_SITEK;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
FIAS_API fiasapi = new FIAS_API();
DBMananger dbm = new DBMananger();

app.MapGet("/", () => "Hello World");
string FIAS_Url = "https://fias.nalog.ru/WebServices/Public/GetLastDownloadFileInfo";
await fiasapi.Delta_Data_Download();
await fiasapi.Unarcive();
await dbm.DB_Upload();
app.Run(
    );
