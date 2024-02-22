namespace Messages
{
  class Message
  {
    protected string MessageText { get; set; }
    protected int StatusCode { get; set; }

    public Message(string message, int statusCode)
    {
      MessageText = message;
      StatusCode = statusCode;
    }

    protected Message() {}
    

    virtual public object GetMessage() => new { MessageText, StatusCode };

  }

  class IfIdNotANumber : Message
  {
    private string YourValue { get; set; }
    
    private const string DefaultMessage = "El valor tiene que ser numérico";
    private const int DefaultStatusCode = 404;
    private const string DefaultYourValue = "";

    public IfIdNotANumber(string message, int statusCode, string yourValue = DefaultYourValue): base(message, statusCode)
    {
      MessageText = message;
      StatusCode = statusCode;
      YourValue = yourValue;
    }

    public IfIdNotANumber(): base(DefaultMessage, DefaultStatusCode)
    {
      MessageText = DefaultMessage;
      StatusCode = DefaultStatusCode;
    }

    public IfIdNotANumber(string yourValue): base(DefaultMessage, DefaultStatusCode)
    {
      YourValue = yourValue;
    }

    override public object GetMessage() {
      var returnWithoutYourValue = new { Message = MessageText, statusCode = StatusCode };
      var returnWithYourValue = new { Message = MessageText, statusCode = StatusCode, yourValue = YourValue };

      if (YourValue is null)
      {
        return returnWithoutYourValue;
      }

      return returnWithYourValue;
    } 
  }
}
