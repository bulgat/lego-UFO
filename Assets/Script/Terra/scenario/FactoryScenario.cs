namespace ZedAngular.Model.Terra.scenario
{
    public class FactoryScenario
    {
        public IGridScenario GetFactoryScenario(int idScenario) {
            if (0== idScenario)
            {
                return new GridScenario();

            }
            if (1 == idScenario)
            {
                return new GridScenario1();
            }
            if (2 == idScenario)
            {
                return new GridScenario2();
            }
            if (3 == idScenario)
            {
                return new GridScenario3();
            }
            return new GridScenario4();
        }
    }
}
