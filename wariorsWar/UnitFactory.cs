namespace WariorsWar
{
    internal abstract class UnitFactory
    {
        public UnitFactory(int unitHealth, int unitDamage, string unitDescription, string unitName)
        {
            UnitHealth = unitHealth;
            UnitDamage = unitDamage;
            UnitDescription = unitDescription;
            UnitName = unitName;
        }

        public string UnitDescription { get; }

        public string UnitName { get; }

        public int UnitDamage { get; }

        public int UnitHealth { get; }

        public abstract Warior CreateWarior();
    }
}
