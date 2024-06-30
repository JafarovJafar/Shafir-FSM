using UnityEngine.Events;

namespace Shafir.FSM
{
    /// <summary>
    /// Простая машина состояний для состояний, которые имеют только методы входа и выхода
    /// </summary>
    public class SimpleStateMachine : BaseStateMachine<IState>
    {
        public SimpleStateMachine(UnityAction<string> logMethod) : base(logMethod)
        {
        }
    }
}