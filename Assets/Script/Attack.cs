using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class Attack : MonoBehaviour
{
    //public Transform positionPlayer;
    public float speed = 3f;
    //public bool seguir = false;
    //public NavMeshAgent agent;
    //public GameObject nav;


    // Update is called once per frame


    void Update()
    {
        float Hor = Input.GetAxisRaw("Horizontal");
        float Ver = Input.GetAxisRaw("Vertical");

        transform.Translate(-Ver * Time.deltaTime * speed, 0f, Hor * Time.deltaTime * speed);
    }
}
