using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class HitProbe : MonoBehaviour
{
    public float radioAtaque = 0.5f;
    private float attack1 = 5;
    private float attack2 = 10;
    private float attack3 = 15;
    private bool haAtacado = false;
    private Transform actualTransform;


    void Awake()
    {
        actualTransform = this.transform;
    }
    void OnDrawGizmosSelected()
    {
        
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(GetProbePosition(), radioAtaque);
    }

    private void Update()
    {
        if (Input.GetMouseButtonUp(0) && !haAtacado) 
        {
                Atacar(attack1);
                haAtacado = true;
        }

        if (Input.GetMouseButtonUp(1) && !haAtacado)
        {
                Atacar(attack2);
                haAtacado = true;
        }

        if (Input.GetKeyUp(KeyCode.E) && !haAtacado)
        {
                Atacar(attack3);
                haAtacado = true;
        }
    }
    void Atacar(float attack)
    {
        
        Collider[] colliders = Physics.OverlapSphere(GetProbePosition(), radioAtaque);

               
        foreach (Collider collider in colliders)
        {

           if (collider.CompareTag("TeamB"))
           {

            print("Attaque de " + attack + " de dano");
           }
        }
        
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("TeamB"))
        {
            haAtacado = false;
            print("yes");
        }
    }

    Vector3 GetProbePosition()
    {
        return actualTransform.position + actualTransform.TransformVector(new Vector3(0.0f,1.2f,0f));
    }
}
