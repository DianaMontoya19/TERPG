using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    public GameObject flag;
    public GameObject miniFlags;
    public bool follow = false;
    // Start is called before the first frame update
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    void Update()
    {
        if (follow)
        {
            flag.transform.position = gameObject.transform.position;
        }

        //if(this.gameObject == null)
        //{
        //    flag.SetActive(true);
        //}
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Flag"))
        {
            Activate();
            
        }
    }
    //private void OnDisable()
    //{
    //    gameObject.SetActive(false);
    //    flag.SetActive(true);
    //}
    private void Activate()
    {
        flag.SetActive(false);
        miniFlags.SetActive(true);
        follow = true;
    }
 
   
        
            
        
        
    
}
