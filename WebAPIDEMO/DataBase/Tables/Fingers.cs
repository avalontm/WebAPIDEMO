using PluginSQL;

namespace WebAPIDEMO.DataBase.Tables
{
    public class Fingers :TableBase
    {
        [PrimaryKey]
        public int id { set; get; }
        public int user_id { set; get; }
        public string? data { set; get; }

        public static Fingers? Find(int id)
        {
            return MYSQL.Query<Fingers>($"SELECT * FROM fingers WHERE id='{id}' LIMIT 1").FirstOrDefault();
        }
    }
}
