using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;
using EDM_SITEK;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Xml;
using System;

namespace EDM_SITEK
{
    public class DBMananger : DbContext
    {
        public DbSet<OBJECT> data { get; set; } = null!;

        public DBMananger()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("server=sql7.freemysqlhosting.net;user=sql7731515;password=XqCtvUb5y7;database=sql7731515;",
            new MySqlServerVersion(new Version(5, 5, 62)));
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
                {
                    string pattern = @"AS_ADDR_OBJ_\d";
                    if (Regex.IsMatch(file, pattern))
                    {
                        XmlSerializer xmlSerializer = new XmlSerializer(typeof(ADDRESSOBJECTS));
                        using (FileStream fs = new FileStream(file, FileMode.OpenOrCreate))
                        {
                            ADDRESSOBJECTS? AddressObject = xmlSerializer.Deserialize(fs) as ADDRESSOBJECTS;
                            List<OBJECT> objects = AddressObject.OBJECT;
                            foreach (OBJECT obj in objects)
                            {
                                if (!ExistInDatabase(obj.ID, this))
                                {
                                    using (DBMananger db = new DBMananger())
                                    {
                                        db.data.AddRange(obj);
                                        db.SaveChanges();
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        private bool ExistInDatabase(int id, DBMananger db)
        {
            return db?.data?.Any(o => o.ID == id) ?? false;
        }
    }
}