using Shafir.FSM;
using UnityEngine;

public class SimpleState2 : IState
{
    private Rigidbody _rigidbody;
    private Collider _collider;

    public SimpleState2
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

    public void Exit()
    {

    }
}