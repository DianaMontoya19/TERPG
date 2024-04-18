using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIA : MonoBehaviour
{
<<<<<<< Updated upstream
    public float radioAtaque = 0.5f;
    private float attack1 = 5;
    private float attack2 = 10;
    private float attack3 = 15;
    private Transform actualTransform;
    public LayerMask layerMask;
    private Character character;
    void Awake()
    {
        actualTransform = transform;
        character = FindObjectOfType<Character>();
=======
    public float radioAtaque = 0.5f; // Radio de ataque de la IA
    private float attack1 = 5; // Daño del ataque 1
    private float attack2 = 10; // Daño del ataque 2
    private float attack3 = 15; // Daño del ataque 3
    private Transform actualTransform; // Referencia al componente Transform de la IA
    public LayerMask layerMask; // Máscara de capa para determinar qué objetos pueden ser atacados
    private CharacterIA characterIA; // Referencia al componente CharacterIA de la IA

    void Awake()
    {
        actualTransform = transform; // Asigna el componente Transform a la variable actualTransform
        characterIA = FindObjectOfType<CharacterIA>(); // Busca en la escena el objeto con el componente CharacterIA y lo asigna a la variable characterIA
>>>>>>> Stashed changes
    }

    void OnDrawGizmosSelected()
    {
        // Dibuja una esfera en la posición de la IA con el radio de ataque
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GetProbePosition(), radioAtaque);
    }
<<<<<<< Updated upstream
  
    public void Atacar(float attack)
=======

    void Update()
    {
        // Este método está vacío, pero se puede usar para actualizar la lógica de la IA en cada frame
    }

    void Atacar(float attack)
>>>>>>> Stashed changes
    {
        // Obtiene todos los colliders dentro del radio de ataque que corresponden a la máscara de capa
        Collider[] colliders = Physics.OverlapSphere(GetProbePosition(), radioAtaque, layerMask);

        foreach (Collider collider in colliders)
        {
<<<<<<< Updated upstream
            if (collider.CompareTag("TeamA"))
            {
                character.IGetDamage(attack);
=======
            // Si el collider pertenece al equipo B, le inflige daño
            if (collider.CompareTag("TeamB"))
            {
                characterIA.IGetDamage(attack);
>>>>>>> Stashed changes
            }
        }
    }

    Vector3 GetProbePosition()
    {
        // Devuelve la posición de la IA ajustada en el eje Y
        return actualTransform.position + actualTransform.TransformVector(new Vector3(0.0f, 1.2f, 0f));
    }
}
