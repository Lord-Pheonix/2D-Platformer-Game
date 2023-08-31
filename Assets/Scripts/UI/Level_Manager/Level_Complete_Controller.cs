using UnityEngine;

public class Level_Complete_Controller : MonoBehaviour
{
    [SerializeField] private Level_Complete_Manager Level_Complete_Manager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            //Debug.Log("Level Complete");
            Level_Manager.Instance.SetCurrentLevelCompleted();
            Level_Complete_Manager.LevelComplete();
        }
    }
}