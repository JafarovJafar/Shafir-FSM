namespace Shafir.FSM
{
    /// <summary>
    /// Базовый интерфейс для всех состояний
    /// </summary>
    public interface IState
    {
        /// <summary>
        /// Вход в состояние
        /// </summary>
        void Enter();
        /// <summary>
        /// Выход из состояния
        /// </summary>
        void Exit();
    }
}