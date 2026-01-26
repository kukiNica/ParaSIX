using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LVL1QuestionsController : MonoBehaviour
{
    [Header("Interfaces del juego (Nivel 1)")]
    public GameObject game;
    public GameObject panelQuestions;
    public GameObject appereanceCanva;
    [Space]

    [Header("Textos")]
    public TMP_Text respuesta;

    public TMP_Text preguntaDoc1, preguntaDoc2, preguntaDoc3;

    public static bool isOpenQUESTIONS = false;

    //TIPO
    bool infectado;

    //RAMAS
    bool ramaCotidiana, ramaContactoDirecto, ramaConfusionNeurologica;

    //RIESGOS
    bool riesgoNulo, riesgoMedio, riesgoAlto;

    //PREGUNTAS PRINCIPALES
    string pregunta1 = "Explícame qué estabas haciendo cuando ocurrió la fuga.";
    string pregunta2 = "¿Tuviste contacto físico o te acercaste demasiado al área contaminada o a aklguien que entró en ella?";

    //RESPUESTAS PRINCIPALES
    string respuesta1_1 = "Estaba realizando mis tareas rutinarias, no noté nada fuera de lo normal."; //RAMA COTIDIANA
    string respuesta1_2 = "Intenté ayudar. Uno de los tanques tuvo una caída de presión y fui a revisar."; //RAMA CONTACTO DIRECTO
    string respuesta1_3 = "No… no estoy seguro. Fue todo muy rápido, no recuerdo bien el orden."; //RAMA CONFUSIÓN NEUROLÓGICA

    string respuesta2_1 = "Sí, era parte del protocolo. Pero estoy completamente bien.”";
    string respuesta2_2 = "Tal vez… Había mucha gente moviéndose. Creo que me rozaron en algún momento.";
    string respuesta2_3 = "No. Me mantuve a distancia en todo momento.";

    //PREGUNTAS SEGUN RAMA
    string preguntaRamaCotidiana = "Desde la fuga… ¿has sentido alguna molestia o cambio, aunque sea algo pequeño?";
    string preguntaRamaContactoDirecto = "¿Hubo algún tipo de exposición a sangre, fluidos o a la zona dañada del contenedor?";
    string preguntaRamaConfusionNeurologica = "¿Te has sentido raro desde el incidente? Mareos, temblores o problemas para concentrarte.";

    //RESPUESTAS SEGUN PREGUNTA
    string respuestaCotidiana1 = "Sí, un poco de irritación en la piel por los nervios, supongo.";
    string respuestaCotidiana2 = "He tenido tensión muscular, pero llevo horas en esta silla.";
    string respuestaCotidiana3 = "No, me siento perfectamente.";

    string respuestaContactoDirecto1 = "Sí, uno de los tubos reventó y me salpicó un poco, pero fue mínimo.";
    string respuestaContactoDirecto2 = "No estoy seguro… Había vapor, golpes, gente gritando.";
    string respuestaContactoDirecto3 = "No, solo me acerqué unos segundos a revisar una alarma.";

    string respuestaConfusionNeurologica1 = "Sí… siento como… nublado. Es difícil explicarlo.";
    string respuestaConfusionNeurologica2 = "Solo dolor de cabeza. Debe ser estrés.";
    string respuestaConfusionNeurologica3 = "No, estoy bien… creo… solo necesito un momento.";

    private void Start()
    {
        panelQuestions.SetActive(false);
        isOpenQUESTIONS = false;

        preguntaDoc1.text = pregunta1;
        preguntaDoc2.text = pregunta2;
    }

    void Update()
    {
        if ((Input.GetKeyDown(KeyCode.E)) && isOpenQUESTIONS == false)
        {
            if ((SceneManager.GetActiveScene().name == "Level 1") && Level1Controller.isClose == true)
            {
                OpenQUESTIONS();
            }
        }
        else if ((Input.GetKeyDown(KeyCode.E)) && isOpenQUESTIONS == true)
        {
            CloseQUESTIONS();
        }
    }

    //CONTROLADOR DE CANVAS - JERARQUÍA (QUE APAREZCAN)
    public void OpenQUESTIONS()
    {
        panelQuestions.SetActive(true);
        isOpenQUESTIONS = true;

        game.SetActive(false);
    }

    public void CloseQUESTIONS()
    {
        panelQuestions.SetActive(false);
        isOpenQUESTIONS = false;

        game.SetActive(true);

        appereanceCanva.SetActive(false);
        AppereanceController.isOpenAP = false;
    }

    //DISTRIBUCIÓN DE RAMAS (Para saber en que rama tiene que ir y en cuál no).
    public void RamaCOTIDIANA() 
    {
        ramaCotidiana = true;
        ramaContactoDirecto = false;
        ramaConfusionNeurologica = false;
    }

    public void RamaCONTACTODIRECTO()
    {
        ramaCotidiana = false;
        ramaContactoDirecto = true;
        ramaConfusionNeurologica = false;
    }

    public void RamaCONFUSIONNEUROLOGICA()
    {
        ramaCotidiana = false;
        ramaContactoDirecto = false;
        ramaConfusionNeurologica = true;
    }

    //DISTRIBUCIÓN DE RIESGOS (Para saber en que riesgo tiene que ir y en cuál no)
    public void RiesgoNULO()
    {
        riesgoAlto = false;
        riesgoMedio = false;
        riesgoNulo = true;
    }

    public void RiesgoMEDIO()
    {
        riesgoAlto = false;
        riesgoMedio = true;
        riesgoNulo = false;
    }

    public void RiesgoALTO()
    {
        riesgoAlto = true;
        riesgoMedio = false;
        riesgoNulo = false;
    }


    public void Pregunta1() //PREGUNTA PRINCIPAL 1
    {
        if (infectado == false) //Si no está infectado
        {
            int numRndm = Random.Range(1, 3);
            Debug.Log(numRndm);

            if (numRndm % 2 == 0) //Si es par, respuesta cotidiana
            {
                respuesta.text = respuesta1_1;
                RamaCOTIDIANA();
            }
            else //Si es impar, respuesta contacto directo
            {
                respuesta.text = respuesta1_2;
                RamaCONTACTODIRECTO();
            }
        }
        else //SI ESTA INFECTADO
        {
            int numRndm = Random.Range(1, 3);
            Debug.Log(numRndm);

            if (numRndm % 2 == 0) //Si es par, respuesta contacto directo
            {
                respuesta.text = respuesta1_2;
                RamaCONTACTODIRECTO();
            }
            else //Si es impar, respuesta confusión neurológica
            {
                respuesta.text = respuesta1_3;
                RamaCONFUSIONNEUROLOGICA();
            }
        }
    }

    public void Pregunta2() //PREGUNTA PRINCIPAL 2
    {
        if (infectado == false) //Si no está infectado
        {
            int numRndm = Random.Range(1, 3);
            Debug.Log(numRndm);

            if (numRndm % 2 == 0) //Si es par, respuesta riesgo nulo
            {
                respuesta.text = respuesta2_1;
                RiesgoNULO();
            }
            else //Si es impar, respuesta riesgo medio
            {
                respuesta.text = respuesta2_2;
                RiesgoMEDIO();
            }
        }
        else //SI ESTA INFECTADO
        {
            int numRndm = Random.Range(1, 3);
            Debug.Log(numRndm);

            if (numRndm % 2 == 0) //Si es par, respuesta riesgo medio
            {
                respuesta.text = respuesta2_2;
                RiesgoMEDIO();
            }
            else //Si es impar, respuesta riesgo alto
            {
                respuesta.text = respuesta2_3;
                RiesgoALTO();
            }
        }
    }

    public void PreguntaRamaCOTIDIANA()
    {
        if (infectado == false) //Si no está infectado
        {
            int numRndm = Random.Range(1, 3);
            Debug.Log(numRndm);

            if (numRndm % 2 == 0) //Si es par, sosprecha baja
            {
                respuesta.text = respuestaCotidiana1;
            }
            else //Si es impar, respuesta sospecha media
            {
                respuesta.text = respuestaCotidiana2;
            }
        }
        else //SI ESTA INFECTADO
        {
            int numRndm = Random.Range(1, 3);
            Debug.Log(numRndm);

            if (numRndm % 2 == 0) //Si es par, respuesta sospecha media
            {
                respuesta.text = respuestaCotidiana2;
            }
            else //Si es impar, respuesta sospecha muy alta
            {
                respuesta.text = respuestaCotidiana3;
            }
        }
    }
}
