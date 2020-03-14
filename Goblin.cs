using System;

namespace RolePlayingGame {
    public class Goblin : Creature {
        public Goblin( string name, int strenght, int dexterity, int healthPoints )
            : base( name, strenght, dexterity, healthPoints ) {
        }


        /// <summary>
        /// La creatura attacca un'altra creatura
        /// Restituisce i dati relativi all'attacco cioè:
        /// Risultati, danno effettuati e danni subiti -> AttackResult struct
        /// </summary>
        public override AttackResult Attack( Creature other ) {
            AttackResult result;
            if ( base.IsDead || base.IsUnconscious ) {
                result = new AttackResult( Results.Failed, 0, 0 );
            }
            else {
                int res = other.Parry( Fate.Next( 0, _strenght + 1 ), this );
                if ( res      > 0 ) result = new AttackResult( Results.Success, res, 0 );
                else if ( res < 0 ) result = new AttackResult( Results.ParryAndRiposte, 0, res * ( -1 ) );
                else result                = new AttackResult( Results.Parry, 0, 0 );
            }

            return result;
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
                damage -= _dexterity;
                DecreaseHealth( damage );
                return damage;
            }
            //il goblin effettua un parry con riposte alla creatura avversaria
            else if ( _dexterity >= damage * 2 ) {
                return attacker.Riposte( damage ) * ( -1 );
            }
            //il goblin effettua un parry all'attcco
            else {
                return 0;
            }
        }

        /// <summary>
        /// Questo metodo decrementa la vita della creatura che ha ricevuta una deflezione del danno
        /// e ritorna il valore del danno
        /// </summary>
        public override int Riposte( int damage ) {
            damage = (int) ( damage * 1.5f );
            DecreaseHealth( damage );
            return damage;
        }

        public override string ToString( ) {
            return "Tipo:       Goblin\n" + base.ToString();
        }
    }
}