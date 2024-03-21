using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public Animator anim;
    public float speed;

    public void Start()
    {
        anim = GetComponent<Animator>();
    }
    void Update()
    {
        float Horizontal = Input.GetAxisRaw("Horizontal");
        float Vertical = Input.GetAxisRaw("Vertical");

        transform.Translate(0f, 0f, Vertical * Time.deltaTime * speed);

        anim.SetFloat("Velx", Horizontal);
        anim.SetFloat("VelY", Vertical);
    }
}
