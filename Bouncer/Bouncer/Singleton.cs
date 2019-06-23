namespace BrutalHack.Bouncer
{
    public partial class Bouncer : IBouncer
    {
        private static Bouncer _instance;

        public static Bouncer Instance => _instance ?? (_instance = new Bouncer());
    }
}