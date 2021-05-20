using RefreshTODo.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;


namespace RefreshTODo.Data
{
    internal class ToDoDAO
    {

        private string connectionString = @"Server=tcp:refreshtododbserver.database.windows.net,1433;Initial Catalog=RefreshTODo_db;Persist Security Info=False;User ID=RefreshToDo;Password=<SqlPassword>;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
        //get the index
        public List<ToDoModel> FetchAll()
        {
            List<ToDoModel> returnList = new List<ToDoModel>();
            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.ToDos";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ToDoModel toDo = new ToDoModel();
                        toDo.Id = reader.GetInt32(0);
                        toDo.Employee = reader.GetString(1);
                        toDo.Task = reader.GetString(2);
                        toDo.StartDate = reader.GetString(3);
                        toDo.Deadline = reader.GetString(4);
                        toDo.Complete = reader.GetString(5);

                        returnList.Add(toDo);
                    }
                }
            }

            return returnList;
        }

        public ToDoModel FetchOne(int id)
        {
            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.ToDos WHERE Id = @id";

                //associate @id with Id with Id parameter

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.Int).Value = id;

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                ToDoModel toDo = new ToDoModel();

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {

                        toDo.Id = reader.GetInt32(0);
                        toDo.Employee = reader.GetString(1);
                        toDo.Task = reader.GetString(2);
                        toDo.StartDate = reader.GetString(3);
                        toDo.Deadline = reader.GetString(4);
                        toDo.Complete = reader.GetString(5);

                    }
                }
                return toDo;
            }
        }

        public int CreateOrUpdate(ToDoModel toDoModel)
        {
            //if toDoModel.id <= 0 then create

            //if toDoModel.id > 1 then update

            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "";


                if (toDoModel.Id <= 0)
                {
                    sqlQuery = "INSERT INTO dbo.ToDos Values(@Employee, @Task, @StartDate, @Deadline, @Complete)";
                }
                else
                {
                    sqlQuery = "UPDATE dbo.ToDos SET Employee = @Employee, Task = @Task, StartDate = @StartDate, Deadline = @Deadline, Complete = @Complete WHERE ID = @Id";
                }

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = toDoModel.Id;
                command.Parameters.Add("@Employee", System.Data.SqlDbType.VarChar, 1000).Value = toDoModel.Employee;
                command.Parameters.Add("@Task", System.Data.SqlDbType.VarChar, 1000).Value = toDoModel.Task;
                command.Parameters.Add("@StartDate", System.Data.SqlDbType.VarChar, 1000).Value = toDoModel.StartDate;
                command.Parameters.Add("@Deadline", System.Data.SqlDbType.VarChar, 1000).Value = toDoModel.Deadline;
                command.Parameters.Add("@Complete", System.Data.SqlDbType.VarChar, 1000).Value = toDoModel.Complete;


                connection.Open();
                int newID = command.ExecuteNonQuery();

                return newID;
                ;
            }

        }

        internal int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {

                string sqlQuery = "DELETE FROM dbo.ToDos WHERE Id = @Id";

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@Id", System.Data.SqlDbType.VarChar, 1000).Value = id;


                connection.Open();
                int deletedID = command.ExecuteNonQuery();

                return deletedID;
                ;
            }
        
        }

        internal List<ToDoModel> SearchForEmployee(string searchPhrase)
        {
            List<ToDoModel> returnList = new List<ToDoModel>();

            //access the database
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * from dbo.ToDos WHERE EMPLOYEE LIKE @searchForMe";

                //associate @Employee with Employee parameter

                SqlCommand command = new SqlCommand(sqlQuery, connection);

                command.Parameters.Add("@searchForMe", System.Data.SqlDbType.NVarChar).Value = "%" + searchPhrase + "%";

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();



                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        ToDoModel toDo = new ToDoModel();
                        toDo.Id = reader.GetInt32(0);
                        toDo.Employee = reader.GetString(1);
                        toDo.Task = reader.GetString(2);
                        toDo.StartDate = reader.GetString(3);
                        toDo.Deadline = reader.GetString(4);
                        toDo.Complete = reader.GetString(5);

                        returnList.Add(toDo);
                    }
                }
                return returnList;
            }
        }
    }


}