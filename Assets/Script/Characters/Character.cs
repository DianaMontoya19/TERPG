using System;
using UnityEngine;

public abstract class Character : MonoBehaviour
{
    [SerializeField] private ParticleSystem dirtFoots;
    private static Character _instance;
    public static Character Instance => _instance;

    public float velocity;
    public float defense;
    public float attack;


    private Animator _animator;

    public void Awake()
    {
        _animator = GetComponent<Animator>();
        _instance = this;
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

    public void AttackAnimations(int selector)
    {
        
        if(selector == 1)
        {
            _animator.SetTrigger("Attack1");
        }
        if (selector == 2)
        {
            _animator.SetTrigger("Attack2");
        }
        if (selector == 3)
        {
            _animator.SetTrigger("Attack3");
        }
        if (selector == 4)
        {
            _animator.SetTrigger("BlockAttack");
        }
        if (selector == 5)
        {
            _animator.SetBool("Block", true);
        }
        else
        {
            _animator.SetBool("Block", false);
        }

    }
}
