using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;

namespace firstclass.Pages.Client
{
    public class Index1Model : PageModel
    {
        public List<ClientInfo> listClients = new List<ClientInfo>();
        public void OnGet(string SearchString)
        {
            try
            {
                var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\kanik\\OneDrive\\Documents\\xyz.mdf;Integrated Security=True;Connect Timeout=30";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    var sql = "SELECT * FROM clients where name like '%" + SearchString + "%'";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                ClientInfo clientInfo = new ClientInfo();
                                clientInfo.id = reader.GetInt32(0);
                                clientInfo.name = reader.GetString(1);
                                clientInfo.email = reader.GetString(2);
                                clientInfo.phone = reader.GetString(3);
                                clientInfo.address = reader.GetString(4);

                                listClients.Add(clientInfo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:" + ex.ToString());
            }

        }
    }
    public class ClientInfo
    {
        public Int32 id;
        public String? name;
        public String? email;
        public String? phone;
        public String? address;

    }

}

