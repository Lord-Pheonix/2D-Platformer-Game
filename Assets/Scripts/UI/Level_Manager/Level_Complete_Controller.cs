using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Complete_Controller : MonoBehaviour
{
    [SerializeField] private Level_Complete_Manager Level_Complete_Manager;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            if (SceneManager.GetActiveScene().buildIndex == 4)
            {
                Level_Complete_Manager.GameComplete();
                Invoke(nameof(LoadCreditScene), 1f);
            }
            else
            {
                //Debug.Log("Level Complete");
                Sound_Manager.Instance.Play(AudioClips.Sfx_PlayerVictory);
                Level_Manager.Instance.SetCurrentLevelCompleted();
                Level_Complete_Manager.LevelComplete();
            }
        }
    }

    private void LoadCreditScene()
    {
        //Debug.Log("level Complete");
        SceneManager.LoadScene(5);
    }
}