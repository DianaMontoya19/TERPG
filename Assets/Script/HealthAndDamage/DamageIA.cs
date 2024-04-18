using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageIA : MonoBehaviour
{
    public float radioAtaque = 0.5f;
    private float attack1 = 5;
    private float attack2 = 10;
    private float attack3 = 15;
    private Transform actualTransform;
    public LayerMask layerMask;
    private CharacterIA characterIA;
    void Awake()
    {
        actualTransform = transform;
        characterIA = FindObjectOfType<CharacterIA>();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GetProbePosition(), radioAtaque);
    }
  
    void Update()
    {
        
    }

    void Atacar(float attack)
    {
        Collider[] colliders = Physics.OverlapSphere(GetProbePosition(), radioAtaque, layerMask);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("TeamB"))
            {
                characterIA.IGetDamage(attack);

            }
        }
    }

    Vector3 GetProbePosition()
    {
        return actualTransform.position + actualTransform.TransformVector(new Vector3(0.0f, 1.2f, 0f));
    }
}
