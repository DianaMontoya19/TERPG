
using System.Collections;
using UnityEngine;
using static UnityEngine.ParticleSystem;


public class CharacterIA : MonoBehaviour
{
    public ParticleSystem dirtFoots;
    private static CharacterIA _instance;
    public static CharacterIA Instance => _instance;
    private Animator _animator;
    private DamageIA _damage;
    public float health = 100f;
    private AiInput _agent;
    public GameObject objectFlag;

    public void Awake()
    {
        _instance = this;
        _animator = GetComponent<Animator>();
        //_agent = GetComponent<AiInput>();
    }

    private void Start()
    {
        _damage = FindObjectOfType<DamageIA>();
    }

    public void WalkAnimationsIA(float VelX)
    {
        _animator.SetFloat("VelX", VelX);
        if(VelX ==  0) 
        {
            DeactivateDirtyFoots();
        }
    }

    public void IGetDamage(float damageRecive)
    {
        health -= damageRecive;
    }
    public void AttackAnimations(int selector)
    {
        switch(selector)
        {
            case 0: 
                _animator.SetTrigger("Attack1");
                _damage.Atacar(5);
                break;

            case 1: _animator.SetTrigger("Attack2");
                _damage.Atacar(13);
                break;
        }

    }
    public void Die()
    {
        _animator.SetTrigger("Death");
        
        StartCoroutine(Timer());
        Desactivate();
    }
    IEnumerator Timer()
    {
        yield return new WaitForSeconds(1f);
        _animator.SetTrigger("Life");
        health = 100;
    }
    public void ActivateDirtyFoots()
    {
        dirtFoots.Play();
    }
    public void DeactivateDirtyFoots()
    {
        dirtFoots.Stop();
    }
    public void Activate()
    {
        //GameObject objetoInterno = GameObject.Find(objectFlag);
        objectFlag.SetActive(true);
        Debug.Log("bandera");
    }
    public void Desactivate()
    {
        //GameObject objetoInterno = GameObject.Find(objectFlag);
        objectFlag.SetActive(false);
        Debug.Log("bandera");
    }
}
