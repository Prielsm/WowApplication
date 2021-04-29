using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using WowApplication.Repositories;

namespace WowApplication.Models
{
    public class LoginViewModel
    {
        private DataContext ctx = new DataContext(ConfigurationManager.ConnectionStrings["Cnstr"].ConnectionString);

        private MembreModel _membreModel;
        private LoginModel _loginModel;

        public LoginViewModel()
        {

        }

        public MembreModel MembreModel
        {
            get
            {
                return _membreModel;
            }

            set
            {
                _membreModel = value;
            }
        }

        public LoginModel LoginModel
        {
            get
            {
                return _loginModel;
            }

            set
            {
                _loginModel = value;
            }
        }
    }
}