using System;
using System.Threading.Tasks;
using MICS.Helpers.Abstractions.Loaders;
using MICS.Helpers.Behaviors.Abstractions.Behavior;
using MICS.Helpers.Core.Abstractions;
using MICS.Helpers.ManualInjection;
using MICS.Helpers.Utilities;
using MVVMEssentials.Commands.Async.Base;
using MVVMEssentials.ViewModels;
using Ptichki.Mappings.Tools.Connection;
using Ptichki.Tools.Connection.Db;

namespace Ptichki.Application.Micqrs.Db
{
    /// <summary>
    /// Асинхронная команда для Insert операций в бд.
    /// </summary>
    public class InsertCommand : AsyncCommandBase
    {
        private readonly IBehavior _utilityBehavior;
        private IConnectionCredentials _connectionCredentials;
        private readonly ViewModelBase _viewModel;
        private readonly IRequestStore _requestStore;
        private ILoader? _loader;

        /// <summary>
        /// Асинхронная команда для Insert операций в бд.
        /// </summary>
        public InsertCommand(ViewModelBase viewModel,
                             IRequestStore requestStore,
                             IBehavior utilityBehavior
                             )
        {
            _viewModel = viewModel;
            _requestStore = requestStore;
            _utilityBehavior = utilityBehavior;
           
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _viewModel.LoadingError = string.Empty;
            _viewModel.IsLoading = true;
            var url = "";
            
            var credentials = await ConnectionCredentialsDeserializer.DeserializeInfo(url);
            _connectionCredentials = credentials.ToData();


            _loader = new ManualInjectorFacade(_connectionCredentials,
                                               new UniversalUtility(),
                                               _utilityBehavior,
                                               _requestStore
                                               ).Inject();

            try
            {
                await _loader?.Load()!;
            }
            catch (Exception)
            {
                _viewModel.LoadingError = "Failed to load items.";
                throw;
            }
        }
    }
}
