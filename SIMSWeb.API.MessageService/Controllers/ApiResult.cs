using System;

namespace SIMSWeb.API.MessageService.Controllers
{
    public class ApiResult<T>
    {
        public ApiResult()
        {
        }

        public ApiResult(T successItem)
        {
            WasSuccessful = true;
            Item = successItem;
        }

        public ApiResult(bool wasSuccessful, string errorMessage)
        {
            WasSuccessful = wasSuccessful;
            ErrorMessage = errorMessage;
        }

        public ApiResult(Exception e)
        {
            WasSuccessful = false;
            ErrorMessage = e.Message;
        }
        public bool WasSuccessful { get; set; }

        public string ErrorMessage { get; set; }

        public T Item { get; set; }
    }
}