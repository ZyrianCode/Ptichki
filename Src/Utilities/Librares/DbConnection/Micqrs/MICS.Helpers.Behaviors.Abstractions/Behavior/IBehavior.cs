using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;

namespace MICS.Helpers.Behaviors.Abstractions.Behavior
{
    /// <summary>
    /// Интерфейс поведения.
    /// <remarks> Предоставляет контракт всем классам поведениям.
    ///           Является вторым уровнем абстракции.
    /// </remarks>
    /// </summary>
    public interface IBehavior
    {
        /// <summary>
        /// Метод второй уровень абстракции.
        /// </summary>
        /// <remarks> Позволяет выполнять задачу, абстрагируясь от подробностей методов первого уровня абстракции. </remarks>
        /// <returns> Перечисление объектов. </returns>
        public Task<IEnumerable<object>> Perform(SqlCommand command);
    }
}
