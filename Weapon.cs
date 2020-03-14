namespace RolePlayingGame {
    public abstract class Weapon {
        private int    _damage;
        private int    _integrity;
        private double _cost;

        protected Weapon( int damage, int integrity, double cost ) {
            _damage    = damage;
            _integrity = integrity;
            _cost      = cost;
        }

        public int Damage => _integrity > 0 ? _damage : 0;

        public int Integrity => _integrity;

        public double Cost => _cost;
    }

    public class Sword : Weapon {
        public Sword( ) : base( 3, 500, 100f ) { }
    }
    
}