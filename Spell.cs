using System;
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

        public abstract AttackResult CastSpell( Sorcerer caster, Creature target );
    }

    public class FireBall : Spell {
        private int _damage;

        public FireBall( )
            : base( "FireBall", 1, 1 ) {
            _damage = 30;
        }

        public int Damage => _damage;

        /// <summary>
        /// E' ancora da rifinire e per ora la creatura attaccata non può difendersi
        /// </summary>
        public override AttackResult CastSpell( Sorcerer caster, Creature target ) {
            if ( caster.Mana >= _manaRequested ) {
                caster.Mana -= _manaRequested;
                var res = target.MagicalDamage( _damage * caster.Critical );
                return res;

            }
            return new AttackResult( Results.Failed, 0, 0 );;
        }
    }

    public class MagicShield : Spell {
        private int _protection;

        public MagicShield( )
            : base( "FireBall", 1, 1 ) {
            _protection = 2;
        }

        public int Protection => _protection;

        /// <summary>
        /// Da implementare che il mago casta lo scudo magico e la creatura target per
        /// qualche attacco ha una destrezza maggiorata, dopo essersi difesa da un certo numero
        /// di attacchi lo scudo magico sparisce
        /// </summary>
        public override AttackResult CastSpell( Sorcerer caster, Creature target ) {
            if ( caster.Mana >= _manaRequested ) {
                caster.Mana -= _manaRequested;
                if ( caster.DefenceCastedSpells[0] != 0 ) {
                    caster.DefenceCastedSpells[1] = 3;
                }
                caster.DefenceCastedSpells[0] += _protection;
                return new AttackResult( Results.Success, 0, 0 );;
            }

            return new AttackResult( Results.Failed, 0, 0 );;
        }
    }
}