using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class IAEnemy : MonoBehaviour
{
    public Transform[] position;
    public Transform tf;
    private NavMeshAgent agent;
    public GameObject ia;
    private Animator anim;
    public bool destino = false;
    public bool jugador = false;
    public float speed;
    private int _i = 0;
    public GameObject player;
    private Vector3 ruta;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();

        


    }

    // Se ejecuta toda la ruta con sus casos
    void Update()
    {
        
        switch (_i)
            {
                case 0:
                    Move(_i = 0);
                    destino = false;
                    break;
                case 1:

                    Move(_i = 1);

                    if (!destino)
                    {
                        _i = 0;
                    }
                    else if (destino)
                    {
                        _i = 2;
                    }
                
                break;
                case 2:
                    Move(_i = 2);

                    break;
        }

       


    }
    // movimiento del navmesh va camabiando dependiento de la _i cambia la posicion de la ruta
    public int Move(int _i)
    {
        agent.SetDestination(position[_i].position);
        anim.SetBool("Walk", true);
        agent.isStopped = false;

        return _i;
    }

    // cuando colisione con player, que es la bandera vuelva a la posicion incial, pero si me choca con el enemigo lo destruya
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Flag"))
        {
            _i = 2;
            destino = true;
            Debug.Log("entro");
            //anim.SetBool("Walk", false);
            //agent.isStopped = true;
        }

        if (collision.gameObject.CompareTag("Player"))
        {

            Destroy(player);
           
            if(destino)
            {
                _i = 2;
            }
            else
            {
                _i = 0;
            }
            

        }
        //   if(player == null && !destino)
        //    {
        //        _i = 0;
        //    }
        //    else if(player == null && destino)
        //    {
        //        _i = 2;
        //    }


        //}        

    }
    // si me detecta al jugador lo sigue
    private void OnTriggerStay(Collider other)
    {
        if (player != null)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                _i = 1;
                //Debug.Log(agent.pathStatus);
            }
        }
    }
    // deteccion para activar ataque, quise intentarlo con areas del layer
    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object  
        Gizmos.color = Color.red;
        Vector3 direction = new Vector3(tf.position.x, tf.position.y + 2, tf.position.z);
        Gizmos.DrawWireSphere(direction, 3f);

        Collider[] hitColliders = Physics.OverlapSphere(direction, 3f);

        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.CompareTag("Player"))
            {
                anim.SetTrigger("Attack");
                Debug.Log("deteccion");
            }
        }

    }
    //private void Player()
    //{


    //}
    //    if(jugador)
    //    {
    //        if(destino)
    //        {

    //        }
    //    }
    //}
    //private void OnTriggerExit(Collider other)
    //{
    //    destino = true;
    //}
}

            //        Destroy(ia);
            //        Invoke("ReStart", 1f);
            //        Debug.Log("Entro");



            //    }
            //    if (destino == true && collision.gameObject.CompareTag("Position"))
            //    {

            //       anim.SetBool("Walk", false);
            //        agent.isStopped = true;
            //       Debug.Log("llego");
            //    }


            //}
            //void ReStart()
            //{

            //    anim.SetBool("Walk", true);
            //    agent.destination = positionEnemy.position;
            //    //destino = true;
            //    agent.isStopped = false;

            //    //agent.SetDestination(this.transform.position);
            //    Debug.Log("reestart");
            //}


            //       if(agent.isStopped)
            //        {
            //            agent.isStopped = false;
            //            agent.destination = positionEnemy.position;
            //        }
            //       Debug.Log("el agente llego");

            //       //agent.destination = positionEnemy.position;

            //    }
            //}
        
