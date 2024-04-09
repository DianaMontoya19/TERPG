using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace Script
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private Character character;

        [SerializeField] private EnemyStateEnum[] enums;
        [SerializeField] private Transform[] transforms;

        [SerializeField] private Transform position;
        
        private Dictionary<EnemyStateEnum, Transform> _positions = new();
        
        private void Awake()
        {
            for (int i = 0; i < enums.Length; i++)
            {
                _positions.Add( enums[i], transforms[i] );
            }
        }

        private void Start()
        {
            Character player = Instantiate(character);
            IInput input = new PlayerInput(600f, player.Rb, player.Transform, 5f);
            player.Configure(input);
            _positions.Add(EnemyStateEnum.Player, player.Transform);
            
            Character enemy = Instantiate(character);
            IInput enemyInput = new AiInput(_positions, enemy.Agent);
            enemy.Configure((IInput) enemyInput, (IInputAddons) enemyInput);

            player.Transform.position = position.position;
            enemy.Transform.position = position.position;
        }
    }
}