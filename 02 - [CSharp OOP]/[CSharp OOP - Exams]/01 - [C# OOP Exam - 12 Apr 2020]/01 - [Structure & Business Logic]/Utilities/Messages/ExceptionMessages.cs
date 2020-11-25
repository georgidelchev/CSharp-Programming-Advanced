namespace CounterStrike.Utilities.Messages
{
    public static class ExceptionMessages
    {
        public const string InvalidPlayerName = "Username cannot be null or empty.";

        public const string InvalidPlayerHealth = "Player health cannot be below or equal to 0.";

        public const string InvalidPlayerArmor = "Player armor cannot be below 0.";

        public const string InvalidGun = "Gun cannot be null or empty.";

        public const string InvalidGunBulletsCount = "Bullets cannot be below 0.";

        public const string InvalidGunName = "Gun cannot be null or empty.";

        public const string InvalidGunRepository = "Cannot add null in Gun Repository.";

        public const string InvalidPlayerRepository = "Cannot add null in Player Repository.";

        public const string InvalidPlayerType = "Invalid player type!";

        public const string InvalidGunType = "Invalid gun type!";

        public const string GunCannotBeFound = "Gun cannot be found!";
    }
}
