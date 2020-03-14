using System;
using System.Threading.Tasks.Dataflow;

namespace RolePlayingGame {
    public abstract class Creature {
        #region variables

        protected     string _name;
        protected     int    _strenght;
        protected     int    _dexterity;
        protected     int    _healthPoints;
        public static Random Fate { get; } = new Random();

        #endregion

        protected Creature( string name, int strenght, int dexterity, int healthPoints ) {
            _name         = name;
            _strenght     = strenght;
            _dexterity    = dexterity;
            _healthPoints = healthPoints;
        }

        #region methods

        //attacco
        public abstract AttackResult Attack( Creature other );

        //parata
        public abstract int Parry( int damage, Creature attacker );

        //risposta
        public abstract int Riposte( int damage );


        protected void DecreaseHealth( int damage ) {
            _healthPoints -= damage;
        }

        public bool IsAlive {
            get { return _healthPoints > 0; } //se i punti vita sono maggiori di 0 è vivo
        }

        public bool IsUnconscious {
            get { return _healthPoints == 0; } //se sono uguali a 0 è svenuto
        }

        public bool IsDead {
            get { return !IsAlive && !IsUnconscious; } //se non è vivo nè svenuto è morto	
        }

        public override string ToString( ) {
            return "Nome:       "  + _name         + "\n" +
                   "Forza:      "  + _strenght     + "\n" +
                   "Destrezza:  "  + _dexterity    + "\n" +
                   "Punti vita: "  + _healthPoints + "\n" +
                   "Stato       :" + ( IsAlive ? "Vivo" : IsUnconscious ? "Svenuto" : "Morto" );
        }

        #endregion
    }
}