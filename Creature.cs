using System;
using System.Threading.Tasks.Dataflow;

namespace RolePlayingGame {
    public abstract class Creature {
#region variables

        protected        string _name;
        protected        int    _strenght;
        protected        int    _dexterity;
        protected        int    _healthPoints;
        protected        double _money;
        protected        Level  _level;
        protected        int    _initialHealthPoints;
        protected int _criticalHitChances;
        protected static Random Fate { get; } = new Random();

#endregion

        protected Creature( string name, int strenght, int dexterity, int healthPoints ) {
            _name                = name;
            _strenght            = strenght;
            _dexterity           = dexterity;
            _healthPoints        = healthPoints;
            _initialHealthPoints = _healthPoints;
        }

        public string Name => _name;

        public int Strenght => _strenght;

        public int Dexterity => _dexterity;

        public int HealthPoints {
            get => _healthPoints;
            set => _healthPoints = value;
        }

        public int InitialHealthPoints {
            get => _initialHealthPoints;
            set => _initialHealthPoints = value;
        }

        public double Money => _money;

        public int Level => _level.CreatureLevel;

        //colpo critico
        protected abstract int CriticalHit( );

        //attacco
        public abstract AttackResult Attack( Creature other );

        //parata
        public abstract int Parry( int damage, int criticalHit, Creature attacker );

        //risposta
        public abstract int Riposte( int damage );


        protected void DecreaseHealth( int damage ) {
            _healthPoints -= damage;
        }

        protected abstract void LevelUpCharacteristic( );

        public bool IsAlive => _healthPoints > 0; //se i punti vita sono maggiori di 0 è vivo

        public bool IsUnconscious => _healthPoints == 0; //se sono uguali a 0 è svenuto

        public bool IsDead => !IsAlive && !IsUnconscious; //se non è vivo nè svenuto è morto	

        public override string ToString( ) {
            return "Nome:       "  + _name        + "\n" +
                   "Forza:      "  + Strenght     + "\n" +
                   "Destrezza:  "  + Dexterity    + "\n" +
                   "Punti vita: "  + HealthPoints + "\n" +
                   "Stato       :" + ( IsAlive ? "Vivo" : IsUnconscious ? "Svenuto" : "Morto" );
        }
    }
}