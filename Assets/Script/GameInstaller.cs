 using System.Collections.Generic;
using UnityEngine;

namespace Script
{
    public class GameInstaller : MonoBehaviour
    {
        
        [Header("ObjectsReference")]
        [SerializeField] private Player player;
        [SerializeField] private Player enemy;
        
        
        [Space(8)]
        
        [Header("Character Data")]
        
        [SerializeField] private CharactersData characterData;
        
        [Space(12)]

        
        [Header("Characters & Enemy Characters")]
        [SerializeField] private Character[] character;
        [SerializeField] private CharacterIA[] characterEnemy;

        [SerializeField] private EnemyStateEnum[] enums;
        
        [Space(12)]
        
        
        [Header("Enemys Positions")]
        [SerializeField] private Transform[] transforms;
        
        [Space(12)]
        
        [Header("Player Position")]
        [SerializeField] private Transform position;
        
        
        private string[] names = { "Knight", "Barbarian", "Skeleton_Warrior" ,"Skeleton_Minion",};  //ArrayCharactersNames
        private Dictionary<EnemyStateEnum, Transform> _positions = new();  //Mapea los estados de los enemidos con sus posiciones
        
        private void Awake()  //Inicializa el diccionario de posiciones
        {
            for (int i = 0; i < enums.Length; i++)
            {
                _positions.Add( enums[i], transforms[i] );
            }
        }

        private void Start() 
        {
            for (int i = 0; i < names.Length; i++) //Asigna los personajes a los jugadores
            {
                if (names[i] == characterData.PrefabCharacter.name)
                //    Si el nombre del personaje seleccionado coincide con uno de los nombres en el array names...
                {
                    IMovable movable = new PlayerInput(600f, player.Rb, player.Transform, 5f);  // ... se crea un nuevo objeto PlayerInput y se configura el jugador con él.
                    IMovable movalbeEnemy = new AiInput(Team.Red, _positions, enemy.NavMeshAgent, EnemyStateEnum.Flag);  // ... se crea un nuevo objeto AiInput y se configura el enemigo con él.
                    
                    // ... se configura el jugador y el enemigo con los personajes seleccionados.
                    player.Configure(Team.Blue, character[i], movable);
                    enemy.ConfigureEnemy(Team.Red, characterEnemy[i], movalbeEnemy);
                    // Romper el buble unavez que se encuentre el personaje seleccionado
                    break;
                }
            }
        }   
    
    }
}