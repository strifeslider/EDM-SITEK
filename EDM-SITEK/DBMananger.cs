using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using EDM_SITEK;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace EDM_SITEK
{
    public class DBMananger : DbContext
    {
        public DbSet<OBJECT> data { get; set; } = null!;

        public DBMananger() {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=sql7.freemysqlhosting.net;user=sql7731515;password=XqCtvUb5y7;database=sql7731515;",
            new MySqlServerVersion(new Version(8, 0, 25)));
        }

        public async Task DB_Upload()
        {
            FIAS_API Fias_api = new FIAS_API();
            FIAS_Url_Data data = await Fias_api.API_Call();
            string WorkPath = "Tmp_Dir//" + data.Date;
            foreach (var directory in Directory.GetDirectories(WorkPath))
            {
                string[] files = Directory.GetFiles(directory);
                foreach (string file in files)
                {;
                    string pattern = @"^AS_ADDR_OBJ_2.*";
                    if (Regex.IsMatch(file,pattern)) {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(OBJECT[]));
                        using (FileStream fs = new FileStream(file, FileMode.Open))
                        {
                            OBJECT[]? objct = xmlSerializer.Deserialize(fs) as OBJECT[];
                            if(objct != null)
                            {
                                foreach(OBJECT obj in objct)
                                {
                                    using (DBMananger dbMananger = new DBMananger())
                                    {
                                        dbMananger.data.AddRange(obj);
                                        dbMananger.SaveChanges();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
