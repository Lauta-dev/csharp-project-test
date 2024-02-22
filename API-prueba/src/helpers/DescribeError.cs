using FormatJson;

namespace DescribeError
{
  class Error
    {
      public int ErrorCode { get; set; }
      public string ErrorMessage { get; set; }

      public Error(int errorCode, string errorMessage)
      {
        ErrorMessage = errorMessage;
        ErrorCode = errorCode;
      }

      public string GetErrorsInJson()
      {
        // FIX: Ya me devuelve un el objeto correcto
        var error = FormatJsonSerializer.Format(this);
        return error;
      }
    }
}
