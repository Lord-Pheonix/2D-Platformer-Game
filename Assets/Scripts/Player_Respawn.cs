using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Respawn : MonoBehaviour
{
    private UI_Manager uiManager;

    private void Awake()
    {
        uiManager = FindObjectOfType<UI_Manager>();
    }

    public void Respawn()
    {
        uiManager.GameOver();
    }
}
