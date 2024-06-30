using Shafir.FSM;
using UnityEngine;

public class SimpleState1 : IState
{
    private Transform _transform;
    private Rigidbody _rigidbody;
    private Collider _collider;
    private ParticleSystem _particleSystem;
    private Vector3 _goalPos;

    public SimpleState1
    (
        Transform transform,
        Rigidbody rigidbody,
        Collider collider,
        ParticleSystem particle,
        Vector3 goalPos
    )
    {
        _transform = transform;
        _rigidbody = rigidbody;
        _collider = collider;
        _particleSystem = particle;
        _goalPos = goalPos;
    }

    public void Enter()
    {
        _transform.position = _goalPos;
        _rigidbody.isKinematic = true;
        _collider.enabled = false;
        _particleSystem.Play();
    }

    public void Exit()
    {
        _particleSystem.Stop();
    }
}
