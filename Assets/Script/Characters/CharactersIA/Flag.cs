using HadFlag;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Flag : MonoBehaviour
{
    //public GameObject flag;
    //public GameObject miniFlags;
   
    public bool follow = false;
    [SerializeField] private GameObject flag;
    //// Start is called before the first frame update
    ////void Start()
    ////{

    ////}

    ////// Update is called once per frame
    //void Update()
    //{
    //    if (follow)
    //    {
    //        flag.transform.position = gameObject.transform.position;
    //    }
    //}


    //    //if(this.gameObject == null)
    //    //{
    //    //    flag.SetActive(true);
    //    //}
    //}
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.CompareTag("Flag"))
    //    {
    //        Activate();

    //    }
    //}
    ////private void OnDisable()
    ////{
    ////    gameObject.SetActive(false);
    ////    flag.SetActive(true);
    ////}
    //private void Activate()
    //{
    //    flag.SetActive(false);
    //    miniFlags.SetActive(true);
    //    follow = true;
    //}

    private void OnCollisionEnter(Collision collision)
    {
       collision.gameObject.TryGetComponent<IHadFlag>(out IHadFlag component);
       component?.WhoHadFlag();
       follow = true;

       flag.gameObject.SetActive(false);

    }




}
