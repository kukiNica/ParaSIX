using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoDoctor : MonoBehaviour
{
    [SerializeField] private float speed;

    float velocityX;

    private List<Vector2> waypoints = new List<Vector2>();
    private Vector2 newWaypoint;
    private Camera cam;

    int cont = 0;

    void Start()
    {
        cam = Camera.main;
    }

    void Update()
    {
        /*if (cont < 3)
        {
            if (Input.GetMouseButtonDown(0))
            {
                newWaypoint = cam.ScreenToWorldPoint(Input.mousePosition);
                waypoints.Add(newWaypoint);
                cont++;
                Debug.Log(cont);
            }
        }*/

        if (Input.GetMouseButtonDown(0))
        {
            newWaypoint = cam.ScreenToWorldPoint(Input.mousePosition);
            waypoints.Add(newWaypoint);
            cont++;
        }

        Move();
    }

    private void Move()
    {
        if (waypoints.Count == 0)
        {
            return;
        }

        velocityX = transform.position.x * speed;

        transform.position = Vector2.MoveTowards(transform.position, newWaypoint, speed * Time.deltaTime);

        
        if ((Vector2)transform.position == waypoints[0])
        {
            waypoints.RemoveAt(0);
            cont--;
        }
    }

    /*
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        foreach(Vector2 waypoint in waypoints)
        {
            Gizmos.DrawSphere(waypoint, 0.1f);
        }
    }*/

    
}
