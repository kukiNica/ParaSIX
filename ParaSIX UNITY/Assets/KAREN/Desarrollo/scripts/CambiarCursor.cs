using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarCursor : MonoBehaviour
{
 

    public Texture2D cursorHand; // La textura del cursor (por ejemplo, una mano)
    private Texture2D cursorDefault;

    private void Start()
    {
        // Guardamos el cursor original
        cursorDefault = null; // Usa null si el cursor por defecto es el del sistema
    }

    private void OnMouseEnter()
    {
        Cursor.SetCursor(cursorHand, Vector2.zero, CursorMode.Auto);
    }

    private void OnMouseExit()
    {
        Cursor.SetCursor(cursorDefault, Vector2.zero, CursorMode.Auto);
    }
}


