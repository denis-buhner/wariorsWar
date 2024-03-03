namespace WariorsWar
{
    internal class KingFactory : UnitFactory
    {
        public KingFactory(
            int unitHealth = 100,
            int unitDamage = 1,
            string unitDescription = "Король - не серьезный противник. Получает и наносит 1 еденицу урона. Хихихиха",
            string name = "Король")
            : base(unitHealth, unitDamage, unitDescription, name)
        {
        }

        public override Warior CreateWarior() => new King(UnitHealth, UnitDamage, UnitDescription, UnitName);
    }
}
