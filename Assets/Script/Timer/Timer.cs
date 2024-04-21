using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer = 0f; // Variable que controla el tiempo restante
    private float initialTime;
    public TextMeshProUGUI textoTimer; // Referencia al componente TextMeshProUGUI que muestra el tiempo restante
    private Character character; // Referencia al componente Character del jugador
    private CharacterIA characterIA; // Referencia al componente CharacterIA del enemigo
    public float PlayerHealth; // Salud del jugador
    public float EnemyHealth; // Salud del enemigo

    private void Start()
    {
        // Busca en la escena los objetos con los componentes Character y CharacterIA y los asigna a las variables correspondientes
        character = FindObjectOfType<Character>();
        characterIA = FindObjectOfType<CharacterIA>();
        initialTime = timer;
    }

    void Update()
    {
        print(Time.deltaTime);
        // Disminuye el tiempo restante
        timer -= Time.deltaTime;
        
        // Actualiza el texto del timer
        textoTimer.text = "Time: " + timer.ToString("f0");

        // Si el tiempo llega a 0, termina el juego
        if (timer <= 0f)
        {
            Debug.Log("GAME OVER");
        }

        // Actualiza las variables de salud del jugador y del enemigo
        PlayerHealth = character.health;
        EnemyHealth = characterIA.health;
    }
    
    public void RestartTimer()
    {
        Time.timeScale = 1f; // Reanuda el tiempo
        // Reinicia el tiempo restante
        timer = initialTime;
        
    }
}

