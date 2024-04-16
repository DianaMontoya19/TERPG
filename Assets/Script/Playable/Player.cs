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
    public float health = 100f;
    private Character _character;
    private CharacterIA _characterEnemy;
    private IMovable _movable;

    private Rigidbody _rb;
    private DamageMainWeapon damageMainWeapon;
    public Rigidbody Rb => _rb;
    private Transform _transform;
    public Transform Transform => _transform;
    private NavMeshAgent _navMeshAgent;
    public NavMeshAgent NavMeshAgent => _navMeshAgent;
    
    
    
    protected void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _transform = transform;
        _navMeshAgent = GetComponent<NavMeshAgent>();
        damageMainWeapon = GameObject.FindObjectOfType<DamageMainWeapon>();

    }



    public void Configure(Team team, Character character, IMovable movable)
    {
        _team = team;
        _character = Instantiate(character, _transform);
        _movable = movable;
    }

    public void ConfigureEnemy(Team team, CharacterIA characterEne, IMovable movable)
    {
        _team = team;
        _characterEnemy = Instantiate(characterEne, _transform);
        _movable = movable;
    }

    public void Update()
    {
        
        _movable.Update();
    }

    

    protected void FixedUpdate()
    {
        _movable.FixedUpdate();
    }
    public void IGetDamage(float damageRecive)
    {
        health -= damageRecive;
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