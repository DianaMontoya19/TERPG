using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class IAEnemy : MonoBehaviour
{
    public Transform flag;
    public Transform positionEnemy; 
    private NavMeshAgent agent;
    public GameObject ia;
    private Animator anim;
    public bool destino = false;
    public float speed;
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponent<Animator>();
        anim.SetBool("Walk", true);
        


    }

    // Update is called once per frame
    void Update()
    {
        if(flag != null)
        {
            agent.SetDestination(flag.position);
        }


       

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            anim.SetBool("Walk", false);
            agent.isStopped = true;
            
            Destroy(ia);
            Invoke("ReStart", 1f);



        }
        if (collision.gameObject.tag == "Position")
        {

            anim.SetBool("Walk", false);
            agent.isStopped = true;
            Debug.Log("llego");
        }


    }
    void ReStart()
    {

        anim.SetBool("Walk", true);
        agent.destination = positionEnemy.position;
        agent.isStopped = false;
        
        //agent.SetDestination(this.transform.position);
        Debug.Log("reestart");
    }


    //       if(agent.isStopped)
    //        {
    //            agent.isStopped = false;
    //            agent.destination = positionEnemy.position;
    //        }
    //       Debug.Log("el agente llego");

    //       //agent.destination = positionEnemy.position;

    //    }
    //}
}
