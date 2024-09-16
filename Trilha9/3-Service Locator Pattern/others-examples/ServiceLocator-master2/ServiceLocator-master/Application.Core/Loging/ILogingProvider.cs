using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Core.Loging
{
    interface ILogingProvider
    {
        void Log(string message);
        void Log(string message,LogLevelCategory logLevelCategory);
    }
}
