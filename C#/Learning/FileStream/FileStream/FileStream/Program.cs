
using System.Text;
try
{

    FileStream fs = new FileStream(
     @"path",
     FileMode.OpenOrCreate,
     FileAccess.Write);

    var alreadyInserted = 0;
    for (int i = 0; i < 2000; i++)
    {
        for (int j = 0; j < 20000; j++)
        {
            var msg = Encoding.ASCII.GetBytes("Hello ");
            fs.Write(msg, 0, msg.Length);
        }
        fs.Write(Encoding.ASCII.GetBytes(Environment.NewLine), 0, 1);
    }
    fs.Close();

}
catch (Exception ex)
{

}