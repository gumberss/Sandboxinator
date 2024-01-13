using Amazon.CDK;
using Amazon.CDK.AWS.DynamoDB;
using Amazon.CDK.AWS.S3;
using Constructs;

namespace Test1
{
    public class Test1Stack : Stack
    {
        internal Test1Stack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {

            // Creates S3 Bucket
            new Bucket(this, "MyFirstBucket", new BucketProps
            {
                Versioned = true
            });

            // Create DynamoDB Table
            new Table(this, "MyFirstDynamoDBTable", new TableProps
            {
                PartitionKey = new Attribute { Name = "PK", Type = AttributeType.STRING },
                SortKey = new Attribute { Name = "SK", Type = AttributeType.STRING },
                BillingMode = BillingMode.PAY_PER_REQUEST
            });

            // Creates Lambda Function
            /*new Function(this, "LambdaFunction", new FunctionProps
            {
                Runtime = Runtime.NODEJS_12_X,
                Handler = "index.handler",
                Code = new InlineCode("exports.handler = _ => 'Hello, CDK';")
            });*/
        }
    }
}
