using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_Complete_Manager : MonoBehaviour
{
    [Header("Level Complete Buttons")]
    [SerializeField] Button nextLevel;
    [SerializeField] Button restart;
    [SerializeField] Button mainmenu;

    private void Awake()
    {
        nextLevel.onClick.AddListener(NextLavel);
        restart.onClick.AddListener(Restart);
        mainmenu.onClick.AddListener(MainMenu);
    }

    public void NextLavel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
