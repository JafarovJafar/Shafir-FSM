using Shafir.FSM;
using UnityEngine;

public class TickableState2 : ITickableState
{
    private Rigidbody _rigidbody;
    private Collider _collider;

    private float _rotateStrength = 100;

    public TickableState2
    (
        Rigidbody rigidbody,
        Collider collider
    )
    {
        _rigidbody = rigidbody;
        _collider = collider;
    }

    public void Enter()
    {
        _collider.enabled = true;
        _rigidbody.isKinematic = false;
    }

    public void Tick()
    {
        _rigidbody.AddTorque(Vector3.forward * _rotateStrength);
    }

    public void Exit()
    {

    }
}