

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
        
        PlayerPrefs.SetString("SelectedCharacter", prefab.name); // Guarda el nombre del personaje seleccionado
    }
    
    // Este método inicia el juego
    public void StarGame()
    {
        //Reactiva el terreno
        ChangeCharacterButton changeCharacterButton = FindObjectOfType<ChangeCharacterButton>();
        changeCharacterButton.terrain.SetActive(true);
        SceneManager.LoadScene("MainScene"); // Carga la escena principal
    }
}