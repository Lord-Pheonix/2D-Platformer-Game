using UnityEngine;

public class Player_Death_Controller : MonoBehaviour
{
    [SerializeField] private int enemydamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            Sound_Manager.Instance.Play(AudioClips.Sfx_PlayerHurt);
            collision.GetComponent<Player_Health>().LoseLife(enemydamage);
            //Debug.Log("Player got hurt ");
        }
    }
}