using UnityEngine;

public class Player_Death_Controller : MonoBehaviour
{
    [SerializeField] private int enemydamage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<Player_Controller>() != null)
        {
            collision.GetComponent<Player_Health>().LoseLife(enemydamage);
            //Debug.Log("Player got hurt ");
        }
    }
}
