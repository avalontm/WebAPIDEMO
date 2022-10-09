using PluginSQL;
using WebAPIDEMO.DataBase.Tables;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

/*-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=*/
/* SECCION BASE DE DATOS */
/*-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=*/

string _host = String.Empty;
int _port = 3306;
string _user = String.Empty;
string _pwd = String.Empty;
string _name = string.Empty;

_host = app.Configuration.GetSection("MYSQL").GetValue<string>("host");
_port = app.Configuration.GetSection("MYSQL").GetValue<int>("port");
_user = app.Configuration.GetSection("MYSQL").GetValue<string>("user");
_pwd = app.Configuration.GetSection("MYSQL").GetValue<string>("pwd");
_name = app.Configuration.GetSection("MYSQL").GetValue<string>("name");

//Conectamos la base de datos
MYSQL.Init(_host, _port, _user, _pwd, _name);

bool iscreate = MYSQL.CreateDataBase();

MYSQL.CreateTable<Users>();
MYSQL.CreateTable<Fingers>();

if (MYSQL.Table<Users>().Count == 0)
{
    Users item = new Users();
    item.created_at = DateTime.Now;
    item.updated_at = DateTime.Now;
    item.email = "admin@demo.com";
    item.password = "admin";
    item.name = "administrador";

    item.Insert();
}

bool status = MYSQL.CheckStatus();

if (status)
{
    Console.WriteLine("[MYSQL] conectado :)");
}
else
{
    Console.WriteLine("[MYSQL] no conectado :(");
}

/*-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=*/
/*-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=*/

app.Run();
