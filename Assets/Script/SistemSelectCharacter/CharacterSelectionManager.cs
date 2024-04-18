using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// Clase que administra la selección de personajes
public class CharacterSelectionManager : MonoBehaviour
{
    public CharactersData characterData; // Datos del personaje seleccionado

    // Este método asigna el personaje seleccionado
    public void AsingnateCharacter(GameObject prefab)
    {
        characterData.PrefabCharacter = prefab;
    }
    
    // Este método inicia el juego
    public void StarGame()
    {
        SceneManager.LoadScene("MainScene"); // Carga la escena principal
    }
}