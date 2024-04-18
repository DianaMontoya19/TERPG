using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class DamagePlayer : MonoBehaviour
{
    public float radioAtaque = 0.5f;
    private float attack1 = 5;
    private float attack2 = 10;
    private float attack3 = 15;
    private bool haAtacadoMouse0 = false;
    private bool haAtacadoMouse1 = false;
    private bool haAtacadoE = false;
    private Transform actualTransform;
    public LayerMask layerMask;
    private CharacterIA characterIA;
    void Awake()
    {
        actualTransform = transform;
    }

    private void Start()
    {
        characterIA = FindObjectOfType<CharacterIA>();
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GetProbePosition(), radioAtaque);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0) && !haAtacadoMouse0)
        {
            Atacar(attack1);
            haAtacadoMouse0 = true;
        }
        if (Input.GetMouseButtonUp(1) && !haAtacadoMouse1)
        {
            Atacar(attack2);
            haAtacadoMouse1 = true;
        }
        if (Input.GetKeyUp(KeyCode.E) && !haAtacadoE)
        {
            Atacar(attack3);
            haAtacadoE = true;
        }

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1) || Input.GetKeyUp(KeyCode.E))
        {
            haAtacadoMouse0 = false;
            haAtacadoMouse1 = false;
            haAtacadoE = false;
        }
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
