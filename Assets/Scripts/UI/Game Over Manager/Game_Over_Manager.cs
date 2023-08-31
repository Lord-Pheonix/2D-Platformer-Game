using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Over_Manager : MonoBehaviour
{
    [SerializeField] private GameObject gameOverScreen;

    [Header("GameOver Menu Buttons")]
    [SerializeField] private Button restart;
    [SerializeField] private Button mainmenu;
    [SerializeField] private Button quit;

    private void Awake()
    {
        gameOverScreen.SetActive(false);


        restart.onClick.AddListener(Restart);
        mainmenu.onClick.AddListener(MainMenu);
        quit.onClick.AddListener(Quit);
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    { 
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Application.Quit();
    }
}
