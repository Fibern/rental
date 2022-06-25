using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rental.Stores
{
    public class AuthenticationStore
    {
        private string _login;
        public string Login 
        { 
            get => _login ?? "";
            set => _login = value;
        }
        private string _password;
        public string Password 
        { 
            get => _password ?? "";
            set => _password = value;
        }
    }
}
