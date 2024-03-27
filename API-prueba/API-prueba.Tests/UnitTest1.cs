using NUnit.Framework;
using System.Text.Json;

[TestFixture]
class RestApiTest
{
  private readonly HttpClient _client;

  public RestApiTest()
  {
    _client = new HttpClient();
    _client.BaseAddress = new Uri("http://localhost:5073");
  }

  [Test]
  public async Task CheckVerbHttpIfStatusCodeIsNotEqual200()
  {
    var res = await _client.GetAsync("/users/adsa");
    var expected = 404;
    var resStatusCode = (int)res.StatusCode;

    Xunit.Assert.Equal(expected, resStatusCode);
  }

  public async Task CheckVerbHttpIfStatusCodeIsEqual200()
  {
    var res = await _client.GetAsync("/users");
    var expected = 200;
    var resStatusCode = (int)res.StatusCode;

    Xunit.Assert.Equal(expected, resStatusCode);
  }

  [Test]
  public async Task CheckContentInResponse()
  {
    var res = await _client.GetAsync("/users");
    var resToString = await res.Content.ReadAsStringAsync();
    var users = JsonSerializer.Deserialize<User[]>(resToString);

    var expected = 200;
    var resStatusCode = (int)res.StatusCode;

    var userZero = users[0];
    System.Console.WriteLine(userZero.name);

    Xunit.Assert.Equal("John", userZero.name);
    Xunit.Assert.Equal(expected, resStatusCode);
  }

  [Test]
  public async Task GetOneUser()
  {
    var res = await _client.GetAsync("/user/1"); 
    
    // Verificar el status code
    var expectedStatusCode = 200;
    var resStatusCode = (int)res.StatusCode;
    Xunit.Assert.Equal(expectedStatusCode, resStatusCode);

    // Verificar que la respuesta sea un JSON
    var expectedContentType = "application/json; charset=utf-8";
    var resContentType = res.Content.Headers.ContentType.ToString();
    Xunit.Assert.Equal(expectedContentType, resContentType);
  }

  [Test]
  public async Task asd()
  {
    var user = "a";

    var res = await _client.GetAsync($"/user/{user}");
    var resToString = await res.Content.ReadAsStringAsync();
    var error = JsonSerializer.Deserialize<RequestError>(resToString);

    Xunit.Assert.Equal(400, error.statusCode);
    Xunit.Assert.Equal(user, error.yourValue);
    Xunit.Assert.NotEmpty(error.message);
  }

  [Test]
  public async Task UserNotFount()
  {
    var user = 14;
    var res = await _client.GetAsync($"/user/{user}");
    var resToString = await res.Content.ReadAsStringAsync();
    var error = JsonSerializer.Deserialize<UserNotFountTemplate>(resToString);
    int resStatusCode = (int)res.StatusCode;

    Xunit.Assert.Equal(404, resStatusCode); // Verificar que el status code sea 404
    Xunit.Assert.Equal(200, error.statuscode); // Verificar que me devuelva en el JSON el status Code correcto

    Xunit.Assert.NotEmpty(error.message);

  }

  class UserNotFountTemplate
  {
    public string message { get; set; }
    public int statusCode { get; set; }
  }
  class RequestError
  {
    public string message { get; set; }
    public int statusCode { get; set; }
    public string yourValue { get; set; }
  }

  class User
  {
    public string name { get; set; }
    public string id { get; set; }
  }
}

