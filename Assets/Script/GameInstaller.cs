 using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class GameInstaller : MonoBehaviour
    {
        [Header("Requirements")]
        


        [Header("ObjectsReference")]
        [SerializeField] private Player player;
        [SerializeField] private Player enemy;
        
        
        [Space(8)]
        
        [Header("Character Data")]
        
        [SerializeField] private CharactersData config;
        [SerializeField] private CharacterIAData configIA;

        [Header("Factories Configs")]
        private ConfigureFactory _playerFactory;
        private ConfigureFactory _enemyFactory;

        [Space(12)]

        
        [Header("Characters & Enemy Characters")]
        [SerializeField] private EnemyStateEnum[] enums;
        
        [Space(12)]
        
        
        [Header("Enemys Positions")]
        [SerializeField] private Transform[] transforms;
        
        [Space(12)]
        
        [Header("Player Position")]
        [SerializeField] private Transform position;
              
        private Dictionary<EnemyStateEnum, Transform> _positions = new();  //Mapea los estados de los enemidos con sus posiciones
        
        private void Awake()  //Inicializa el diccionario de posiciones
        {
            _playerFactory = new ConfigureFactory(config);
            _enemyFactory = new ConfigureFactory(configIA);
            for (int i = 0; i < enums.Length; i++)
            {
                _positions.Add( enums[i], transforms[i] );
            }
        }

        private void Start() 
        {
            Character player1 = _playerFactory.Create(config.id,player.transform); // 0 0 0
            CharacterIA enemy1 = _enemyFactory.CreateIA(Contra(configIA.id),enemy.transform); // 0 0 0
           
            IMovable movable = new PlayerInput(600f, player.Rb, player.Transform, 5f);
            IMovable movalbeEnemy = new AiInput(Team.Red, _positions, enemy.NavMeshAgent, EnemyStateEnum.Flag);
           
            player.Configure(Team.Blue, player1, movable);
            enemy.ConfigureEnemy(Team.Red, enemy1, movalbeEnemy);
        }
        public int Contra(int id) => (id + 2) % 4;
    }
}