namespace Shafir.FSM
{
    /// <summary>
    /// Базовый класс для машины состояний
    /// </summary>
    /// <typeparam name="TState">Базовый тип состояния</typeparam>
    public abstract class BaseStateMachine<TState> where TState : IState
    {
        /// <summary>
        /// Текущее состояние
        /// </summary>
        public TState CurrentState { get; private set; }

        /// <summary>
        /// Сменить текущее состояние
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState(TState state)
        {
            CurrentState?.Exit();
            CurrentState = state;
            CurrentState?.Enter();
        }
    }
}