using HadFlag;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Experimental.GraphView.GraphView;

public class IAEnemy : MonoBehaviour, IHadFlag
{
    public Transform[] position;
    public Transform tf;
    private NavMeshAgent agent;
    //public GameObject ia;
    private Animator anim;
    public bool destino = false;
    public bool jugador = false;
    public float speed;
    private int _i = 0;
    public GameObject player;
    [SerializeField] private GameObject _flag;
    [SerializeField] private GameObject _miniFlag;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();




    }

    // Se ejecuta toda la ruta con sus casos
    void Update()
    {
      if(player != null)
        {
            switch (_i)
            {
                case 0:
                    if (jugador)
                    {
                        _i = 1;
                    }
                    else
                    {
                        Move(_i = 0);
                       
                    }


                    break;
                case 1:

                    Move(_i = 1);

                    if (destino)
                    {
                        _i = 2;
                    }
                    else
                    {
                        _i = 0;
                    }

                    break;
                case 2:

                    if (jugador)
                    {
                        _i = 1;
                    }
                    else
                    {
                        Move(_i = 2);
                    }
                    //destino = true;

                    break;
            }

        }






    }

    public void WhoHadFlag()
    {
        _i = 2;
        destino = true;
        _miniFlag.SetActive(true);
        Debug.Log("entro");
    }
    public void Position()
    {
        _flag.transform.parent = this.transform;
        Debug.Log("enmigo es el padre");
    }

    // cuando colisione con player, que es la bandera vuelvak    private void OnCollisionEnter(Collision collision)
    private void OnCollisionEnter(Collision collision)
    {
        //if (collision.gameObject.CompareTag("Flag"))
        //{
        //    _i = 2;
        //    destino = true;
        //    Debug.Log("entro");

        //}

        if (collision.gameObject.CompareTag("Player"))
        {

            Destroy(player);

            if (destino)
            {
                Move(_i = 2);
            }
            else
            {
                Move(_i = 0);
            }


        }


    }

    // si me detecta al jugador lo sigue
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player"))
        {
            _i = 1;
            jugador = true;

        }

    }
    private void OnTriggerExit(Collider other)
    {
        jugador = false;
    }

    // movimiento del navmesh va camabiando dependiento de la _i cambia la posicion de la ruta
    public int Move(int _i)
    {
        agent.SetDestination(position[_i].position);
        //anim.SetBool("Walk", true);
        agent.isStopped = false;
        Debug.Log("position" + _i);
        return _i;
    }

  

}


