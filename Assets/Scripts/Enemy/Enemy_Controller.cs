using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class Enemy_Controller : MonoBehaviour
{
    [SerializeField] private List<Transform> points;
    [SerializeField] private float speed = 1.5f;

    private int nextPoint = 0;
    private int ChangePointValue = 1;
    

    private void Update()
    {
        MoveToNextPoint();
    }

    private void Reset()
    {
        CreatingGameobject();
    }

    void MoveToNextPoint()
    {
        //Get the next Point transform
        Transform FinalPoint = points[nextPoint];

        //flip the enemy transformation to look into the point's direction
        Vector3 scale = transform.localScale;
        if (FinalPoint.transform.position.x > transform.position.x)
        {
            scale.x = 1f * Mathf.Abs(scale.x);
        }
        else
        {
            scale.x = -1f * Mathf.Abs(scale.x);
        }
        transform.localScale = scale;

        //move the enemy towards the goal point
        transform.position = Vector2.MoveTowards(transform.position,FinalPoint.position,speed*Time.deltaTime);

        //check the distance between enemy and goal point to trigger next point
        if(Vector2.Distance(transform.position, FinalPoint.position) < 0.1f)
        {
            //check if we are at the end of the line( make the change -1)
            if(nextPoint == points.Count - 1 )
            {
                ChangePointValue = -1;
            }
            //check if we are at the start of the line( make the change +1)
            if(nextPoint == 0)
            {
                ChangePointValue = 1;
            }
            nextPoint = nextPoint + ChangePointValue;
        }
    }

    void CreatingGameobject()
    {
        //It will enable isTrigger
        GetComponent<BoxCollider2D>().isTrigger = true;

        //Create Root object
        GameObject root = new GameObject("Enemy1");

        //Reset Position of Root to enemy object
        root.transform.position = transform.position;

        //Set enemy object as child of root
        transform.SetParent(root.transform);

        //create waypoints object
        GameObject waypoints = new GameObject("Waypoints");

        //Reset waypoint position to root and Make waypoints object child of root
        waypoints.transform.SetParent(root.transform);
        waypoints.transform.position = root.transform.position;

        //Create two points and reset their position to waypoints object and Make the points children of waypoint object
        GameObject Point1 = new GameObject("Point 1");
        Point1.transform.SetParent(waypoints.transform);
        Point1.transform.position = root.transform.position;


        GameObject Point2 = new GameObject("Point 2");
        Point2.transform.SetParent(waypoints.transform);
        Point2.transform.position = root.transform.position;

        //Init points in list then add the point to it
        points = new List<Transform>
        {
            Point1.transform,
            Point2.transform
        };
    }
}
