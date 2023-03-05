using AssignmentTaskCleanCode.Extensions;
using AssignmentTaskCleanCode.Models;
using AssignmentTaskCleanCode.Service.Interfaces;

namespace AssignmentTaskCleanCode.Service.Business
{
    public class UserService:IUserService
    {
       ~UserService() { }
        public async Task<bool> SaveToDatebase(User user)
        {
            try
            {
                if (user == null)
                    return false;

                SqlConnection sql = new SqlConnection(Connections.connectionUrl);
                await sql.OpenAsync();

                string query = $"INSERT INTO Users (Name, Age) VALUES ('{user.Name},{user.Age}')";
                SqlCommand cmd = new SqlCommand(query, sql);

                await cmd.ExecuteNonQueryAsync();
                await sql.CloseAsync();

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error Saving user to database" + ex.Message);
                return false;
            }
        }
        public Task<List<User>> GetUserList()
        {
            SqlConnection sql = new SqlConnection(Connections.connectionUrl);
            await sql.OpenAsync();

            string query = "SELECT Name,Age FROM Users";
            SqlCommand cmd = new SqlCommand(query, sql);
            SqlDataReader reader = cmd.ExecuteReader();

            while(reader.Read())
            {
                Console.WriteLine(reader["Name"] + "," + reader["Age"]);
            }
            reader.Close();
            sql.Close();

        }

    }
}
