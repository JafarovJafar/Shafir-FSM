using UnityEngine;
using Shafir.FSM;

public class TickableTestEntryPoint : MonoBehaviour
{
    [SerializeField] private Transform _transform;
    [SerializeField] private Transform _goalPosTransform;
    [SerializeField] private ParticleSystem _particle;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _collider;

    private TickableState1 _state1;
    private TickableState2 _state2;
    private TickableStateMachine _stateMachine;

    private void Start()
    {
        _state1 = new TickableState1
        (
            _transform,
            _rigidbody,
            _collider,
            _particle,
            _goalPosTransform.position
        );

        _state2 = new TickableState2
        (
            _rigidbody,
            _collider
        );

        _stateMachine = new TickableStateMachine();

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

        _stateMachine.Tick();
    }
}