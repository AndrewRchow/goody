using Goody.Web.Models.Domain;
using Goody.Web.Models.Requests;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using System;
using System.Configuration;
using System.IO;

namespace Goody.Web.Services
{
    public class FileService : BaseService
    {
        public List<UploadedFile> SelectAll()
        {
            List<UploadedFile> fileList = new List<UploadedFile>();
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UploadedFile_SelectAll", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        UploadedFile file = this.Mappper(reader);
                        fileList.Add(file);
                    }
                }
                conn.Close();
            }
            return fileList;
        }

        public async Task<int> Insert(FileUploadAddRequest model)
        {
            int id = 0;
            using (SqlConnection conn=new SqlConnection(connString))
            {
                await conn.OpenAsync();
                using (SqlCommand cmd = new SqlCommand("UploadedFile_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FileName", model.FileName);
                    cmd.Parameters.AddWithValue("@Size", model.Size);
                    cmd.Parameters.AddWithValue("@Type", model.Type);
                    cmd.Parameters.AddWithValue("@SystemFileName", model.ServerFileName);
                    cmd.Parameters.AddWithValue("@ModifiedBy", model.ModifiedBy);

                    SqlParameter parm = new SqlParameter("@Id", SqlDbType.Int);
                    parm.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(parm);

                    await cmd.ExecuteNonQueryAsync().ContinueWith(_ => conn.Close());
                    id = (int)cmd.Parameters["@Id"].Value;
                }
            }
            return id;
        }

        private UploadedFile Mappper(SqlDataReader reader)
        {
            int index = 0;
            string baseUrl = ConfigurationManager.AppSettings["fileFolder"];
            UploadedFile file = new UploadedFile();
            file.Id = reader.GetInt32(index++);
            file.FileName = reader.GetString(index++);
            file.Size = reader.GetInt32(index++);
            file.Type = reader.GetString(index++);
            file.SystemFileName = baseUrl.Replace("~","") + "/" + reader.GetString(index++);
            file.CreatedDate = reader.GetDateTime(index++);
            file.ModifiedDate = reader.GetDateTime(index++);
            file.Modifiedby = reader.GetString(index++);

            return file;
        }
    }
}