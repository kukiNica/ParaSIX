using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navegacion : MonoBehaviour
{
    [SerializeField] private Sistemapreguntas sistemaPreguntas;

        private void Start()
        {
            sistemaPreguntas.AbrirPanel();
        }
   



}

