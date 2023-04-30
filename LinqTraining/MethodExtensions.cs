using SystemConsole = System.Console;

namespace LinqTraining.Extensions
{
    internal static class MethodExtensions
    {
        public static void Defend(this Wizard wizard, Wizard attacker)
        {
            SystemConsole.WriteLine("Je me défend...");
        }
    }
}
