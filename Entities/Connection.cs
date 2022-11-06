using System.Data;
using System.Data.SqlClient;
using api_LS.Entities;
namespace api_LS.Entities
{
    public class Connection
    {
        private string url { get; set; }


        public Connection()
        {
            IConfigurationBuilder config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfiguration configuration = config.Build();
            this.url = configuration["DBConnection"];
        }

        public Respuesta Consultar(string Query)
        {
            DataTable data = new DataTable();
            Respuesta res=new Respuesta();
            try
            {
                using (SqlConnection connection = new SqlConnection(this.url))
                {
                    connection.Open();
                    string query = $"{Query}";
                    SqlCommand comando = new SqlCommand(query, connection);
                    SqlDataReader reader = comando.ExecuteReader();
                    data.Load(reader);
                    res.data=data;
                    connection.Close();
                }
            }
            catch (Exception ex)
            {
                res.Mensaje=ex.Message.ToString();
                return res;
            }
            return res;
        }
        public string insert(string Query)
        {
            string mensaje;
            try
            {
                using (SqlConnection connection = new SqlConnection(this.url))
                {
                    connection.Open();
                    string query = $"{Query}";
                    SqlCommand comando = new SqlCommand(query, connection);
                    comando.ExecuteReader();
                    
                    connection.Close();
                    mensaje="Se insertaron correctamente";
                }
            }
            catch (Exception ex)
            {
                return ex.Message.ToString();
                
            }
            return mensaje;
        }
    }
}