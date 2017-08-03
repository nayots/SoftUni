namespace _03BarracksFactory.Core
{
    using _03BarracksFactory.Attributes;
    using _03BarracksFactory.Core.Commands;
    using _03BarracksFactory.Core.Factories;
    using _03BarracksFactory.Data;
    using Autofac;
    using Contracts;
    using System;
    using System.Linq;
    using System.Reflection;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;
        private ContainerBuilder ioc;
        private IContainer container;

        public Engine(IRepository repository, IUnitFactory unitFactory, ContainerBuilder container)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
            this.ioc = container;
        }

        public void Run()
        {
            this.ioc.RegisterType<UnitRepository>().As<IRepository>();
            this.ioc.RegisterType<UnitFactory>().As<IUnitFactory>();
            this.ioc.RegisterType<IExecutable>().AsImplementedInterfaces();
            this.ioc.RegisterType<AddCommand>().Named<IExecutable>("Add");
            this.ioc.RegisterType<FightCommand>().Named<IExecutable>("Fight");
            this.ioc.RegisterType<ReportCommand>().Named<IExecutable>("Report");
            this.ioc.RegisterType<RetireCommand>().Named<IExecutable>("Retire");

            this.ioc.RegisterInstance(this.repository);
            this.ioc.RegisterInstance(this.unitFactory);

            this.container = this.ioc.Build();

            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private string InterpredCommand(string[] data, string commandName)
        {
            //Using autofac works like a charm but since softuni judge has a limit of 16kb per zip file it is not possible to send the solution to this problem using an IOC/DI container
            //This gives the correct answers but for judge it has to be done using the InjectDependencies method and by modifying the commands so that they only accept string[] data as a param.

            string result = string.Empty;
            commandName = char.ToUpper(commandName[0]) + commandName.Substring(1);

            Type commandType = Type.GetType("_03BarracksFactory.Core.Commands." + commandName + "Command");

            IExecutable cmd = (IExecutable)this.container.ResolveNamed(commandName, typeof(IExecutable), new NamedParameter("data", data));

            result = cmd.Execute();

            return result;
        }

        [Obsolete]
        private IExecutable InjectDependencies(IExecutable command)
        {
            FieldInfo[] commandFields = command.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            FieldInfo[] engineFields = this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic);

            foreach (var field in commandFields)
            {
                var fieldAttribute = field.GetCustomAttribute(typeof(InjectAttribute));

                if (fieldAttribute != null)
                {
                    if (engineFields.Any(f => f.FieldType == field.FieldType))
                    {
                        field.SetValue(command, engineFields.First(f => f.FieldType == field.FieldType).GetValue(this));
                    }
                }
            }

            return command;
        }
    }
}