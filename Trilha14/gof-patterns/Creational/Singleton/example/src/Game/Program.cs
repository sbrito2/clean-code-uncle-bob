using Hes.Singleton.Example;
using SingletonPattern.Singleton;

namespace Game 
{
    internal static class Program 
    {
        private static readonly SingletonManager Manager = SingletonManager.Instance;

        private static void Main(string[] args) 
        {

            Manager.Register<WithPublicCtor>();
            Manager.Register<ParameterfulCtor>();
            Manager.Register<GameManager>();

            TryCatch.Do(() => {
                var publicCtor = Manager.Get<WithPublicCtor>();
                var str = publicCtor.ToString();
            });

            TryCatch.Do(() => {
                var parameterfulCtor = Manager.Get<ParameterfulCtor>();
                var str = parameterfulCtor.ToString();
            });

            TryCatch.Do(() => {
                var gameMager = Manager.Get<GameManager>();
                gameMager.Initialize();
                gameMager.Update();
            });
        }
    }
}