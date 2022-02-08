using System;

namespace d04_ex02
{
    class Program
    {
        static void Main(string[] args)
        {
            var consoleSetter = new ConsoleSetter();
            
            var idUser = new IdentityUser();
            consoleSetter.SetValues(idUser);

            Console.WriteLine();

            var idRole = new IdentityRole();
            consoleSetter.SetValues(idRole);
        }
    }
}
