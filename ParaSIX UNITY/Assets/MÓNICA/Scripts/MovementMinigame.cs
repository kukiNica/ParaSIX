using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementMinigame : MonoBehaviour
{
    float velocity = 0.1f;

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        float velocityX = Input.GetAxis("Horizontal") * velocity;
        float velocityY = Input.GetAxis("Vertical") * velocity;

        Vector2 position = transform.position;

        transform.position = new Vector2(velocityX + position.x, velocityY + position.y);
    }
}
