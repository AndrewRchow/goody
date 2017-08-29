using Goody.Web.Models.Requests;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Goody.Web.Services
{
    public class FileService : BaseService
    {
        public int Insert(FileUploadAddRequest model)
        {
            int id = 0;
            using (SqlConnection conn=new SqlConnection(connString))
            {
                conn.Open();
                using (SqlCommand cmd = new SqlCommand("UploadedFile_Insert", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@UserName", model.Username);
                    cmd.Parameters.AddWithValue("@FileName", model.PostedFile.FileName);
                    cmd.Parameters.AddWithValue("@Size", model.PostedFile.ContentLength);
                    cmd.Parameters.AddWithValue("@Type", model.PostedFile.ContentType);
                    cmd.Parameters.AddWithValue("@SystemFileName", model.ServerFileName);
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
    }
}