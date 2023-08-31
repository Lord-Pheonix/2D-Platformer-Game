using UnityEngine;
using UnityEngine.UI;

public class Game_Menu_Manager: MonoBehaviour
{
    [Header("Game Menu Objects")]
    [SerializeField] private MainMenu_Background MainMenu_Background;    //object Coming from MainMenu_Background script
    [SerializeField] private GameObject MainMenu, levelMenu;        

    [Header("Main Menu Buttons")]
    [SerializeField] private Button startGame;
    [SerializeField] private Button quitGame;

    [Header("Level Menu Buttons")]
    [SerializeField] private Button quitLevelMenu;

    private void Start()
    {
        Sound_Manager.Instance.PlayMusic(AudioClips.music_BackgroundMusic);
    }

    private void Awake()
    {
        //set Mainmenu gameobject to true and levelmenu to false when first time the game run
        levelMenu.SetActive(false);
        MainMenu.SetActive(true);

        startGame.onClick.AddListener(StartGame);               //when button is clicked call Start Game function
        quitGame.onClick.AddListener(Quit);                     //when button is clicked call quit function
        quitLevelMenu.onClick.AddListener(CloseLevelMenu);      //when button is clicked call close Level Menu function
        
    }

    private void Update()
    {
        if(levelMenu == true)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                CloseLevelMenu();
            }
        }
    }

    public void StartGame()  //this function will take us to level menu
    {
        //call Fading In animation which is present main menu fading script
        MainMenu_Background.FadingIn();

        //set Main menu object to false and level menu to true
        Sound_Manager.Instance.Play(AudioClips.sfx_StarButtonClick);
        levelMenu.SetActive(true);
        MainMenu.SetActive(false);
    }

    public void Quit()  //this function will quit the whole game 
    {
        Application.Quit();
    }

    public void CloseLevelMenu()   //this function will used in Level menu to close it
    {
        //call Fading Out animation which is present main menu fading script
        MainMenu_Background.FadingOut();

        //set Main menu object to true and level menu to false
        MainMenu.SetActive(true);
        levelMenu.SetActive(false);
    }
}
