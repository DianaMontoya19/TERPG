using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterIA : MonoBehaviour
{
    [SerializeField] private ParticleSystem dirtFoots;

    private Animator _animator;

    public void Awake()
    {
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
}
