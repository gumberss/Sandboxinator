using Amazon.Runtime;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using System.Net.Http.Headers;


var provider = new AmazonCognitoIdentityProviderClient();

var password = "PASSWORD";

var initiateAuthRequest = new InitiateAuthRequest
{
    AuthFlow = AuthFlowType.USER_PASSWORD_AUTH,
    AuthParameters = new Dictionary<string, string>
                {
                    { "USERNAME", "USERNAME OR EMAIL" },
                    { "PASSWORD", password }
                },
    ClientId = "[[APP INTEGRATION CLIENT ID]]",
};

var initiateAuthResponse = await provider.InitiateAuthAsync(initiateAuthRequest);
Console.WriteLine(initiateAuthResponse.AuthenticationResult.IdToken);

HttpClient client = new HttpClient();
client.BaseAddress = new Uri($"https://w8yy4e0hg4.execute-api.us-east-1.amazonaws.com/prod/{10}/{20}");
client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", initiateAuthResponse.AuthenticationResult.IdToken);

HttpResponseMessage response = client.GetAsync("").Result;

if (response.IsSuccessStatusCode)
{
    var dataObjects = response.Content.ReadAsStringAsync().Result;
    Console.WriteLine(dataObjects);
}
else
{
    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
}


