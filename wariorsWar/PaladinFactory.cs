namespace WariorsWar
{
    internal class PaladinFactory : UnitFactory
    {
        public PaladinFactory(
            int unitHealth = 100,
            int unitDamage = 10,
            string unitDescription = "Паладин - обладает внушительной броней и большим запасом здоровья, стабильно наносит небольшой урон.",
            string name = "Паладин")
            : base(unitHealth, unitDamage, unitDescription, name)
        {
        }

        public override Warior CreateWarior() => new Paladin(UnitHealth, UnitDamage, UnitDescription, UnitName);
    }
}
