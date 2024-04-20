using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeCharacterButton : MonoBehaviour
{
    
    public GameObject terrain;
    
    public void OnButtonClick()
    {
        
        // Desactiva el terreno
        terrain.SetActive(false);
        // Carga la escena UiScene de forma aditiva
        SceneManager.LoadScene("UiScene", LoadSceneMode.Additive);

        // Encuentra el objeto FuncionMenu en la escena
        FuncionMenu funcionMenu = FindObjectOfType<FuncionMenu>();

        // Llama al método SelectCharacter
        funcionMenu.SelectCharacter();
    }
}