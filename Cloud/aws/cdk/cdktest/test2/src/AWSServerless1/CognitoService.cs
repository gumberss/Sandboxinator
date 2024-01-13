using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;

namespace AWSServerless1
{
    internal class CognitoService
    {
        public struct User
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string Email { get; set; }
            public string NickName { get; set; }
        }


        private readonly AmazonCognitoIdentityProviderClient _cognitoClient;
        public CognitoService()
        {
            _cognitoClient = new AmazonCognitoIdentityProviderClient(
                                     "your_client_Id_of_Cognito",
                                     "your_client_secret",
                                     Amazon.RegionEndpoint.USEast1);
        }

        public async Task SignUp(User user)
        {
            var userSignUpRequest = new SignUpRequest
            {
                ClientId = "your_client_id",
                Password = user.Password,
                Username = user.Email
            };

            var attributeNickname = new AttributeType
            {
                Name = "nickname",
                Value = user.NickName
            };
            userSignUpRequest.UserAttributes.Add(attributeNickname);

            try
            {
                var userCreated = await _cognitoClient.SignUpAsync(userSignUpRequest);
                await Console.Out.WriteLineAsync("User created");
                await Console.Out.WriteLineAsync(user.UserName);
            }
            catch(Exception ex)
            {
                await Console.Out.WriteLineAsync(ex.ToString());
            }
        }
    }
}
