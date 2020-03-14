using System;

namespace RolePlayingGame {
    class Program {
        static void Main( string[] args ) {
            Goblin goblin1 = new Goblin( "kiko", 20, 10, 100 );
            Goblin goblin2 = new Goblin( "barausen", 17, 12, 70 );

            Console.WriteLine( goblin1 + "\n" );
            Console.WriteLine( goblin2 );
            //
            // Console.WriteLine( "\n\nAttacco 1 risultato: " +goblin1.Attack(goblin2)  );
            // Console.WriteLine( goblin1 +"\n" );
            // Console.WriteLine( goblin2 +"\n" );
            //
            // Console.WriteLine( "\n\nAttacco 2 risultato: " +goblin1.Attack(goblin2)  );
            // Console.WriteLine( goblin1 +"\n"  );
            // Console.WriteLine( goblin2 +"\n"  );
            //
            // Console.WriteLine( "\n\nAttacco 3 risultato: " +goblin1.Attack(goblin2)  );
            // Console.WriteLine( goblin1 +"\n"  );
            // Console.WriteLine( goblin2 +"\n"  );

            while ( goblin1.IsAlive && goblin2.IsAlive ) {
                Console.WriteLine( goblin1.Attack( goblin2 ) );
                Console.WriteLine( goblin2.Attack( goblin1 ) );
                Console.WriteLine( goblin1 +"\n" );
                Console.WriteLine( goblin2 +"\n\n\n");
            }

            Console.ReadKey();
        }
    }
}