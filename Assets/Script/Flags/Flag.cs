using UnityEngine;

public class Flag : MonoBehaviour
{
    public bool follow = false;
    [SerializeField] private GameObject flag;

    private void OnTriggerEnter(Collider collision)
    {
       flag.gameObject.SetActive(false);
    }
}
