using System.Collections.Generic;
using System.Collections.ObjectModel;
using MVVMEssentials.ViewModels;

namespace Ptichki.Tools.Extensions.Collections
{
    public static class ObservableCollectionExtensions
    {
        public static void AddRange<T, G, TCollection>(this ObservableCollection<T> observableCollection,
            TCollection collection)
            where G : class
            where T : ViewModelBase, new()
            where TCollection : List<G>, ICollection<G>, IEnumerable<G>,
            IReadOnlyCollection<G>, IReadOnlyList<G>, IReadOnlySet<G>,
            IList<G>
        {
            foreach (var element in collection)
            {
                T viewModel = new()
                {
                    Property = element
                };

                observableCollection.Add(viewModel);
            }
        }
    }
}
