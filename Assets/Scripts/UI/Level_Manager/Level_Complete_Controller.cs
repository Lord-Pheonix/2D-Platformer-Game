using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_Complete_Controller : MonoBehaviour
{
    [SerializeField] Canvas levelComplete;

    private void Awake()
    {
        levelComplete.enabled = false;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("Level Complete");
                Level_Manager.Instance.SetCurrentLevelCompleted();
                levelComplete.enabled = true;
            }
        }
    }
}
