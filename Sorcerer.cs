using System.Collections.Generic;
using System.Linq;

namespace RolePlayingGame {
    public class Sorcerer : Creature {
        private int         _mana;
        private List<Spell> _castableSpellsAttack;
        private List<Spell> _castableSpellsDefence;
        private List<int>   _defenceCastedSpells;
        private int _manaRegen;
        private int _maxMana;

        public Sorcerer( string name, int strenght, int dexterity, int healthPoints, int mana )
            : base( name, strenght, dexterity, healthPoints ) {
            _mana           = mana;
            _castableSpellsAttack = new List<Spell>();
            _castableSpellsDefence = new List<Spell>();
            //ogni mago puo lanciare la palla di fuoco quindi la aggiungo di default
            _castableSpellsAttack.Add( new FireBall() );
            //ogni mago puo creare uno scudo  quindi lo aggiungo di default
            _castableSpellsDefence.Add( new MagicShield() );

            _defenceCastedSpells = new List<int>(){0,0};
            _criticalHitChances  = 3;
            _maxMana = mana;
            _manaRegen = 20;
        }


        public int Mana {
            get => _mana;
            set => _mana = value;
        }

        public new int Dexterity => base.Dexterity + DefenceCastedSpells[0];

        public List<int> DefenceCastedSpells {
            get => _defenceCastedSpells;
            set => _defenceCastedSpells = value;
        }

        public void AddSpellAttack( Spell spell ) {
            _castableSpellsAttack.Add( spell );
        }
        
        public void AddSpellDefence( Spell spell ) {
            _castableSpellsDefence.Add( spell );
        }

        public void ManaRegen( ) {
            if ( Mana <= _maxMana - _manaRegen ) {
                Mana += _manaRegen;
            }
        }

        
        /// <summary>
        /// Metodo da ridefinire, la creatura attaccata non puo difendersi 
        /// </summary>
        public override AttackResult MagicalDamage( int damage ) {
            DecreaseHealth( damage - Dexterity );

            if ( --DefenceCastedSpells[1] <= 0 ) {
                DefenceCastedSpells[0] = 0;
            }
            var result = new AttackResult( Results.Success, damage, 0 );
            return result;
        }

        protected override int CriticalHit( ) {
            return Fate.Next( 0, 101 ) < _criticalHitChances ? 3 : 1;
        }

        public int Critical => CriticalHit();

        protected override void LevelUpCharacteristic( ) {
            Mana = _maxMana;
            Mana                 = (int) ( Mana                 * _level.StrenghtMultilier );
            _dexterity           = (int) ( Dexterity            * _level.DexterityMultiplier );
            _initialHealthPoints = (int) ( _initialHealthPoints * _level.HealthPointsMultiplier );
            _healthPoints        = _initialHealthPoints;
        }

        public override AttackResult Attack( Creature other ) {
            ManaRegen();
            //return _castableSpells[Fate.Next( 0, _castableSpells.Count - 1 )].CastSpell( this, other );
            if ( Fate.Next( 0, 2 ) == 0 ) {
                return _castableSpellsAttack[Fate.Next( 0, _castableSpellsAttack.Count - 1 )].CastSpell( this, other );
            }
            else {
                return _castableSpellsDefence[Fate.Next( 0, _castableSpellsDefence.Count - 1 )].CastSpell( this, this );
            }
        }

        //non ha senso implementarlo
        public override int Riposte( int damage ) {
            throw new System.NotImplementedException();
        }


        //non ha senso implementarlo
        public override int Parry( int damage, int criticalHit, Creature attacker ) {
            throw new System.NotImplementedException();
        }

    }
}