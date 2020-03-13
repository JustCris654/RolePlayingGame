using System;
using System.Threading.Tasks.Dataflow;

namespace RolePlayingGame {
	public abstract class Creature {
		#region variables

		protected     string _name;
		protected     int    _strenght;
		protected     int    _dexterity;
		protected     int    _healthPoints;
		public static Random Fate { get; }

		#endregion

		protected Creature ( string name, int strenght, int dexterity, int healthPoints ) {
			_name         = name;
			_strenght     = strenght;
			_dexterity    = dexterity;
			_healthPoints = healthPoints;
		}

		#region methods

		public abstract bool Attack ( Creature other );

		public abstract bool Deflect ( int damage );

		public void DecreaseHealth ( int damage ) {
			_healthPoints -= damage - _dexterity;
		}

		public bool IsAlive {
			get { return _healthPoints > 0; } //se i punti vita sono maggiori di 0 è vivo
		}

		public bool IsUnconscious {
			get { return _healthPoints == 0; } //se sono uguali a 0 è svenuto
		}

		public bool IsDead {
			get { return !IsAlive && !IsUnconscious; } //se non è vivo nè svenuto è morto	
		}

		public override string ToString ( ) {
			return "Nome:       "  + _name         + "\n" +
			       "Forza:      "  + _strenght     + "\n" +
			       "Destrezza:  "  + _dexterity    + "\n" +
			       "Punti vita: "  + _healthPoints + "\n" +
			       "Stato       :" + ( IsAlive ? "Vivo" : IsUnconscious ? "Svenuto" : "Morto" );
		}

		#endregion
	}
}