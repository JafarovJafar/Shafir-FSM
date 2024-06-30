namespace Shafir.FSM
{
    /// <summary>
    /// Машина состояний для состояний, которые могут обновляться каждый кадр
    /// </summary>
    public class TickableStateMachine : BaseStateMachine<ITickableState>
    {
        /// <summary>
        /// Обновить текущее состояние
        /// </summary>
        public void Tick() => CurrentState?.Tick();
    }
}