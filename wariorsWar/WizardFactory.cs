namespace WariorsWar
{
    internal class WizardFactory : UnitFactory
    {
        public WizardFactory(
            int unitHealth = 75,
            int unitDamage = 15,
            string unitDescription = "Волшебник - имеет скромный запас здоровья, но большой урон. способен увеличивать свой урон за счет манны.",
            string name = "Маг")
            : base(unitHealth, unitDamage, unitDescription, name)
        {
        }

        public override Warior CreateWarior() => new Wizard(UnitHealth, UnitDamage, UnitDescription, UnitName);
    }
}
