using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelectionManager : MonoBehaviour
{
    public CharactersData characterData;
    public void AsingnateCharacter(GameObject prefab)
    {
        characterData.PrefabCharacter = prefab;
    }
    
    public void StarGame()
    {
        SceneManager.LoadScene("CopiaDianaScene");
    }
}
