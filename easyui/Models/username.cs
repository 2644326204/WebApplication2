using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace easyui.Models
{
    public class username
    {
        private String _username;
        private String _password;
        private String _phone;
        public String userName
        {
            get { return _username; }
            set { _username = value; }
        }
        public String passWord
        {
            get { return _password; }
            set { _password = value; }
        }
        public String phone
        {
            get { return _phone; }
            set { _phone = value; }
        }
    }
}