using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main_Menu_UI : MonoBehaviour
{
    [SerializeField] Main_Menu_Fading main_Menu_Fading;

    [SerializeField] private Canvas mainMenuCanvas;
    [SerializeField] private Canvas levelCanvas;

    private void Awake()
    {
        mainMenuCanvas.enabled = true;
        levelCanvas.enabled = false;
    }
    public void StartGame()
    {
        main_Menu_Fading.Fading();
        mainMenuCanvas.enabled = false;
        levelCanvas.enabled = true;
    }

    public void Quit()
    {
        Application.Quit();
    }
}
