using System;

namespace RolePlayingGame {
    public class Goblin : Creature {
        public Goblin( string name, int strenght, int dexterity, int healthPoints )
            : base( name, strenght, dexterity, healthPoints ) {
        }


        /// <summary>
        /// La creatura attacca un'altra creatura
        /// Restituisce 0 se l'attacco è andato a buon fine
        /// Restituisce 1 se l'attacco è stato parato
        /// Restituisce 2 se l'attacco è stato parato e deflesso
        /// </summary>
        public override int Attack( Creature other ) {
            Random rnd = new Random();
            return other.Parry( Fate.Next( 0, _dexterity + 1 ), this );
        }


        /// <summary>
        /// Questo metodo serve a determinare il successo o no di una parata-deflezione
        /// Se il danno è maggiore alla destrezza la creatura non deflette o para il danno ma viene colpita
        /// Se la destrezza è maggiore al danno la parata viene eseguita
        /// Se la destrezza è un valore doppio o maggiore del doppio del danno viene eseguita anche una deflezione
        /// che consite nel danneggiare l'avversario con i suoi stessi danni moltiplicati per 1,5
        /// </summary>
        public override int Parry( int damage, Creature attacker ) {
            //il goblin viene danneggiato
            if ( _dexterity < damage ) {
                DecreaseHealth( damage - _dexterity );
                return 0;
            }
            //il goblin effettua un parry con riposte alla creatura avversaria
            else if ( _dexterity >= damage * 2 ) {
                attacker.Riposte( damage );
                return 2;
            }
            //il goblin effettua un parry all'attcco
            else {
                return 1;
            }
        }

        /// <summary>
        /// Questo metodo decrementa la vita della creatura che ha ricevuta una deflezione del danno
        /// </summary>
        public override void Riposte( int damage ) {
            DecreaseHealth( (int) ( damage * 1.5f ) );
        }

        public override string ToString( ) {
            return "Tipo:       Goblin\n" + base.ToString();
        }
    }
}