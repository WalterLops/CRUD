using MySqlConnector;
using System.Data;

namespace BikeVale.Controllers
{
    public class ClienteController
    {
        protected static MySqlConnection connection = new MySqlConnection("server=localhost;userid=developer;password=123456;database=bancotp");
        public ClienteController() { } 

        public static async Task Insert(string query)//insert form
        {
            try {
                connection.Open();
                MySqlCommand cliente = new MySqlCommand(query, connection);
                connection.Close();
            }
            catch(Exception ex){
                Console.WriteLine(ex);
            }
        }
        
        public static async Task<string> Consulta(string query)
        {
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            try
            {
                connection.Open();
                MySqlCommand cliente = new MySqlCommand(query, connection);
                adapter.SelectCommand = cliente;
                DataTable tabela = new DataTable();
                adapter.Fill(tabela);
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return adapter.ToString();
        }

        public static async Task Update(string query)//update
        {
            try
            {
                connection.Open();
                MySqlCommand cliente = new MySqlCommand(query, connection);
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static async Task Delete(string query) //delete from
        {
            try
            {
                connection.Open();
                MySqlCommand cliente = new MySqlCommand(query, connection);
                connection.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public static async Task Teste()
        {
            connection.Open();
            MySqlCommand cliente = new MySqlCommand("SELECT Distinct Cliente.Nome, Cliente.Sobrenome , Bicicleta.Modelo from Cliente join Aluga on Cliente.Id_cliente = Aluga.Id_cliente join Bicicleta on Bicicleta.Id_bicicleta = Aluga.Id_bicicleta;", connection);
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            adapter.SelectCommand = cliente;
            DataTable tabela = new DataTable();
            adapter.Fill(tabela);
            connection.Close();
        }
    }
}
