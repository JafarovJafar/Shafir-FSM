namespace Shafir.FSM
{
    /// <summary>
    /// Состояние, которое может обновляться (т.е. выполнять какую-то логику каждый кадр)
    /// </summary>
    public interface ITickableState : IState
    {
        /// <summary>
        /// Обновить
        /// </summary>
        void Tick();
    }
}