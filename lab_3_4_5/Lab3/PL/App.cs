using BLL.Provider;
using PL.Controller;

namespace PL
{
    internal static class App
    {
        static void Main(string[] args)
        {
            DependencyProvider.Init();
            CommandExecutor.Execute();
        }
    }
}
