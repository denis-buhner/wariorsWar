namespace WariorsWar
{
    internal class AstralGhostFactory : UnitFactory
    {
        public AstralGhostFactory(
            int unitHealth = 100,
            int unitDamage = 10,
            string unitDescription = "Астральный призрак - Способен игнорировать часть урона, но с некоторым шансом его урон также будет снижен",
            string name = "Астральный призрак")
            : base(unitHealth, unitDamage, unitDescription, name)
        {
        }

        public override Warior CreateWarior() => new AstralGhost(UnitHealth, UnitDamage, UnitDescription, UnitName);
    }
}
