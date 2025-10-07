using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoDoctor : MonoBehaviour
{
    [SerializeField] private float speed;

    private Vector2 target;
    private Camera cam;

    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = cam.ScreenToWorldPoint(Input.mousePosition);
        }
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}
