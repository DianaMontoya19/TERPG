using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private ParticleSystem dirtFoots;
    
    public float velocity;
    public float defense;
    public float attack;

    private Animator _animator;

    public void Configure(Animator animator)
    {
        _animator = animator;
    }
    
    public void WalkAnimations(float velY, float velX)
    {
        _animator.SetFloat("VelX", velY);
        _animator.SetFloat("VelY", velX);
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
