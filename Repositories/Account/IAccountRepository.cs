using SignUpTask.Models.Account;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SignUpTask.Repositories.Account
{
    interface IAccountRepository
    {
        public bool SignUp(User obj);
        public bool IsEmailExists(string email);
    }
}
