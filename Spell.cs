using System.IO;

namespace RolePlayingGame {
    public abstract class Spell {
        protected string _name;
        protected int    _levelRequired;
        protected int    _manaRequested;

        protected Spell( string name, int levelRequired, int manaRequested ) {
            _name          = name;
            _levelRequired = levelRequired;
            _manaRequested = manaRequested;
        }

#region Properties

        public int LevelRequired => _levelRequired;

        public int ManaRequested => _manaRequested;

#endregion

        public bool IsCastable( Sorcerer sorcerer ) {
            return sorcerer.Level >= LevelRequired;
        }

        public abstract bool CastSpell( Sorcerer caster, Creature target );
    }

    public class FireBall : Spell {
        private int _damage;

        public FireBall( )
            : base( "FireBall", 1, 1 ) {
            _damage = 14;
        }

        /// <summary>
        /// E' ancora da rifinire e per ora la creatura attaccata non può difendersi
        /// </summary>
        public override bool CastSpell( Sorcerer caster, Creature target ) {
            if ( caster.Mana >= _manaRequested ) {
                target.MagicalDamage( _damage );
                return true;
            }

            return false;
        }
    }

    public class MagicShield : Spell {
        private int _protection;

        public MagicShield( )
            : base( "FireBall", 1, 1 ) {
            _protection = 20;
        }

        /// <summary>
        /// Da implementare che il mago casta lo scudo magico e la creatura target per
        /// qualche attacco ha una destrezza maggiorata, dopo essersi difesa da un certo numero
        /// di attacchi lo scudo magico sparisce
        /// </summary>
        public override bool CastSpell( Sorcerer caster, Creature target ) {
            return true;
        }
    }
}