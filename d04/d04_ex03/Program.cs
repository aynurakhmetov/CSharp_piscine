using System;

namespace d04_ex03
{
    class Program
    {
        static void Main(string[] args)
        {
            var instanceIdenUserCreatedWithConstructor = TypeFactory.CreateWithConstructor<IdentityUser>();
            var instanceIdenUserCreatedWithActivator = TypeFactory.CreateWithActivator<IdentityUser>();

            Console.WriteLine("d04_ex03.Models.IdentityUser");
            if (instanceIdenUserCreatedWithConstructor == instanceIdenUserCreatedWithActivator)
            {
                Console.WriteLine("user1 == user2" );
            }
            else
            {
                Console.WriteLine("user1 != user2");
            }
            
            var instanceIdenRoleCreatedWithConstructor = TypeFactory.CreateWithConstructor<IdentityRole>();
            var instanceIdenRoleCreatedWithActivator = TypeFactory.CreateWithActivator<IdentityRole>();
            
            Console.WriteLine("d04_ex03.Models.IdentityRole");
            if (instanceIdenRoleCreatedWithConstructor == instanceIdenRoleCreatedWithActivator)
            {
                Console.WriteLine("role1 == role2" );
            }
            else
            {
                Console.WriteLine("role1 != role2");
            }

            Console.WriteLine("\nd04_ex03.Models.IdentityUser");
            Console.WriteLine("Set name:");
            string userName = Console.ReadLine();
            object[] parametersForIdenUser = new object[1];
            parametersForIdenUser[0] = userName;
            
            var instanceIdenUserCreatedWithParameters =
                TypeFactory.CreateWithParameters<IdentityUser>(parametersForIdenUser);
            Console.WriteLine($"Username set: {instanceIdenUserCreatedWithParameters.UserName}");
        }
    }
}
