using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private ParticleSystem dirtFoots;
    
    public float velocity;
    public float defense;
    public float attack;

    private float VelX;
    private float VelY;

    private Animator _animator;

    public void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    private void Update()
    {
        VelX = Input.GetAxis("Horizontal");
        VelY = Input.GetAxis("Vertical");

        WalkAnimations( VelY, VelX);
    }
    public void WalkAnimations(float VelY, float VelX)
    {
        _animator.SetFloat("VelX", VelY);
        _animator.SetFloat("VelY", VelX);
    }

    public void ActivateFoots(bool state)
    {
        if (state)
        {
            dirtFoots.Play();
        }
        else
        {
            dirtFoots.Stop();
        }
    }
}
