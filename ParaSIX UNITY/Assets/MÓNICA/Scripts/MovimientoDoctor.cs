using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class MovimientoDoctor : MonoBehaviour
{
    float velocity = 2.5f;
    public Animator animator;
    public SpriteRenderer doc;

    void Update()
    {
        Movement();
    }

    public void Movement()
    {
        float velocityX = Input.GetAxis("Horizontal") * velocity*Time.deltaTime;
        float velocityY = Input.GetAxis("Vertical") * velocity;

        Vector2 position = transform.position;
        transform.position = new Vector2(velocityX + position.x, position.y);

        if (Input.GetButtonDown("Horizontal"))
        {
            animator.SetBool("isWalking", true);
            if (velocityX >= 0)
            {
                doc.flipX = false;
            }
            else if (velocityX < 0)
            {
                doc.flipX = true;
            }
        }

        if (Input.GetButtonUp("Horizontal"))
        {
            animator.SetBool("isWalking", false);
        }
        Debug.Log(velocityX);
    }
}
