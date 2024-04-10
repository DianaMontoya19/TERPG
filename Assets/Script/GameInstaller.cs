using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class GameInstaller : MonoBehaviour
    {
        [SerializeField] private Character character;

        [SerializeField] private Character barbarianTest;
        
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
            
        }
    }
}