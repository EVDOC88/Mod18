using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mod18
{
    abstract class Command
    { // Абстрактные методы, которые надо в будущем перезаписать для различных команд
        public abstract void Run();
        public abstract void Cancel();
    }
}

