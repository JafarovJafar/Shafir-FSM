using Shafir.FSM;
using UnityEngine;

public class TickableState1 : ITickableState
{
    private Transform _transform;
    private Rigidbody _rigidbody;
    private Collider _collider;
    private ParticleSystem _particleSystem;
    private Vector3 _goalPos;

    private float _rotateSpeed = 180f;

    public TickableState1
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

    public void Tick()
    {
        Vector3 eulers = _transform.eulerAngles;
        eulers.y += _rotateSpeed * Time.deltaTime;
        _transform.eulerAngles = eulers;
    }

    public void Exit()
    {
        _particleSystem.Stop();
    }
}