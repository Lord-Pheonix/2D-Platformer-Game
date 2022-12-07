using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_Complete_Manager : MonoBehaviour
{
    [SerializeField] GameObject Level_Complete_Menu;

    [Header("Level Complete Buttons")]
    [SerializeField] Button nextLevel;
    [SerializeField] Button restart;
    [SerializeField] Button mainmenu;

    private void Awake()
    {
        Level_Complete_Menu.SetActive(false);

        nextLevel.onClick.AddListener(NextLavel);
        restart.onClick.AddListener(Restart);
        mainmenu.onClick.AddListener(MainMenu);
    }

    public void LevelComplete()
    {
        Level_Complete_Menu.SetActive(true);
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
