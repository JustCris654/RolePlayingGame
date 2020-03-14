namespace RolePlayingGame {
    
    /// <summary>
    /// Struct che riassume il risultato di un attacco
    /// Viene usata una variabile enum per le 4 possibili situazioni verificabili
    /// dopo un tentato attacco
    /// Oltre al risultato dell'attacco la struct contiene i danni effettuati alla creatura attaccata
    /// e i danni subiti dalla  creatura attaccante
    /// </summary>
    public struct AttackResult {
        private Results _result;
        private int     _damageDone;
        private int     _damageTaken;

        public AttackResult( Results result, int damageDone, int damageTaken ) {
            _result      = result;
            _damageDone  = damageDone;
            _damageTaken = damageTaken;
        }

        public Results Result => _result;

        public int DamageDone => _damageDone;

        public int DamageTaken => _damageTaken;

        public override string ToString( ) {
            return "Risultato:         " + Result     + "\n" +
                   "Danno  effettuato: " + DamageDone + "\n" +
                   "Danno preso:       " + DamageTaken;
        }
    }
    
    /// <summary>
    /// Variabile enumerativa che contiene i 4 possibili risultati di un attacco
    /// Quindi Success in caso l'attacco ha un esito positivo
    ///        Parry in caso l'attacco viene parato
    ///        ParryAndRiposte in caso l'attacco viene parato e si subisce un contrattacco
    ///        Failed in caso l'attacco non va a segno come nel caso in cui la creatura è
    ///        morta o svenuta 
    /// </summary>
    public enum Results {
        Success,
        Parry,
        ParryAndRiposte,
        Failed
    };
}