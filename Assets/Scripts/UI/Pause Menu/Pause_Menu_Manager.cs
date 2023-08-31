using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Pause_Menu_Manager : MonoBehaviour
{
    [SerializeField] private GameObject PauseMenu;

    [Header("Pause Menu Buttons")]
    [SerializeField] private Button resume;
    [SerializeField] private Button restart;
    [SerializeField] private Button mainmenu;
    [SerializeField] private Button closePauseMenu;

    public static bool GameIsPaused = false;

    private void Awake()
    {
        PauseMenu.SetActive(false);

        resume.onClick.AddListener(Resume);
        restart.onClick.AddListener(Restart);
        mainmenu.onClick.AddListener(MainMenu);
        closePauseMenu.onClick.AddListener(Resume);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        PauseMenu.SetActive(false);
        Time.timeScale = 1f;           //setting the speed of time passing to normal to free the time
        GameIsPaused = false;
    }

    private void Pause()
    {
        PauseMenu.SetActive(true);
        Time.timeScale = 0f;             //setting the speed of time passing to 0 to freeze the time
        GameIsPaused = true;
    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }
}
