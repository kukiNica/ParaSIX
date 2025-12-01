using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Entrance2"))
        {
            Debug.Log("Entrance");
            SceneManager.LoadScene("Level 2");
        }
        else if (collision.CompareTag("Entrada1"))
        {
            Debug.Log("entrada");
            SceneManager.LoadScene("Diseño de Nivel 1");
        }
        else if (collision.CompareTag("Entrance3"))
        {
            SceneManager.LoadScene("Level 3");
        }
       
    }
}
