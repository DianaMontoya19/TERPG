using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FuncionMenu : MonoBehaviour
{
    [SerializeField] GameObject optionsWindow;
    [SerializeField] GameObject creditsWindow;

    public void Start()
    {
        optionsWindow.SetActive(false);
        creditsWindow.SetActive(false);
    }

    public void Options()
    {
        optionsWindow.SetActive(true);
    }

    public void GoBackOptions()
    {
        optionsWindow.SetActive(false);
    }

    public void Credits()
    {
        creditsWindow.SetActive(true);
    }

    public void GoBackCredits()
    {
        creditsWindow.SetActive(false);
    }
}