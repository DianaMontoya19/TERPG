using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public IAEnemy follow;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        OnDisable();

    }
    private void OnDisable()
    {
        if (follow.player == null)
        {
            Debug.Log("desaparecio");
        }
    }
}
