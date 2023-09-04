using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_Complete_Manager : MonoBehaviour
{
    [SerializeField] private GameObject level_Complete_Menu;
    [SerializeField] private GameObject game_Complete_Menu;

    [Header("Level Complete Buttons")]
    [SerializeField] private Button nextLevel;
    [SerializeField] private Button restart;
    [SerializeField] private Button mainmenu;

    public bool levelCompleted;

    private void Awake()
    {
        level_Complete_Menu.SetActive(false);
        game_Complete_Menu.SetActive(false);
        levelCompleted = false;

        nextLevel.onClick.AddListener(NextLavel);
        restart.onClick.AddListener(Restart);
        mainmenu.onClick.AddListener(MainMenu);
    }

    public void LevelComplete()
    {
        level_Complete_Menu.SetActive(true);
        levelCompleted = true;
    }

    public void GameComplete()
    {
        game_Complete_Menu?.SetActive(true);
        levelCompleted = true;
    }

    public void NextLavel()
    {
        Sound_Manager.Instance.Play(AudioClips.Sfx_LevelButtonClick);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
}
