namespace RolePlayingGame {
    public abstract class Armor {
        private int    _protection;
        private int    _initialIntegrity;
        private int    _integrity;
        private double _cost;

        protected Armor( int protection, int integrity, double cost ) {
            _protection       = protection;
            _initialIntegrity = integrity;
            _integrity        = integrity;
            _cost             = cost;
        }

        //proprietà che restituisce la difesa aggiuntiva di un'arma 
        public int Protection => _integrity > 0 ? _protection : 0;

        //proprietà per l'integrità
        public int Integrity => _integrity;

        //proprietà per il costo
        public double Cost => _cost;

        //riduce l'integrità dell'arma ad ogni attacco
        public void ReduceIntegrity( ) {
            _integrity--;
        }

        //Ripara completamente l'armatura
        public void Repair( ) {
            _integrity = _initialIntegrity;
        }
    }

    /// <summary>
    /// Classe derivata da Armor
    /// Rappresenta un'armatura a piastre 
    /// </summary>
    public class PlateArmor : Armor {
        public PlateArmor( )
            : base( 3, 1000, 1000 ) {
        }
    }
}