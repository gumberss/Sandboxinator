using Amazon.CDK;
using Amazon.CDK.AWS.DynamoDB;
using Amazon.CDK.AWS.Lambda;
using Amazon.CDK.AWS.S3;
using Amazon.CDK.AWS.Cognito;
using Constructs;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;
using Amazon.CDK.AWS.APIGateway;

namespace Test2
{
    public class Test2Stack : Stack
    {
        internal Test2Stack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            // Creates S3 Bucket
            new Bucket(this, "MyFirstBucket", new BucketProps
            {
                Versioned = true
            });

            // Create DynamoDB Table
            new Table(this, "MyFirstDynamoDBTable", new TableProps
            {
                PartitionKey = new Attribute
                {
                    Name = "PK",
                    Type = AttributeType.STRING
                },
                SortKey = new Attribute { Name = "SK", Type = AttributeType.STRING },
                BillingMode = BillingMode.PAY_PER_REQUEST
            });

            // Creates Lambda Function
            var lambda1 = new Function(this, "LambdaFunction", new FunctionProps
            {
                Runtime = Runtime.DOTNET_6,
                //assembly::Namespace.of.it::Function
                Handler = "AWSServerless1::AWSServerless1.Functions::Get",
                Code = Code.FromAsset("src/AWSServerless1/bin/Debug/net6.0")
            });

            var lambda2 = new Function(this, "LambdaFunctionTop", new FunctionProps
            {
                Runtime = Runtime.DOTNET_6,
                //assembly::Namespace.of.it::Function
                Handler = "AWSServerless1::AWSServerless1.Functions::Plus",
                Code = Code.FromAsset("src/AWSServerless1/bin/Debug/net6.0")
            });

            var userPool = new UserPool(this, "somePoolId", new UserPoolProps()
            {
                SignInAliases = new SignInAliases
                {
                    Email = true
                },
                SelfSignUpEnabled = true,
                AutoVerify = new AutoVerifiedAttrs
                {
                    Email = true
                },
                UserVerification = new UserVerificationConfig
                {
                    EmailSubject = "You need to verify your email",
                    EmailBody = "Thanks for signing up Your verification code is {####}",
                    EmailStyle = VerificationEmailStyle.CODE,
                },
                StandardAttributes = new StandardAttributes()
                {
                    Email = new StandardAttribute()
                    {
                        Required = true
                    }
                },
                CustomAttributes = new Dictionary<string, ICustomAttribute> { },
                PasswordPolicy = new PasswordPolicy
                {
                    MinLength = 8,
                    RequireLowercase = false,
                    RequireUppercase = false,
                    RequireDigits = false,
                    RequireSymbols = false,
                },
                Email = UserPoolEmail.WithCognito(),
                AccountRecovery = AccountRecovery.EMAIL_ONLY,
                RemovalPolicy = RemovalPolicy.DESTROY,

            });

            userPool.AddDomain("cognitoDomain", new UserPoolDomainOptions
            {
                CognitoDomain = new CognitoDomainOptions
                {
                    DomainPrefix = "my-app12d12414srdr"
                }
            });


            userPool.AddClient("appClient", new UserPoolClientOptions
            {
                OAuth = new OAuthSettings
                {
                    CallbackUrls = new[] { "https://www.google.com.br" }
                },
                AuthFlows = new AuthFlow
                {
                    UserPassword = true
                }
            });

            var restApi = new LambdaRestApi(this, "MyRestApi", new LambdaRestApiProps
            {
                Handler = lambda1,
                Proxy = false
            });

            var resources = restApi.Root
                .AddResource("{x}", new ResourceOptions { })
                .AddResource("{y}", new ResourceOptions { });

            var cognitoAuthorizer = new CognitoUserPoolsAuthorizer(this, "CognitoAuthorizer", new CognitoUserPoolsAuthorizerProps
            {
                CognitoUserPools = new[]
            {
                    userPool
                },
                IdentitySource = "method.request.header.Authorization"
            });

            var apiFunctionTwo = resources.AddMethod("GET", new LambdaIntegration(lambda2, new LambdaIntegrationOptions
            {
                Proxy = true
            }), new MethodOptions
            {
                Authorizer = cognitoAuthorizer,
                AuthorizationType = AuthorizationType.COGNITO
            });

        }
    }
}
