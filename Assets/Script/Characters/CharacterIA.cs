
using UnityEngine;


public class CharacterIA : MonoBehaviour
{
    [SerializeField] private ParticleSystem dirtFoots;
    private static CharacterIA _instance;
    public static CharacterIA Instance => _instance;
    private Animator _animator;
    public float health = 100f;

    public void Awake()
    {
        _instance = this;
        _animator = GetComponent<Animator>();
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
    public void WalkAnimationsIA(float VelX)
    {
        _animator.SetFloat("VelX", VelX);
    }

    public void IGetDamage(float damageRecive)
    {
        health -= damageRecive;
    }
    public void AttackAnimations(int selector)
    {
        switch(selector)
        {
            case 0: _animator.SetTrigger("Attack1");
                break;

            case 1: _animator.SetTrigger("Attack2");
                break;
        }

    }
}
