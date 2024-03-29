using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class IAEnemy : MonoBehaviour
{
    public Transform[] flag;
    public Transform positionEnemy;
    private NavMeshAgent agent;
    public GameObject ia;
    private Animator anim;
    public bool destino = false;
    public float speed;
    private int _i = 0;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();




    }

    // Update is called once per frame
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
                if(!destino)
                {
                    _i = 0;
                }
                else if(destino)
                {
                    _i = 2;
                }
                break;
            case 2:
                Move(_i = 2);
            break;
        }





    }

    public int Move(int _i)
    {
        agent.SetDestination(flag[_i].position);
        anim.SetBool("Walk", true);
        agent.isStopped = false;

        return _i;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && _i==0)
        {
            _i = 2;
            destino = true;
            Debug.Log("entro");
            //anim.SetBool("Walk", false);
            //agent.isStopped = true;
        }
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            _i = 1;
        }
    }
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
        
