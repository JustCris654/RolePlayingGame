using System.Collections.Generic;

namespace RolePlayingGame {
    public class Sorcerer : Creature {
        private int         _mana;
        private List<Spell> _castableSpells;
        private List<int>   _defenceCastedSpells;

        public Sorcerer( string      name,           int       strenght, int dexterity, int healthPoints, int mana,
                         List<Spell> castableSpells, List<int> defenceCastedSpells )
            : base( name, strenght, dexterity, healthPoints ) {
            _mana                = mana;
            _castableSpells      = castableSpells;
            _defenceCastedSpells = defenceCastedSpells;
        }

        public int Mana {
            get => _mana;
            set => _mana = value;
        }


#region Metodi da implementare
        
        //metodi che devo ancora implementare
        
        /// <summary>
        /// Metodo da ridefinire, la creatura attaccata non puo difendersi 
        /// </summary>
        public override AttackResult MagicalDamage( int damage ) {
            DecreaseHealth( damage - _dexterity );
            var result = new AttackResult( Results.Success, damage, 0 );
            return result;
        }
        
        protected override int CriticalHit( ) {
            throw new System.NotImplementedException();
        }

        public override AttackResult Attack( Creature other ) {
            throw new System.NotImplementedException();
        }

        public override int Riposte( int damage ) {
            throw new System.NotImplementedException();
        }

        protected override void LevelUpCharacteristic( ) {
            throw new System.NotImplementedException();
            
        }

        public override int Parry( int damage, int criticalHit, Creature attacker ) {
            throw new System.NotImplementedException();
        }
        
        //fine metodi che devo ancora implementare
        
#endregion
    }
}