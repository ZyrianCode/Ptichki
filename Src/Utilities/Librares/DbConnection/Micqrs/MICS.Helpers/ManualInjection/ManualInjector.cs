#nullable enable
using MICS.Helpers.Abstractions.Connectors;
using MICS.Helpers.Abstractions.Loaders;
using MICS.Helpers.Abstractions.Providers;
using MICS.Helpers.Abstractions.Utilities;
using MICS.Helpers.Behaviors.Abstractions.Behavior;
using MICS.Helpers.Connectors;
using MICS.Helpers.Core.Abstractions;
using MICS.Helpers.Loaders;
using MICS.Helpers.Providers;

namespace MICS.Helpers.ManualInjection
{
    public class ManualInjector
    {
        private IItemsProvider? _itemsProvider;
        private ILoader? _loader;
        private IUtility? _utility;
        private IConnector? _connector;
        private readonly IConnectionCredentials? _connectorCredentials;
        private readonly IRequestStore? _requestStore;

        public ManualInjector(IConnectionCredentials connectorCredentials,
                              IRequestStore requestStore)
        {
            _connectorCredentials = connectorCredentials;
            _requestStore = requestStore;
        }
        public ManualInjector InjectUtility(IUtility utility) //1-ый
        {
            _utility = utility;
            return this;
        }
        public ManualInjector InjectConnectorComponents(IBehavior utilityBehaviorType) //2-ой
        {
            _connector = new Connector(_utility!, utilityBehaviorType, _requestStore);
            return this;
        }

        public ManualInjector InjectProviderComponents() //3-ый
        {
            _itemsProvider = new ItemsProvider(_connector!,
                                               _connectorCredentials!
                                              );
            return this;
        }

        public ManualInjector InjectProviderToLoader() //4-ый
        {
            _loader = new Loader(_itemsProvider!);
            return this;
        }

        public ILoader CompleteInjection() => _loader!;
    }
}
