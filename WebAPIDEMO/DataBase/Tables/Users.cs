using PluginSQL;

namespace WebAPIDEMO.DataBase.Tables
{
    public class Users : TableBase
    {
        [PrimaryKey]
        public int id { set; get; }
        public DateTime created_at { set; get; }
        public DateTime updated_at { set; get; }
        public string? email { set; get; }
        public string? password { set; get; }
        public string? name { set; get; }

        public static Users? Find(int id)
        {
            return MYSQL.Query<Users>($"SELECT * FROM users WHERE id='{id}' LIMIT 1").FirstOrDefault();
        }

        public static List<Users> Get(int limit = 20)
        {
            return MYSQL.Query<Users>($"SELECT * FROM users LIMIT {limit}");
        }

        public static Users? Get(string email, string password)
        {
            return MYSQL.Query<Users>($"SELECT * FROM users WHERE email='{email}' AND password='{password}' LIMIT 1").FirstOrDefault();
        }
    }
}
