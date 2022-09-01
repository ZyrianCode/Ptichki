#nullable enable
using MICS.Helpers.Abstractions.Loaders;
using MICS.Helpers.Abstractions.Utilities;
using MICS.Helpers.Behaviors.Abstractions.Behavior;
using MICS.Helpers.Core.Abstractions;

namespace MICS.Helpers.ManualInjection
{
    public class ManualInjectorFacade
    {
        private readonly ManualInjector _manualInjector;
        private readonly IBehavior? _utilityBehavior;
        private readonly IUtility? _utility;
        private readonly IRequestStore? _requestStore;
        public ManualInjectorFacade(IConnectionCredentials connectorCredentials,
                                    IUtility utility,
                                    IBehavior utilityBehavior,
                                    IRequestStore requestStore)
        {
            _requestStore = requestStore;
            _manualInjector = new ManualInjector(connectorCredentials, _requestStore);
            _utility = utility;
            _utilityBehavior = utilityBehavior;
        }

        public ILoader Inject()
        {
            ILoader loader = _manualInjector.InjectUtility(_utility!)
                .InjectConnectorComponents(_utilityBehavior!)
                .InjectProviderComponents()
                .InjectProviderToLoader()
                .CompleteInjection();

            return loader;
        }
    }
}
