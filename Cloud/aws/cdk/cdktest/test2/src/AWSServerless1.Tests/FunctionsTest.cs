using Amazon.Lambda.Annotations.APIGateway;
using Amazon.Lambda.APIGatewayEvents;
using Amazon.Lambda.TestUtilities;
using System.Net;
using Xunit;

namespace AWSServerless1.Tests;

public class FunctionTest
{
    public FunctionTest()
    {
    }

    [Fact]
    public void TestGetMethod()
    {
        var context = new TestLambdaContext();
        var functions = new Functions();

        var response = functions.Get(new APIGatewayProxyRequest(), context);

        Assert.Equal(System.Net.HttpStatusCode.OK, (HttpStatusCode)response.StatusCode);

        var serializationOptions = new HttpResultSerializationOptions { Format = HttpResultSerializationOptions.ProtocolFormat.RestApi };
        Assert.Contains("Hello AWS Serverless", response.Body);
    }
}
