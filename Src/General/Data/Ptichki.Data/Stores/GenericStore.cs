using System;
using System.Collections.Generic;

namespace Ptichki.Data.Stores
{
    public class GenericStore<TModel>
    {
        public event Action<TModel> SingleModelAdded;
        public event Action<IEnumerable<TModel>> MultipleModelAdded;
        public event Action OperationCompleted;

        public void AddSingleModel(TModel model)
        {
            SingleModelAdded?.Invoke(model);
        }

        public void AddMultipleModel(IEnumerable<TModel> model)
        {
            MultipleModelAdded?.Invoke(model);
        }

        public void OperationComplete()
        {
            OperationCompleted?.Invoke();
        }
    }
}
