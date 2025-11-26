using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPanel : MonoBehaviour
{

    [SerializeField] private Sistemapreguntas sistemaPreguntas;

    private void OnMouseDown()
    {
        sistemaPreguntas.AbrirPanel();
    }


}