using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MovimientoDoctor : MonoBehaviour
{
    float velocity = 0.05f;

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        float velocityX = Input.GetAxis("Horizontal") * velocity;
        float velocityY = Input.GetAxis("Vertical") * velocity;

        Vector2 position = transform.position;

        transform.position = new Vector2(velocityX + position.x, position.y);
    }
}
