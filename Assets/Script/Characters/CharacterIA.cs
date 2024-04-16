
using UnityEngine;


public class CharacterIA : MonoBehaviour
{
    [SerializeField] private ParticleSystem dirtFoots;
    private static CharacterIA _instance;
    public static CharacterIA Instance => _instance;
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
