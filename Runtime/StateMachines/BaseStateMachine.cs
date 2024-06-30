using UnityEngine.Events;

namespace Shafir.FSM
{
    /// <summary>
    /// Базовый класс для машины состояний
    /// </summary>
    /// <typeparam name="TState">Базовый тип состояния</typeparam>
    public abstract class BaseStateMachine<TState> where TState : IState
    {
        /// <summary>
        /// Конструктор
        /// </summary>
        public BaseStateMachine()
        {

        }

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="logMethod">Метод, с помощью которого будет происходить логирование</param>
        /// <remarks>
        /// Т.к. может понадобиться делать лог не с помощью стандартной консоли Unity,
        /// а с помощью сторонних решений (или может понадобиться логировать в файл),
        /// то сделано так, что сам метод логирования передается в конструктор
        /// </remarks>
        public BaseStateMachine(UnityAction<string> logMethod)
        {
            _logMethod = logMethod;
        }

        /// <summary>
        /// Текущее состояние
        /// </summary>
        public TState CurrentState { get; private set; }

        /// <summary>
        /// Предыдущее состояние
        /// </summary>
        public TState PreviousState { get; private set; }

        // Метод логирования
        private UnityAction<string> _logMethod;
        // Включено ли логирование
        private bool _isLogsEnabled;

        /// <summary>
        /// Сменить текущее состояние
        /// </summary>
        /// <param name="state"></param>
        public void ChangeState(TState state)
        {
            CurrentState?.Exit();
            PreviousState = CurrentState;
            CurrentState = state;
            CurrentState?.Enter();

            Log($"Сменил состояние. Предыдущее состояние: {PreviousState?.ToString()}; Текущее состояние{CurrentState}");
        }

        /// <summary>
        /// Включить логирование
        /// </summary>
        public void EnableLogs() => SetLogsEnableness(true);

        /// <summary>
        /// Выключить логирование
        /// </summary>
        public void DisableLogs() => SetLogsEnableness(false);

        // Установить активность логов
        private void SetLogsEnableness(bool isEnabled)
        {
            _isLogsEnabled = isEnabled;
        }

        /// <summary>
        /// Залогировать текущее состояние
        /// </summary>
        public void LogCurrentState()
        {
            Log($"Текущее состояние: {CurrentState?.ToString()}");
        }

        // Залогировать сообщение
        protected void Log(string message)
        {
            if (!_isLogsEnabled) return;
            if (_logMethod == null) return;
            _logMethod(message);
        }
    }
}