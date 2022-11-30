using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Level_Loader : MonoBehaviour
{
    //Inbuilt Game objects 
    [SerializeField] Button nextLevel;

    //private data members
    [SerializeField] string levelName;

    private void Awake()
    {
        nextLevel = GetComponent<Button>();

        //when button is clicked call Load Next Level function
        nextLevel.onClick.AddListener(LoadNextLevel);
    }

    public void LoadNextLevel()
    {
        LevelStatus levelStatus = Level_Manager.Instance.GetLevelStatus(levelName);

        switch(levelStatus)
        {
            case LevelStatus.Locked    : Debug.Log(levelName + " is locked" );
                                         break;

            case LevelStatus.Unlocked  : SceneManager.LoadScene(levelName);       //load the next level scene as per there build Name
                                         break;

            case LevelStatus.Completed : SceneManager.LoadScene(levelName);
                                         break;
        }

        

    }
}
