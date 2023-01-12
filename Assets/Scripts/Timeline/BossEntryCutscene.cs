using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class BossEntryCutscene : MonoBehaviour
{
    [SerializeField] PlayableDirector BossEntry;
    [SerializeField] GameObject MainCamera;
    [SerializeField] GameObject TimelineCamera;
    [SerializeField] GameObject player;

    private void Start()
    {
        BossEntry.GetComponent<PlayableDirector>();
        BossEntry.enabled = false;
        TimelineCamera.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player_Controller>() != null )
        {
            BossEntry.enabled = true;
            if(this.enabled)
            {
                MainCamera.SetActive(false);
                TimelineCamera.SetActive(true);
                BossEntry.Play();
                player.GetComponent<Player_Controller>().speed = 0f;
            }   
        }
    }

    public void OnEnable()
    {
        BossEntry.stopped += OnPlayableDirectorStopped;
        Debug.Log("PlayableDirector is playing.");
    }

    void OnPlayableDirectorStopped(PlayableDirector aDirector)
    {
        if (BossEntry == aDirector)
        {
            Debug.Log("PlayableDirector named " + aDirector.name + " is now stopped.");
            BossEntry.enabled = false;
            MainCamera.SetActive(true);
            TimelineCamera.SetActive(false);
            player.GetComponent<Player_Controller>().speed = 1f;
            this.enabled = false;
        }
    }

    void OnDisable()
    {
        BossEntry.stopped -= OnPlayableDirectorStopped;
        Debug.Log("PlayableDirector is not playing.");
    }
}
