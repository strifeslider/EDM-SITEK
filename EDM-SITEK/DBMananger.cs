using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using System.Xml;

namespace EDM_SITEK
{
    public class DBMananger : DbContext
    {
        public DbSet<FIAS_Url_Data> data { get; set; } = null!;

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
                XmlDocument xDoc = new XmlDocument();
                string[] files = Directory.GetFiles(directory);
                foreach (string file in files)
                {
                    
                    string pattern = @"^AS_ADDR_OBJ_2.*";
                    if (Regex.IsMatch(file,pattern)) {
                        xDoc.Load(file);
                        XmlElement? xRoot = xDoc.DocumentElement;
                        foreach (XmlElement xnode in xRoot)
                        {
                            if( xnode.Name == "OBJECT")
                            {

                            }
                        }
                    }
                }
            }
        }
    }
}
