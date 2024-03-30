using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public Animator anim;
    public float speed;
    public Transform tf;
    public GameObject player;
    private bool detection = false;
    

    public void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnDrawGizmosSelected()
    {
        // Draws a 5 unit long red line in front of the object  
        Gizmos.color = Color.red;
        Vector3 direction = new Vector3(tf.position.x, tf.position.y+2, tf.position.z);
        Gizmos.DrawWireSphere(direction, 3f);

        Collider[] hitColliders = Physics.OverlapSphere(direction, 3f);

        foreach (var hitCollider in hitColliders)
        {
            if(hitCollider.CompareTag("Enemy"))
            {
                anim.SetTrigger("Attack");
                Debug.Log("deteccion");
            }
        }

    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    detection = Physics.OverlapSphere(tf.position.x, tf.position.y + 2, tf.position.z, 3f);
    //    if (other.gameObject.layer == LayerMask.NameToLayer("Enemy"))
    //    {
    //        anim.SetTrigger("Attack");
    //        Debug.Log("detecto");
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (player != null)
        {
            if (collision.gameObject.CompareTag("Enemy"))
            {

                Destroy(player);
            }
        }
    }
}
