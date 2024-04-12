using System;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public enum Team
{
    Blue,
    Red,
}

public class Player : MonoBehaviour
{
    private Team _team;
    public Team Team => _team;
    
    private Character _character;
    private IMovable _movable;
    
    private Rigidbody _rb;
    public Rigidbody Rb => _rb;
    private Transform _transform;
    public Transform Transform => _transform;
    private NavMeshAgent _navMeshAgent;
    public NavMeshAgent NavMeshAgent => _navMeshAgent;
  
    private float VelX => _rb.velocity.x;
    private float VelY => _rb.velocity.y;
    
    protected void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _transform = transform;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        
    }
    
    public void Configure(Team team, Character character, IMovable movable)
    {
        _team = team;
        _character = Instantiate(character, _transform);
        _movable = movable;
    }

    private void Update()
    {
        _character.WalkAnimations(VelX, VelY);
        _movable.Update();
    }

    protected void FixedUpdate()
    {
        _movable.FixedUpdate();
    }
    
    private void OnCollisionEnter(Collision other)
    {
        _movable.OnCollisionEnter(other);
    }

    private void OnCollisionExit(Collision other)
    {
        _movable.OnCollisionExit(other);
    }

    private void OnTriggerEnter(Collider other)
    {
        _movable.OnTriggerEnter(other);
    }

    private void OnTriggerExit(Collider other)
    {
        _movable.OnTriggerExit(other);
    }
    
}