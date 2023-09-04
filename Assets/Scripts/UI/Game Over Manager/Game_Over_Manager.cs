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
        Sound_Manager.Instance.Play(AudioClips.Sfx_LevelButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Sound_Manager.Instance.Play(AudioClips.Sfx_LevelButtonClick);
        SceneManager.LoadScene(0);
    }

    public void Quit()
    {
        Sound_Manager.Instance.Play(AudioClips.Sfx_LevelButtonClick);
        Application.Quit();
    }
}
