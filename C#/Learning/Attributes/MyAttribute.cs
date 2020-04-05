using System;
using System.Collections.Generic;
using System.Text;

namespace Learning.Attributes
{
    //author is a positional parameter because it is in the constructor 
    //and modified is a named parameter because it is a public property that is not in the constructor
    //http://www.java2s.com/Tutorial/CSharp/0200__Attribute/PositionalvsNamedParameters.htm
    [MyAtt(author: "hi", Modified = "hi")]
    public class MyAttribute
    {

        public void Process()
        {

        }
    }

    public class MyAtt : Attribute
    {
        private String Author;
        public string Modified;

        public MyAtt(String author)
        {
            Author = author;
            Modified = DateTime.Now.ToString();
        }
    }
}
