using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Complete_Controller : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            Debug.Log("Level Complete");
            Level_Manager.Instance.SetCurrentLevelCompleted();
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}
