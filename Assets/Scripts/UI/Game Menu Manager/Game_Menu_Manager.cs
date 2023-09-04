using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Game_Menu_Manager: MonoBehaviour
{
    [Header("Game Menu Objects")]
    [SerializeField] private MainMenu_Background MainMenu_Background;    //object Coming from MainMenu_Background script
    [SerializeField] private GameObject MainMenu, levelMenu, controlMenu;
    [SerializeField] private int CreditSceneIndex;

    [Header("Main Menu Buttons")]
    [SerializeField] private Button startGame;
    [SerializeField] private Button controlButton;
    [SerializeField] private Button creditButton;
    [SerializeField] private Button quitGame;

    [Header("Level Menu Buttons")]
    [SerializeField] private Button quitLevelMenu;
    [SerializeField] private Button closeControlMenu;
    [SerializeField] private Button resetLevels;

    private void Start()
    {
        Sound_Manager.Instance.PlayMusic(AudioClips.Music_MainMenuBackgroundMusic);
    }

    private void Awake()
    {
        //set Mainmenu gameobject to true and levelmenu to false when first time the game run
        levelMenu.SetActive(false);
        controlMenu.SetActive(false);
        MainMenu.SetActive(true);

        startGame.onClick.AddListener(StartGame);               //when button is clicked call Start Game function
        controlButton.onClick.AddListener(GameControls);
        creditButton.onClick.AddListener(LoadCreditScene);
        quitGame.onClick.AddListener(Quit);                     //when button is clicked call quit function
        quitLevelMenu.onClick.AddListener(CloseMenu);      //when button is clicked call close Level Menu function
        closeControlMenu.onClick.AddListener(CloseMenu);
        resetLevels.onClick.AddListener(ResetLevels);
    }

    private void Update()
    {
        if(levelMenu == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CloseMenu();
            }
        }   
    }

    public void StartGame()  //this function will take us to level menu
    {
        //call Fading In animation which is present main menu fading script
        MainMenu_Background.FadingIn();

        //set Main menu object to false and level menu to true
        Sound_Manager.Instance.Play(AudioClips.Sfx_StartButtonClick);
        levelMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void GameControls()
    {
        MainMenu_Background.FadingIn();

        Sound_Manager.Instance.Play(AudioClips.Sfx_StartButtonClick);
        controlMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void LoadCreditScene()
    {
        Sound_Manager.Instance.Play(AudioClips.Sfx_StartButtonClick);
        SceneManager.LoadScene(CreditSceneIndex);
    }

    public void Quit()  //this function will quit the whole game 
    {
        Sound_Manager.Instance.Play(AudioClips.Sfx_StartButtonClick);
        Application.Quit();
    }

    public void CloseMenu()   //this function will used in Level menu to close it
    {
        //call Fading Out animation which is present main menu fading script
        MainMenu_Background.FadingOut();

        //set Main menu object to true and level menu to false
        Sound_Manager.Instance.Play(AudioClips.Sfx_BackButtonClick);
        MainMenu.SetActive(true);
        levelMenu.SetActive(false);
        controlMenu.SetActive(false);
    }

    private void ResetLevels()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.Save();
        Level_Manager.Instance.SetLevelStatus(Level_Manager.Instance.TotalLevel[0], LevelStatus.Unlocked);
    }
}
