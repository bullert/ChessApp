using System;
using System.Collections.Generic;
using System.Text;

namespace Chess.Core
{
    public interface IModule
    {
        public IGame GameInstance { get; }
    }

    public abstract class Module : IModule
    {
        public Module(IGame instance)
        {
            GameInstance = instance;
        }
        
        public IGame GameInstance { get; }
    }
}
