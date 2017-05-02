using Goody.Web.Models;
using Goody.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Goody.Web.Services
{
    public class EditorService
    {
        private string connStr = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

        public void EditorContent_DeleteById(int id)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("EditorContent_DeleteById", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
            }

        }

        public List<EditorContentResponse> EditorContent_GetAll()
        {
            List<EditorContentResponse> editorContentList = new List<EditorContentResponse>();            
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("EditorContent_GetAll", conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            EditorContentResponse resp = new EditorContentResponse();
                            resp.Id = (int)reader[0];
                            resp.Title = (string)reader[1];
                            resp.Description = (string)reader[2];
                            editorContentList.Add(resp);
                        }
                    }
                }
            }
            return editorContentList;
        }

        public int EditorContent_Insert(EditorContentInsertRequest req) {
            int retVal = 0;
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("EditorContent_Insert",conn))
                {
                    cmd.Parameters.AddWithValue("@Title", req.Title);
                    cmd.Parameters.AddWithValue("@Description", req.Description);
                    SqlParameter parm = new SqlParameter();
                    parm.ParameterName = "@Id";
                    parm.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(parm);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                    retVal = (int)cmd.Parameters["@Id"].Value;
                    conn.Close();
                }
            }
            return retVal;
        }

        public EditorContentResponse EditorContent_SelectById(int id)
        {
            EditorContentResponse editorContent = new EditorContentResponse();
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("EditorContent_SelectById", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection))
                    {
                        while (reader.Read())
                        {
                            editorContent.Id = (int)reader[0];
                            editorContent.Title = (string)reader[1];
                            editorContent.Description = (string)reader[2];
                            break;
                        }
                    }
                }
            }
            return editorContent;
        }

        public void EditorContent_Update(EditorContentUpdateRequest req)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand cmd = new SqlCommand("EditorContent_Update", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", req.Id);
                    cmd.Parameters.AddWithValue("@Title", req.Title);
                    cmd.Parameters.AddWithValue("@Description", req.Description);
                    conn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}