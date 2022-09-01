#nullable enable
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MICS.Helpers.Behaviors.Abstractions.Behavior;

namespace MICS.Helpers.Dispatchers
{
    public class BehaviorDispatcher
    {
        public Dictionary<Enum, IBehavior>? BehaviorHashTable;

        public static void CompleteBehaviorTable(Func<Task>? function) => 
            function?.Invoke();

        public IBehavior GetBehavior(Enum? utilityBehaviorType) => 
           BehaviorHashTable?[utilityBehaviorType!] ?? throw new InvalidOperationException();
    }
}
