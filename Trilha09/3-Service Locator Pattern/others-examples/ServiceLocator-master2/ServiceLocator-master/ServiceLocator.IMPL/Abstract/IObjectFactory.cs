using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLocator.IMPL.Abstract
{
    public interface IObjectFactory
    {
        object Create(Type type, object[] args );
        T Create<T>(object[] args);

    }
}
