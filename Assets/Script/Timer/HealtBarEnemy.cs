using UnityEngine;
using UnityEngine.UI;


public class HealtBarEnemy : MonoBehaviour
{
    public Slider HealtBar;
    private Timer timer;
    private float maxHealth = 100;
    void Start()
    {
        timer = FindObjectOfType<Timer>();
    }


    void Update()
    {
        float mappedHealth = Mathf.Clamp01(timer.EnemyHealth / maxHealth);
        HealtBar.value = mappedHealth;

        print(mappedHealth);

    }


}
