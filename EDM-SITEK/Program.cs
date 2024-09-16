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


        var stringBuilder = new System.Text.StringBuilder("<h3>Отчет по Обновлениям Субьектов РФ</h3><table>");
        List<OBJECT> obj = db.data.ToList();
        foreach(OBJECT objct in obj)
        {
            if (objct.LEVEL == 1)
            {
                stringBuilder.Append($"<tr><td>{objct.TYPENAME}</td><td>{objct.NAME}</td></tr>");
                obj.Remove(objct);
            }
        }
        stringBuilder.Append("</table>");

        stringBuilder.Append('\n');
        stringBuilder.Append("<h3>Отчет по Обновлениям Административных районов</h3><table>");
        foreach (OBJECT objct in obj)
        {
            if (objct.LEVEL == 2)
            {
                stringBuilder.Append($"<tr><td>{objct.TYPENAME}</td><td>{objct.NAME}</td></tr>");
                obj.Remove(objct);
            }
        }
        stringBuilder.Append("</table>");

        stringBuilder.Append('\n');
        stringBuilder.Append("<h3>Отчет по Обновлениям Муниципальных районов</h3><table>");
        foreach (OBJECT objct in obj)
        {
            if (objct.LEVEL == 3)
            {
                stringBuilder.Append($"<tr><td>{objct.TYPENAME}</td><td>{objct.NAME}</td></tr>");
                obj.Remove(objct);
            }
        }
        stringBuilder.Append("</table>");

        stringBuilder.Append('\n');
        stringBuilder.Append("<h3>Отчет по Обновлениям Сельских/Городских поселений</h3><table>");
        foreach (OBJECT objct in obj)
        {
            if (objct.LEVEL == 4)
            {
                stringBuilder.Append($"<tr><td>{objct.TYPENAME}</td><td>{objct.NAME}</td></tr>");
                obj.Remove(objct);
            }
        }
        stringBuilder.Append("</table>");

        stringBuilder.Append('\n');
        stringBuilder.Append("<h3>Отчет по Обновлениям Городов</h3><table>");
        foreach (OBJECT objct in obj)
        {
            if (objct.LEVEL == 5)
            {
                stringBuilder.Append($"<tr><td>{objct.TYPENAME}</td><td>{objct.NAME}</td></tr>");
                obj.Remove(objct);
            }
        }
        stringBuilder.Append("</table>");

        stringBuilder.Append('\n');
        stringBuilder.Append("<h3>Отчет по Обновлениям Населенных пунктов</h3><table>");
        foreach (OBJECT objct in obj)
        {
            if (objct.LEVEL == 6)
            {
                stringBuilder.Append($"<tr><td>{objct.TYPENAME}</td><td>{objct.NAME}</td></tr>");
                obj.Remove(objct);
            }
        }
        stringBuilder.Append("</table>");

        stringBuilder.Append('\n');
        stringBuilder.Append("<h3>Отчет по Обновлениям Элементов планировочной структуры</h3><table>");
        foreach (OBJECT objct in obj)
        {
            if (objct.LEVEL == 7)
            {
                stringBuilder.Append($"<tr><td>{objct.TYPENAME}</td><td>{objct.NAME}</td></tr>");
                obj.Remove(objct);
            }
        }
        stringBuilder.Append("</table>");

        stringBuilder.Append('\n');
        stringBuilder.Append("<h3>Отчет по Обновлениям Элементов улично-дорожных сетей</h3><table>");
        foreach (OBJECT objct in obj)
        {
            if (objct.LEVEL == 8)
            {
                stringBuilder.Append($"<tr><td>{objct.TYPENAME}</td><td>{objct.NAME}</td></tr>");
                obj.Remove(objct);
            }
        }
        stringBuilder.Append("</table>");

        stringBuilder.Append('\n');
        stringBuilder.Append("<h3>Отчет по Обновлениям Зданий(строений), сооружений</h3><table>");
        foreach (OBJECT objct in obj)
        {
            if (objct.LEVEL == 10)
            {
                stringBuilder.Append($"<tr><td>{objct.TYPENAME}</td><td>{objct.NAME}</td></tr>");
                obj.Remove(objct);
            }
        }
        stringBuilder.Append("</table>");

        stringBuilder.Append('\n');
        stringBuilder.Append("<h3>Отчет по Обновлениям Помещений</h3><table>");
        foreach (OBJECT objct in obj)
        {
            if (objct.LEVEL == 11)
            {
                stringBuilder.Append($"<tr><td>{objct.TYPENAME}</td><td>{objct.NAME}</td></tr>");
                obj.Remove(objct);
            }
        }
        stringBuilder.Append("</table>");

        stringBuilder.Append('\n');
        stringBuilder.Append("<h3>Отчет по Обновлениям Помещений в пределах помещений</h3><table>");
        foreach (OBJECT objct in obj)
        {
            if (objct.LEVEL == 12)
            {
                stringBuilder.Append($"<tr><td>{objct.TYPENAME}</td><td>{objct.NAME}</td></tr>");
                obj.Remove(objct);
            }
        }
        stringBuilder.Append("</table>");


        await context.Response.WriteAsync(stringBuilder.ToString());
    }
});
