using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Respawn : MonoBehaviour
{
    private Game_Over_Manager game_Over_Manager;

    private void Awake()
    {
        game_Over_Manager = FindObjectOfType<Game_Over_Manager>();
    }

    public void Respawn()
    {
        game_Over_Manager.GameOver();
    }
}
