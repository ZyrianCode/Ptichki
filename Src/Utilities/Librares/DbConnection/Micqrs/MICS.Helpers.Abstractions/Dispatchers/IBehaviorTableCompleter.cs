using System.Threading.Tasks;

namespace MICS.Helpers.Abstractions.Dispatchers
{
    /// <summary>
    /// Заполнятель хэш-таблицы поведений.
    /// <remarks> Задаёт контракт для классов, использующих хэш-диспетчеризацию.
    ///           Предоставляет метод заполнения хэш-таблицы / древа,
    ///           связывающую тип поведения и интерфейс класса поведения,
    ///           реализующего этот интерфейс.
    /// </remarks>
    /// </summary>
    public interface IBehaviorTableCompleter
    {
        /// <summary>
        /// Метод, заполняющий хэщ-таблицу / древо поведений.
        /// </summary>
        public Task CompleteBehaviorTable();
    }
}
