using Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business
{
    public interface IUserBusiness
    {
        public UserLoginOutput Login(UserLoginInput input);
    }
}
