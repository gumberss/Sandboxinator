using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Learning.Assemblies
{
    public class MyAssembly 
    {
        public void Process()
        {

            Assembly.Load(this.GetType().Assembly.FullName);
            Assembly.LoadFile(this.GetType().Assembly.Location);
            Assembly.LoadFrom("Learning.dll");


            // Assembly.Load("Assembly identifier");
            // Assembly.LoadFrom("Relative path");
            // Assembly.LoadFIle("Path");
        }
    }
}
