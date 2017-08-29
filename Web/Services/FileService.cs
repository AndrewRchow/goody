using Goody.Web.Models.Requests;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Goody.Web.Services
{
    public class FileService : BaseService
    {
        public async Task<int> Insert(FileUploadAddRequest model)
        {
            // string fileUrl = System.IO.Path.Combine(
            //                      System.Configruation.ConfigurationManager.AppSettings["fileFolder"].Value,
            //                      model.SystemFileName);
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
    }
}