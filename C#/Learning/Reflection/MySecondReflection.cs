using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Learning.Reflection
{
    public class MySecondReflection
    {
        public void Process()
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            Console.WriteLine(assembly.FullName);
            Console.WriteLine(assembly.GetName().Version);
            Console.WriteLine("Major: " + assembly.GetName().Version.Major);
            Console.WriteLine("Minor: " + assembly.GetName().Version.Minor);
            Console.WriteLine("Build: " + assembly.GetName().Version.Build);
            Console.WriteLine("Revision: " + assembly.GetName().Version.Revision);

            Console.WriteLine();

            Console.WriteLine("Is it in Global Cache? " + assembly.GlobalAssemblyCache);

            foreach (var module in assembly.GetModules())
            {
                Console.WriteLine("Module: "+module.Name);

                foreach (var type in module.GetTypes())
                {
                    Console.WriteLine("\tType: "+ type.FullName);

                    foreach (var member in type.GetMembers())
                    {
                        Console.Write("\t\tMember: "+ member.Name + "("+member.MemberType+ ")");

                        if(member.MemberType == MemberTypes.Property)
                        {
                            Console.Write(" Can read: {0}, Can write: {1}", (member as PropertyInfo).CanRead, (member as PropertyInfo).CanWrite);
                            Console.WriteLine(" Get: {0} Set: {1}", (member as PropertyInfo).GetMethod?.Name, (member as PropertyInfo).SetMethod?.Name);
                        }
                        else
                        {
                            Console.WriteLine();
                        }
                    }
                }
            }

        }
    }
}
