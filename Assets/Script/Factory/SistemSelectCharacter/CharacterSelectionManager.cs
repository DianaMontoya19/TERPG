using UnityEngine;
using UnityEngine.SceneManagement;

// Clase que administra la selección de personajes
public class CharacterSelectionManager : MonoBehaviour
{
    public CharactersData characterData; // Datos del personaje seleccionado
    [HideInInspector] public int id;

    // Este método asigna el personaje seleccionado
    public void AsingnateCharacter(int prefab)
    {
        id = prefab;
        characterData.GetPrefab(id);


    }

    // Este método inicia el juego
    public void StarGame()
    {

        SceneManager.LoadScene("MainScene"); // Carga la escena del juego
    }
}