using System;
using System.Collections.Generic;
using System.Text;
using Models;

namespace Business
{
    public class UserBusiness :  BusinessBase,IUserBusiness
    {
        public UserLoginOutput Login(UserLoginInput input)
        {
            return base.ExecuteWithExceptionHandledOperation(() =>
            {
                //throw new ArgumentNullException();
                if (input.Email == "yusufcelik38@gmail.com" && input.Password == "123")
                {
                    return new UserLoginOutput()
                    {
                        Id = "1",
                        OperationResult = new OperationResult()
                    };
                }
                else
                {
                    throw new CustomException("200", "Kullanıcı adı veya şifre yanlış");
                }

            });

            }
    }
}
