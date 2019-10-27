using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public class BusinessBase
    {

        protected T ExecuteWithExceptionHandledOperation<T>(Func<T> func)
        {
            try
            {
                var result = func.Invoke();

                return result;
            }
            catch (CustomException ex)
            {
                throw new CustomException(ex.Code, ex.ReturnMessage);
            }
            catch (Exception ex)
            {
                throw new CustomException("500", ex.Message);
            }
        }

        protected void ExecuteWithExceptionHandledOperation(Action action)
        {
            try
            {
                action.Invoke();
            }
            catch (CustomException ex)
            {
                throw new CustomException(ex.Code, ex.ReturnMessage);
            }
            catch (Exception ex)
            {
                throw new CustomException("500", ex.Message);
            }
        }




        protected async Task<T> ExecuteWithExceptionHandledOperation<T>(Func<Task<T>> func)
        {
            try
            {
                return await func.Invoke();
            }
            catch (CustomException ex)
            {
                throw new CustomException(ex.Code, ex.ReturnMessage);
            }
            catch (Exception ex)
            {
                throw new CustomException("500", ex.Message);
            }
        }
    }
}
