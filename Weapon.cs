namespace RolePlayingGame {
    public abstract class Weapon {
        private   int    _damage;
        private   int    _initialIntegrity;
        private   int    _integrity;
        private   double _cost;
        protected double _costForRepair;

        protected Weapon( int damage, int integrity, double cost ) {
            _damage           = damage;
            _initialIntegrity = integrity;
            _integrity        = integrity;
            _cost             = cost;
            _costForRepair    = cost / 2; //sucessivamente si può integrare un sistema di costo per il riparo migliore
        }


        //proprietà che restituisce la difesa aggiuntiva di un'arma 
        public int Damage => _integrity > 0 ? _damage : 0;

        //proprietà per l'integrità
        public int Integrity => _integrity;

        //proprietà per il costo
        public double Cost => _cost;
        
        //proprietà per il costo per riparare
        public double CostForRepair => _costForRepair;

        //Ripara completamente l'armatura
        public void Repair( ) {
            _integrity = _initialIntegrity;
        }
    }

    public class Sword : Weapon {
        public Sword( ) : base( 3, 500, 100f ) {
        }
    }
}