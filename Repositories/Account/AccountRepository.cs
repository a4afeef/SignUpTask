using SignUpTask.DAL.Account;
using SignUpTask.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignUpTask.Repositories.Account
{
    public class AccountRepository : IAccountRepository
    {
        AccountDAL objAccountDAL = new AccountDAL();
        public bool SignUp(User Obj)
        {
            return objAccountDAL.SignUp(Obj);
        }

        public bool IsEmailExists(string email)
        {
            return objAccountDAL.IsEmailExists(email);
        }
    }
}
