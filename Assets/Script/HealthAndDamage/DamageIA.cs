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
    private Character character;
    void Awake()
    {
        actualTransform = transform;
        character = FindObjectOfType<Character>();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GetProbePosition(), radioAtaque);
    }
  
    public void Atacar(float attack)
    {
        Collider[] colliders = Physics.OverlapSphere(GetProbePosition(), radioAtaque, layerMask);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("TeamA"))
            {
                character.IGetDamage(attack);
            }
        }
    }

    Vector3 GetProbePosition()
    {
        return actualTransform.position + actualTransform.TransformVector(new Vector3(0.0f, 1.2f, 0f));
    }
}
