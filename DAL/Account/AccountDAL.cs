using SignUpTask.Models.Account;
using System;
using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;

namespace SignUpTask.DAL.Account
{
    public class AccountDAL
    {
        string ConString = ConfigurationManager.ConnectionStrings["ConString"].ConnectionString;
        public bool SignUp(User obj)
        {
            int inserted;

            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into dbo.tblUserAccount values(@pFirstName, @pLastName, @pEmail, @pPassword, 1, 0, GETDATE(), GETDATE())", con);

                cmd.Parameters.AddWithValue("@pFirstName", obj.FirstName);
                cmd.Parameters.AddWithValue("@pLastName", obj.LastName);
                cmd.Parameters.AddWithValue("@pEmail", obj.Email);
                cmd.Parameters.AddWithValue("@pPassword", obj.Password);

                inserted = cmd.ExecuteNonQuery();
            }
            if(inserted > 0)
                return true;
            else
                return false;
        }

        public bool IsEmailExists(string email)
        {
            bool EmailExists = false;
            using (SqlConnection con = new SqlConnection(ConString))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select TOP(1) Email from dbo.tblUserAccount where Email = @pEmail and IsDeleted = 0", con);

                cmd.Parameters.AddWithValue("@pEmail", email);
                SqlDataReader dr = cmd.ExecuteReader();

                if (dr.Read())
                {
                    if (dr["Email"].ToString() == email)
                        EmailExists = true;

                }
            }

            return EmailExists;
        }
    }
}
