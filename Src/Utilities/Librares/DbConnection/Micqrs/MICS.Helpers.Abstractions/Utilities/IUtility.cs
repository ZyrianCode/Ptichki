using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using MICS.Helpers.Behaviors.Abstractions.Behavior;

namespace MICS.Helpers.Abstractions.Utilities
{
    /// <summary>
    /// Интерфейс утилиты.
    /// <remarks> Предоставляет контракт для утилит, реализующих интерфейс.
    ///           Паттерн: Strategy, MICS.
    /// </remarks>
    /// </summary>
    public interface IUtility
    {
        /// <summary>
        /// Метод, позволяющий выполнять основную задачу утилиты, используя поведение утилиты.
        /// </summary>
        /// <param name="utilityBehavior"> - поведение утилиты. </param>
        /// <returns> Перечисление объектов. </returns>
        public Task<IEnumerable<object>?> PerformTask(IBehavior utilityBehavior);

        /// <summary>
        /// Алтернативный конструктор. Ленивый конструктор.
        /// </summary>
        /// <remarks> Используется для инжекта данных. </remarks>
        /// <param name="command"> - команда. </param>
        void SetDataComponents(SqlCommand? command);
    }
}
