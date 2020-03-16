using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace RolePlayingGame {
    class Program {
        static void Main( string[] args ) {
            // ArmyWar();
            TestLevels("goblin");
            Console.ReadKey();
            Console.WriteLine("\n\n\n");
            TestLevels("warrior");
        }

        private static void TestLevels( string type ) {
            if ( type == "goblin" ) {
                var goblin = new Goblin("tyrion", 100, 100, 50 );
                var goblins = new List<Creature>();
                for ( int i = 0; i < 10000000; i++ ) {
                    goblins.Add(new Goblin("Q",1,1,1)  );
                }

                int liv = 1;
                Console.WriteLine( goblin.Level );

                for ( int i = 0; i < 10000000; i++ ) {
                    goblin.Attack( goblins[i] );
                    if ( goblin.Level != liv ) {
                        Console.WriteLine( goblin.Level );
                        Console.WriteLine( goblin );
                        liv = goblin.Level;
                    }
                }
            }
            else if ( type == "warrior" ) {
                var warrior = new Warrior("tyrion", 100, 100, 50, new Sword(), new PlateArmor() );
                var goblins = new List<Creature>();
                for ( int i = 0; i < 10000000; i++ ) {
                    goblins.Add(new Goblin("Q",1,1,1)  );
                }

                int liv = 1;
                Console.WriteLine( warrior.Level );

                for ( int i = 0; i < 10000000; i++ ) {
                    warrior.Attack( goblins[i] );
                    if ( warrior.Level != liv ) {
                        Console.WriteLine( warrior.Level );
                        Console.WriteLine( warrior );
                        liv = warrior.Level;
                    }
                }
            }
            
        }

        private static void Fight( Creature a, Creature b ) {
            a.Attack( b );
            b.Attack( a );
        }

        private static void ArmyWar( ) {
            Random rnd = new Random();

            var army1 = new List<Creature>();
            var army2 = new List<Creature>();

            for ( int i = 0; i < 10; i++ ) {
                army1.Add( new Warrior( "tyrion", rnd.Next( 5, 10 ), rnd.Next( 2, 6 ), rnd.Next( 50, 100 ),
                                        new Sword(), new PlateArmor() ) );
                army2.Add( new Warrior( "bardock", rnd.Next( 5, 10 ), rnd.Next( 2, 6 ), rnd.Next( 50, 100 ),
                                        new Sword(), new PlateArmor() ) );
            }

            Console.WriteLine( "Armate fatte!" );

            while ( army1.Any( x => x.IsAlive ) && army2.Any( x => x.IsAlive ) ) {
                int num = army1.Count( x => x.IsAlive ) < army2.Count( x => x.IsAlive )
                              ? army1.Count( x => x.IsAlive )
                              : army2.Count( x => x.IsAlive );

                for ( int i = 0; i < num; i++ ) {
                    Fight( army1[i], army2[i] );
                }

                for ( int i = 0; i < army1.Count; i++ ) {
                    if ( !army1[i].IsAlive ) army1.RemoveAt( i );
                }

                for ( int i = 0; i < army2.Count; i++ ) {
                    if ( !army2[i].IsAlive ) army2.RemoveAt( i );
                }

                //Console.WriteLine( "Armata 1: " + army1.Count + " sopravissuti" );
                //Console.WriteLine( "Armata 2: " + army2.Count + " sopravissuti" );
            }

            if ( army1.Count > army2.Count ) {
                Console.WriteLine( "Ha vinto l'armata 1 con sopravissuti: " + army1.Count );
            }
            else {
                Console.WriteLine( "Ha vinto l'armata 2 con sopravissuti: " + army2.Count );
            }
        }
    }
}