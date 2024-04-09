using HadFlag;
using UnityEngine;

public class Flag : MonoBehaviour
{
    //public GameObject flag;
    //public GameObject miniFlags;
   
    public bool follow = false;
    [SerializeField] private GameObject flag;
    //// Start is called before the first frame update
    //void Start()
    //{
       
    //}

    ////// Update is called once per frame
    //void Update()
    //{
    //    if (follow)
    //    {
    //        gameObject.TryGetComponent<IHadFlag>(out IHadFlag component);
    //        component?.Position();
            
    //    }
    //}
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

    private void OnTriggerEnter(Collider collision)
    {
        bool hasFound = collision.gameObject.TryGetComponent<IHadFlag>(out IHadFlag component);
        if (!hasFound) return;
        component?.WhoHadFlag();
        component?.Position();
        follow = true;

       flag.gameObject.SetActive(false);

    }




}
