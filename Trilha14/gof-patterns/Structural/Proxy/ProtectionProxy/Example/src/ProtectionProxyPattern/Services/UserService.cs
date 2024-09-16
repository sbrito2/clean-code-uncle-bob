using System;
using System.Threading;
using ProtectionProxyPattern.interfaces;

namespace ProtectionProxyPattern.Services
{
    public class UserService : IUserService
    {
        public UserService()
        {
            Console.WriteLine("criei");
            Thread.Sleep(2000);
        }


        //Request()
        public String Research()
        {
            return String.Format("consultei");
        }
    }
}