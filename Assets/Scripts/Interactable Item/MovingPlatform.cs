using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] List<Transform> points;
    [SerializeField] float speed = 1.5f;
    int nextPoint = 0;
    int ChangePointValue = 1;
    
    private void Update()
    {
        MoveToNextPoint();
    }

    void MoveToNextPoint()
    {
        //Get the next Point transform
        Transform FinalPoint = points[nextPoint];

        //move the enemy towards the goal point
        transform.position = Vector2.MoveTowards(transform.position, FinalPoint.position, speed * Time.deltaTime);

        //check the distance between enemy and goal point to trigger next point
        if (Vector2.Distance(transform.position, FinalPoint.position) < 0.1f)
        {
            //check if we are at the end of the line( make the change -1)
            if (nextPoint == points.Count - 1)
            {
                ChangePointValue = -1;
            }
            //check if we are at the start of the line( make the change +1)
            if (nextPoint == 0)
            {
                ChangePointValue = 1;
            }
            nextPoint = nextPoint + ChangePointValue;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
            collision.collider.transform.SetParent(transform);
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player_Controller>() != null)
            collision.collider.transform.SetParent(null);
    }
}
