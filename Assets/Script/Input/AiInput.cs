using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[Serializable]
public enum EnemyStateEnum
{
    Player,
    Flag,
    Position,
}

public class AiInput : IMovable
{
    private readonly Team _team;
    private readonly Dictionary<EnemyStateEnum, Transform> _positions;
    private readonly NavMeshAgent _agent;
    private EnemyStateEnum _currentState;

    private EnemyStateEnum IsFlagCaptured =>
        FlagManager.Instance.currentState == FlagStatesEnum.Captured
            ? EnemyStateEnum.Position
            : EnemyStateEnum.Flag;

    public AiInput(Team team, Dictionary<EnemyStateEnum, Transform> positions, NavMeshAgent agent, EnemyStateEnum currentState = EnemyStateEnum.Flag)
    {
        _team = team;
        _positions = positions;
        _agent = agent;
        _currentState = currentState;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Player player))
        {
            _currentState = IsFlagCaptured;
        }
    }

    public void OnCollisionExit(Collision collision) {}

    public void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.TryGetComponent(out Player player)) return;
        if (player.Team == _team) return;
        
        _positions[EnemyStateEnum.Player] = player.transform;
        _currentState = EnemyStateEnum.Player;
    }
    
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Player player))
        {
            _currentState = IsFlagCaptured;
        }
    }
    
    private void Move(EnemyStateEnum state)
    {
        Transform destine = _positions[state];
        _agent.SetDestination(destine.position);
    }
    
    public void FixedUpdate()
    {
        Move(_currentState);
    }
    
    public void Update()
    {
       
    }

    public int AttackAnimations()
    {
        return 0;
    }
    public void  ActivateDirty()
    {

    }


}