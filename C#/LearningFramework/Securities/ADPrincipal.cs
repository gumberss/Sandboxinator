using System;
using System.Security.Permissions;
using System.Security.Principal;
using System.Threading;

namespace LearningFramework.Securities
{
    public class ADPrincipal
    {
        public void Process()
        {
            // Create a new thread with a generic principal.
            Thread t = new Thread(new ThreadStart(PrintPrincipalInformation));
            t.Start();
            t.Join();

            // Set the principal policy to WindowsPrincipal.
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);

            // The new thread will have a Windows principal representing the
            // current user.
            t = new Thread(new ThreadStart(PrintPrincipalInformation));
            t.Start();
            t.Join();

            // Create a principal to use for new threads.
            IIdentity identity = new GenericIdentity("NewUser");
            IPrincipal principal = new GenericPrincipal(identity, null);
            currentDomain.SetThreadPrincipal(principal);

            // Create a new thread with the principal created above.
            t = new Thread(new ThreadStart(PrintPrincipalInformation));
            t.Start();
            t.Join();

            // Wait for user input before terminating.
            Console.ReadLine();
        }

        private void PrintPrincipalInformation()
        {
            IPrincipal curPrincipal = Thread.CurrentPrincipal;
            if (curPrincipal != null)
            {
                Console.WriteLine("Type: " + curPrincipal.GetType().Name);
                Console.WriteLine("Name: " + curPrincipal.Identity.Name);
                Console.WriteLine("Authenticated: " +
                    curPrincipal.Identity.IsAuthenticated);
                Console.WriteLine();

                if (curPrincipal.Identity.Name == "DESKTOP-UVC3FPE\\GumBerS") 
                    ProtectedMethod();
            }
        }

        [PrincipalPermission(SecurityAction.Demand, Name = "DESKTOP-UVC3FPE\\GumBerS")]
        private void ProtectedMethod()
        {
            Console.WriteLine("Yes, you can it!!");
        }

    }
}
