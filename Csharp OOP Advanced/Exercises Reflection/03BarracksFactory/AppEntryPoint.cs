namespace _03BarracksFactory
{
    using Autofac;
    using Contracts;
    using Core;
    using Core.Factories;
    using Data;

    class AppEntryPoint
    {
        private static void Main(string[] args)
        {
            IRepository repository = new UnitRepository();
            IUnitFactory unitFactory = new UnitFactory();
            ContainerBuilder container = new ContainerBuilder();

            IRunnable engine = new Engine(repository, unitFactory, container);
            engine.Run();
        }
    }
}