using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_Complete_Manager : MonoBehaviour
{
    [SerializeField] private GameObject Level_Complete_Menu;

    [Header("Level Complete Buttons")]
    [SerializeField] private Button nextLevel;
    [SerializeField] private Button restart;
    [SerializeField] private Button mainmenu;

    public bool levelCompleted;

    private void Awake()
    {
        Level_Complete_Menu.SetActive(false);
        levelCompleted = false;

        nextLevel.onClick.AddListener(NextLavel);
        restart.onClick.AddListener(Restart);
        mainmenu.onClick.AddListener(MainMenu);
    }

    public void LevelComplete()
    {
        Level_Complete_Menu.SetActive(true);
        levelCompleted = true;
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
