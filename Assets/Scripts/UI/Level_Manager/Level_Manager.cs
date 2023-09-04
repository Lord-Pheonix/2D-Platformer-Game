using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Manager : MonoBehaviour
{
    private static Level_Manager instance;
    public static Level_Manager Instance {  get { return instance; } }

    [SerializeField] private string[] totalLevel;

    public string[] TotalLevel { get { return totalLevel; } }

    private void Awake()
    {
        if(instance == null)    //checking if instance is null 
        {
            instance = this;   //pointing to the current gameobject where this script is attached
            DontDestroyOnLoad(gameObject);   //to not destroy this gameobject through the whole game
        }
        else
        {
            Destroy(gameObject);    //and if this script is not attacthed to the other gameobject then destroy those gameobject
        }
    }

    private void Start()
    {
        if (GetLevelStatus(totalLevel[0]) == LevelStatus.Locked)  //checking the status of first level if its locked then unlock it
        {
            SetLevelStatus(totalLevel[0], LevelStatus.Unlocked); // making first level as unlocked
        }
    }

    // creating a public getlevelstatus function where this function coming from levelstatus script which accept one parameter as string level name which take the scenes name present in game  
    public LevelStatus GetLevelStatus(string levelName)     
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(levelName);  // To get the staus of a level 
        return levelStatus;               //it will return the status of level as locked , unlocked or completed 
    }

    public void SetLevelStatus(string levelName, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(levelName, (int)levelStatus);  //It will set the level status
        //Debug.Log("Setting " + levelName + " Status to : " + levelStatus);
    }

    public void SetCurrentLevelCompleted()
    {
        Scene currentScene = SceneManager.GetActiveScene();   //it will get the current active scene 

        //set level status to complete
        SetLevelStatus(currentScene.name, LevelStatus.Completed);      

        //unlock the next level
        int currentSceneIndex = Array.FindIndex(totalLevel, level => level == currentScene.name);      //it will find the index of scene based on its name

        int nextSceneIndex = currentSceneIndex + 1;             //increment the curent scene index (ex. if current scene index = 0 then next scene should be 1)
        
        
        if(nextSceneIndex < totalLevel.Length)           //checking if current scene index is less than all scene present in game 
        {
            SetLevelStatus(totalLevel[nextSceneIndex], LevelStatus.Unlocked);    //it will set the status of next level as unlocked
        }
    }
}
