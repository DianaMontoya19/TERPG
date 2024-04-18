using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;
using UnityEngine.UIElements;


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
    //private readonly Transform _transform;
    private EnemyStateEnum _currentState;
    private bool _isActive = false;
    private int RangeAttack;
   


    private EnemyStateEnum IsFlagCaptured =>
        FlagManager.Instance.currentState == FlagStatesEnum.Captured && _isActive
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

        if (collision.gameObject.TryGetComponent(out FlagObject flag))
        {

            _isActive = true;
            FlagManager.Instance.CaptureFlag(CharacterIA.Instance.transform, false); // Captura la bandera
            _currentState = IsFlagCaptured; // Cambia el estado del AI

        }
        if (collision.gameObject.TryGetComponent(out Player player))
        {

            //player.Die();

            if (!player.gameObject.activeSelf)
            {

                _currentState = IsFlagCaptured;


                if (FlagManager.Instance.capturedBy)
                {
                    FlagManager.Instance.Spawn();

                }

            }

        }
        if(collision.gameObject.CompareTag("EnemyFlag") && _isActive)
        {
            FlagManager.Instance.Respawn();
            FlagManager.Instance.Point(Team.Red);
            
            
            _currentState = IsFlagCaptured;
            _isActive = false;

        }




    }

    public void OnCollisionExit(Collision collision) { }

    public void OnTriggerEnter(Collider other)
    {
        CharacterIA.Instance.AttackAnimations(AttackAnimations());
        if (!other.gameObject.TryGetComponent(out Player player)) return;
        //if (player.Team == _team) return;

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

        //_agent.isStopped = false;
    }

    public void FixedUpdate()
    {
        Move(_currentState);

    }

    public void Update()
    {
        float _velx = 1f;
        CharacterIA.Instance.WalkAnimationsIA(_velx);
        
        //Stop();


    }
    //public void Stop()
    //{
    //    if (!_agent.pathPending && _agent.remainingDistance <= _agent.stoppingDistance)
    //    {
    //        _isActive = false;
    //        //_agent.isStopped = true;
    //        FlagManager.Instance.Respawn();
    //        FlagManager.Instance.Point(Team.Red);
    //        _currentState = IsFlagCaptured;

    //        Debug.Log("Gane" + _currentState);
    //        Debug.Log(IsFlagCaptured);
    //        Debug.Log(_isActive);
    //    }
    //}

    public int AttackAnimations()
    {
              
        RangeAttack =  Random.Range(0, 2);
        
      

        return 0;
    }
    public void  ActivateDirty()
    {

    }

 
}