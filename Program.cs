using System;

namespace RolePlayingGame {
    class Program {
        static void Main( string[] args ) {
            Creature goblin1 = new Goblin( "kiko", 20, 10, 100 );
            Creature goblin2 = new Goblin( "barausen", 17, 12, 70 );

            Console.WriteLine( goblin1 + "\n" );
            Console.WriteLine( goblin2 );

            // while ( goblin1.IsAlive && goblin2.IsAlive ) {
            //     Console.WriteLine( goblin1.Attack( goblin2 ) );
            //     Console.WriteLine( goblin2.Attack( goblin1 ) );
            //     Console.WriteLine( goblin1 +"\n" );
            //     Console.WriteLine( goblin2 +"\n\n\n");
            // }
            
            

            Console.ReadKey();
        }
    }
}