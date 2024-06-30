using UnityEngine;
using Shafir.FSM;

public class SimpleTestEntryPoint : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Transform _goalPosTransform;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _collider;

    private SimpleState1 _state1;
    private SimpleState2 _state2;
    private SimpleStateMachine _stateMachine;

    private void Start()
    {
        _state1 = new SimpleState1
        (
            _transform,
            _rigidbody,
            _collider,
            _particle,
            _goalPosTransform.position
        );

        _state2 = new SimpleState2
        (
            _rigidbody,
            _collider
        );

        _stateMachine = new SimpleStateMachine(Log);
        _stateMachine.EnableLogs();

        _stateMachine.ChangeState(_state1);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            _stateMachine.ChangeState(_state1);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            _stateMachine.ChangeState(_state2);
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            _stateMachine.LogCurrentState();
        }
    }

    private void Log(string message)
    {
        Debug.Log(message, gameObject);
    }
}