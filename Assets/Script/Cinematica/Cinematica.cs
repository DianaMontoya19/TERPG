using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Cinematica : MonoBehaviour
{
    public string gameSceneName; // Nombre de la escena del juego principal
    public float cinematicDuration = 10f; // Duraci�n de la cinem�tica en segundos

    private bool cinematicFinished = false;

    void Start()
    {
        // Inicia la corutina que controla la cinem�tica
        StartCoroutine(PlayCinematic());
    }

    IEnumerator PlayCinematic()
    {
        // Reproduce la cinem�tica
        // Aqu� debes colocar el c�digo para reproducir tu cinem�tica
        // Puedes usar la funci�n yield return new WaitForSeconds() para esperar un tiempo antes de continuar

        yield return new WaitForSeconds(cinematicDuration);

        // La cinem�tica ha terminado, establece la bandera de finalizaci�n en true
        cinematicFinished = true;

        // Carga la escena del juego principal
        SceneManager.LoadScene(gameSceneName);
    }
}
