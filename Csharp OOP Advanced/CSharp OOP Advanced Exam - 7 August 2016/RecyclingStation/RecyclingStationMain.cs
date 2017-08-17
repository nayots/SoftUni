using RecyclingStation.Core;
using RecyclingStation.IO;
using RecyclingStation.Models;
using RecyclingStation.Models.Factories;
using RecyclingStation.WasteDisposal;
using RecyclingStation.WasteDisposal.Interfaces;
using System;
using System.Collections.Generic;

namespace RecyclingStation
{
    public class RecyclingStationMain
    {
        private static void Main(string[] args)
        {
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();
            Dictionary<Type, IGarbageDisposalStrategy> strategies = new Dictionary<Type, IGarbageDisposalStrategy>();
            IStrategyHolder strategyHolder = new StrategyHolder(strategies);
            IGarbageProcessor garbageProcessor = new GarbageProcessor(strategyHolder);
            IWasteFactory wasteFactory = new WasteFactory();

            IGarbageManager garbageManager = new GarbageManager(garbageProcessor, wasteFactory);

            IEngine engine = new Engine(reader, writer, garbageManager);

            engine.Run();
        }
    }
}