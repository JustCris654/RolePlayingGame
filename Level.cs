namespace RolePlayingGame {
    /// <summary>
    /// Classe astratta per la gestione dei livelli
    /// Per ora il sistema di potenziamento è base base
    /// e ovviamente si può migliorare ed equilibrare in futuro
    /// </summary>
    public abstract class Level {
        protected int _level;            //livello attuale della creatura
        protected long _experience;       //esperienza 
        protected long _expToLevel;       //esperienza necessaria a raggiungere il prossimo livello

        protected double _strenghtMultilier;        //moltiplicatore della forza
        protected double _dexterityMultiplier;      //moltiplicatore della destrezza
        protected double _healthPointsMultiplier;   //moltiplicatore della vita

        //costruttore
        protected Level( ) {
            _level                  = 0;
            _experience             = 0;
            _expToLevel             = 100;
            _strenghtMultilier      = 1;
            _dexterityMultiplier    = 1;
            _healthPointsMultiplier = 1;
        }

        public void GainExperience( int exp ) {
            _experience += exp;
        }

        public int CreatureLevel => _level;

        public double StrenghtMultilier => _strenghtMultilier;

        public double DexterityMultiplier => _dexterityMultiplier;

        public double HealthPointsMultiplier => _healthPointsMultiplier;


        /// <summary>
        /// Metodo per il levelling up
        /// Se la creatura ha abbastanza esperienza livella automaticamente
        /// Il cap del livello delle creature è il 10
        /// Vengono incrementate le caratteristiche di:
        /// Strenght -> 10%
        /// Dexterity -> 10%
        /// HealthPoints -> 20%
        /// L'esperienza non viene azzerata ma si usa solo quella che serve
        /// L'esperienza necessaria per raggiungere il prossimo livello
        /// è 20 volte maggiore a quella del livello prima
        /// </summary>
        public bool LevelUp( ) {
            if ( _experience < _expToLevel || _level == 10 ) return false;
            _level++;
            _strenghtMultilier      += 0.1f;
            _dexterityMultiplier    += 0.1f;
            _healthPointsMultiplier += 0.2f;
            _experience             -= _expToLevel;
            _expToLevel             *= 20;
            return true;
        }
    }
    
    /// <summary>
    /// Per ora è inutile come classe per serve per aggiungerci in futuro
    /// estensioni del livello massimo ad alcune specifiche classi
    /// o trasformazioni particolari che modificano in modo diverso i
    /// moltiplicatori
    /// Esempio: un goblin diventa re goblin dopo aver guadagnato 1
    /// </summary>
    public class LevelForWarrior : Level {
        
    }
    
    
    
}