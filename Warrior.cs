using System.Threading.Tasks.Dataflow;

namespace RolePlayingGame {
    public class Warrior : Creature {
        //variabili aggiuntive a quelle della classe Creature
        private int    _modStrenght;
        private int    _modDexterity;
        private Weapon _weapon;
        private Armor  _armor;


        //costruttore
        public Warrior( string name, int strenght, int dexterity, int healthPoints, Weapon weapon,
                        Armor  armor )
            : base( name, strenght, dexterity, healthPoints ) {
            _weapon = weapon;
            _armor  = armor;

            _level = new LevelForWarrior();

            _modStrenght = (int) ( strenght * _level.StrenghtMultilier );
            if ( _weapon != null ) {
                _modStrenght += weapon.Damage;
            }

            _modDexterity = (int) ( dexterity * _level.DexterityMultiplier );
            if ( _armor != null ) {
                _modDexterity += armor.Protection;
            }

            _criticalHitChances = 5;
        }

        //nuova proprietà per Strenght, tiene conto anche dell'arma
        public new int Strenght => _modStrenght;

        //nuova proprietà per Dexterity, tiene conto anche dell'armatura
        public new int Dexterity => _modDexterity;


#region Fighting Methods

        /// <summary>
        /// Metodo per controllare se si verifica un colpo critico oppure no,
        /// Di default un guerriero ha il 5% di chance di effettuare un colpo critico
        /// </summary>
        protected override int CriticalHit( ) {
            return Fate.Next( 0, 101 ) < _criticalHitChances ? 2 : 1;
        }

        /// <summary>
        /// La creatura attacca un'altra creatura
        /// Restituisce i dati relativi all'attacco cioè:
        /// Risultati, danno effettuati e danni subiti -> AttackResult struct
        /// </summary>
        public override AttackResult Attack( Creature other ) {
            AttackResult result;
            if ( base.IsDead || base.IsUnconscious || other.IsDead || other.IsUnconscious ) {
                result = new AttackResult( Results.Failed, 0, 0 );
            }
            else {
                int res = other.Parry( Fate.Next( 0, Strenght + 1 ), CriticalHit(), this );
                if ( res > 0 ) {
                    result = new AttackResult( Results.Success, res, 0 );

                    //se il guerriero uccide la creatura nemica aumenta l'esperienza 
                    //e riceve la metà dei soldi che possedeva l'altra creatura (li ruba in fretta)
                    if ( other.IsDead || other.IsUnconscious ) {
                        _level.GainExperience( 10 * other.Level );
                        if ( _level.LevelUp() ) {
                            LevelUpCharacteristic();
                        }

                        _money += ( other.Money / 2 );
                    }
                }
                else if ( res < 0 ) {
                    result = new AttackResult( Results.ParryAndRiposte, 0, res * ( -1 ) );
                }
                else {
                    result = new AttackResult( Results.Parry, 0, 0 );
                }
                _weapon.ReduceIntegrity();
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
        public override int Parry( int damage, int criticalHit, Creature attacker ) {
            //il guerriero viene danneggiato
            if ( Dexterity < damage ) {
                damage *= criticalHit;
                damage -= Dexterity;
                DecreaseHealth( damage );
                return damage;
            }
            //il guerriero effettua un parry con riposte alla creatura avversaria
            else if ( Dexterity >= damage * 2 ) {
                return attacker.Riposte( damage ) * ( -1 );
            }
            //il guerriero effettua un parry all'attcco
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

#endregion

        /// <summary>
        /// Metodo che aumenta le caratteristiche in base al proprio moltiplicatore
        /// All'aumento di livello la vita viene ripristinata completamente
        /// </summary>
        protected override void LevelUpCharacteristic( ) {
            //aumento la variabile _modStrenght del guerriero secondo il moltiplicatore del livello
            _strenght = (int) ( base.Strenght * _level.StrenghtMultilier );
            _modStrenght = base.Strenght;
            if ( _weapon != null ) {
                _modStrenght += _weapon.Damage;
            }

            //aumento la variabile _modDexterity del guerriero secondo il moltiplicatore del livello
            _dexterity = (int) ( base.Dexterity * _level.DexterityMultiplier );
            _modDexterity = base.Dexterity;
            if ( _armor != null ) {
                _modDexterity += _armor.Protection;
            }

            //aumento la variabile HealthPoints e InitialHealthPoints riportando la vita al massimo prima
            InitialHealthPoints = (int) ( InitialHealthPoints * _level.HealthPointsMultiplier );
            HealthPoints        = InitialHealthPoints;
        }

        /// <summary>
        /// Metodo per riparare l'arma del guerriero totalmente
        /// </summary>
        public bool RepairWeapon( ) {
            if ( _money >= _weapon.CostForRepair ) {
                _money -= _weapon.CostForRepair;
                _weapon.Repair();
                return true;
            }

            return false;
        }

        public override string ToString( ) {
            return "Tipo:       Guerriero\n" + base.ToString();
        }
    }
}