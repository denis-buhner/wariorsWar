namespace WariorsWar
{
    internal class SpikeFactory : UnitFactory
    {
        public SpikeFactory(
            int unitHealth = 100,
            int unitDamage = 10,
            string unitDescription = "Колючка - нанесенный ему урон частично добавляется к его основному.",
            string name = "Колючка")
            : base(unitHealth, unitDamage, unitDescription, name)
        {
        }

        public override Warior CreateWarior() => new Spike(UnitHealth, UnitDamage, UnitDescription, UnitName);
    }
}
