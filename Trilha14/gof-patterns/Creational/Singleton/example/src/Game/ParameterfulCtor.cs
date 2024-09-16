using SingletonPattern.Singleton;

namespace Game 
{
    public class ParameterfulCtor : SingletonBase<ParameterfulCtor> 
    {
        private ParameterfulCtor(string x) 
        {

        }
    }
}