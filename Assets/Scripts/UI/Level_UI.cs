using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_UI : MonoBehaviour
{
    [SerializeField] Main_Menu_Fading main_Menu_Fading;
    [SerializeField] GameObject LevelMenu;

    [SerializeField] private Canvas mainMenuCanvas;
    [SerializeField] private Canvas levelCanvas;

    private void Awake()
    { 
        LevelMenu.SetActive(true);
        levelCanvas.enabled = true;
        mainMenuCanvas.enabled = false;
    }
    public void CloseLevel()
    {
        main_Menu_Fading.FadingOut();
        mainMenuCanvas.enabled = true;
        levelCanvas.enabled = false;
    }

    public void Level1()
    {
        SceneManager.LoadScene(1);
    }
}
