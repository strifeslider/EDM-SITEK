using EDM_SITEK;
using System.Reflection.PortableExecutable;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
FIAS_API fiasapi = new FIAS_API();
DBMananger dbm = new DBMananger();

app.MapGet("/", () => "Hello World");
string FIAS_Url = "https://fias.nalog.ru/WebServices/Public/GetLastDownloadFileInfo";
await fiasapi.Delta_Data_Download();
await fiasapi.Unarcive();
await dbm.DB_Upload();
app.Run(async (context) =>
{
    using (DBMananger db = new DBMananger())
    {
        context.Response.ContentType = "text/html; charset=utf-8";


        var stringBuilder = new System.Text.StringBuilder("<h3>Отчет по Обновлениям/h3><table>");
        var obj = db.data.ToList();
        foreach(OBJECT objct in obj)
        {
           
                stringBuilder.Append($"<tr><td>{objct.TYPENAME}</td><td>{objct.NAME}</td></tr>");
           
        }
        stringBuilder.Append("</table>");


        await context.Response.WriteAsync(stringBuilder.ToString());
    }
});
