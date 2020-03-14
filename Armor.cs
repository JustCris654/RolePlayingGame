namespace RolePlayingGame {
    public abstract class Armor {
        private int    _protection;
        private int    _integrity;
        private double _cost;

        protected Armor( int protection, int integrity, double cost ) {
            _protection = protection;
            _integrity  = integrity;
            _cost       = cost;
        }

        public int Protection => _integrity > 0 ? _protection : 0;

        public int Integrity => _integrity;

        public double Cost => _cost;
    }

    public class PlateArmor : Armor {
        public PlateArmor(  ) : base( 3, 1000, 1000f ) {
        }
    }
}