using System;
using SingletonPattern.Singleton;

namespace Game 
{
    public class GameManager : SingletonBase<GameManager> 
    {

        private GameManager() 
        {

        }

        public void Initialize() 
        {
            Console.WriteLine($"{nameof(GameManager)} is initialized...");
        }

        public void Update() 
        {
            Console.WriteLine($"Calling Update...");
        }
    }
}