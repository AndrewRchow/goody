using Goody.Web.Models.Domain;
using Goody.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Goody.Web.Services
{
    public class PersonService
    {
        private string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public int Insert(PersonAddRequest model)
        {
            int id = 0;
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Person_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleName", model.MiddleName);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@DOB", model.DOB);
                    cmd.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);

                    SqlParameter parm = new SqlParameter("@Id", SqlDbType.Int);
                    parm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);

                    cmd.ExecuteNonQuery();

                    id = (int)cmd.Parameters["@Id"].Value;
                }
                conn.Close();
            }
            return id;
        }

        public Person SelectById(int id)
        {
            Person model = new Person();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Person_SelectByid", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    SqlDataReader reader = cmd.ExecuteReader();
                    reader.Read();
                    model = Mapper(reader);
                }
                conn.Close();
            }
            return model;
        }

        public List<Person> SelectAll() {
            List<Person> personList = new List<Person>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Person_SelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Person model;
                        try
                        {
                            model = Mapper(reader);
                        }
                        catch (Exception ex)
                        {
                            string msg = ex.Message;
                            throw;
                        }
                        personList.Add(model);
                    }
                }
                conn.Close();
            }
            return personList;
        }

        public void Update(Person model)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("Person_Update", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", model.Id);
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleName", model.MiddleName);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@DOB", model.DOB);
                    cmd.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);

                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        public void Delete(int id)
        {
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd=new SqlCommand("Person_Delete", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
        }

        private Person Mapper(SqlDataReader reader)
        {
            Person model = new Person();
            int index = 0;
            model.Id = reader.GetInt32(index++);
            model.FirstName = reader.GetString(index++);

            if (!reader.IsDBNull(index))
                model.MiddleName = reader.GetString(index++);
            else
                index++;

            model.LastName = reader.GetString(index++);
            model.DOB = reader.GetDateTime(index++);
            model.CreatedDate = reader.GetDateTime(index++);
            model.ModifiedDate = reader.GetDateTime(index++);
            model.ModifiedBy = reader.GetString(index++);

            return model;
        }
    }
}