using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LVL1QuestionsController : MonoBehaviour
{
    [Header("Interfaces del juego (Nivel 1)")]
    public GameObject game;
    public GameObject panelQuestions;
    public GameObject appereanceCanva;
    [Space]

    [Header("Textos")]
    public TMP_Text respuesta;

    public TMP_Text preguntaDocDOBLE1text, preguntaDocDOBLE2text, preguntaDocUnicatext;
    public Button preguntaDobleButton1, preguntaDobleButton2, preguntaUnicaButton;

    [Header("Fondo Tipo Pregunta")]
    public GameObject preguntaDobleGO;
    public GameObject preguntaUnicaGO;

    public static bool isOpenQUESTIONS = false;

    //TIPO
    bool infectado;

    bool esPregunta1, esPregunta2;

    //RAMAS
    bool ramaCotidiana, ramaContactoDirecto, ramaConfusionNeurologica;

    //RIESGOS
    bool riesgoNulo, riesgoMedio, riesgoAlto;

    //PREGUNTAS PRINCIPALES
    string pregunta1 = "Explícame qué estabas haciendo cuando ocurrió la fuga.";
    string pregunta2 = "¿Tuviste contacto físico o te acercaste demasiado al área contaminada o a alguien que entró en ella?";

    //RESPUESTAS PRINCIPALES
    string respuesta1_1 = "Estaba realizando mis tareas rutinarias, no noté nada fuera de lo normal."; //RAMA COTIDIANA
    string respuesta1_2 = "Intenté ayudar. Uno de los tanques tuvo una caída de presión y fui a revisar."; //RAMA CONTACTO DIRECTO
    string respuesta1_3 = "No… no estoy seguro. Fue todo muy rápido, no recuerdo bien el orden."; //RAMA CONFUSIÓN NEUROLÓGICA

    string respuesta2_1 = "Sí, era parte del protocolo. Pero creo estar completamente bien."; //RIESGO ALTO
    string respuesta2_2 = "Tal vez… Había gente moviéndose. Creo que me rozaron en algún momento."; //RIESGO MEDIO
    string respuesta2_3 = "No. Me mantuve a distancia en todo momento."; //RIESGO NULO

    //PREGUNTAS SEGUN RAMA
    string preguntaRamaCotidiana = "Desde la fuga… ¿has sentido alguna molestia o cambio, aunque sea algo pequeño?";
    string preguntaRamaContactoDirecto = "¿Hubo algún tipo de exposición a sangre, fluidos o a la zona dañada del contenedor?";
    string preguntaRamaConfusionNeurologica = "¿Te has sentido raro desde el incidente? Mareos, temblores o problemas para concentrarte.";

    //RESPUESTAS SEGUN PREGUNTA POR RAMAS
    string respuestaCotidiana1 = "No, me siento perfectamente.";
    string respuestaCotidiana2 = "He tenido tensión muscular, además llevo horas en esta silla.";
    string respuestaCotidiana3 = "Sí, un poco de irritación en la piel por los nervios, supongo.";

    string respuestaContactoDirecto1 = "No, solo me acerqué unos segundos a revisar una alarma.";
    string respuestaContactoDirecto2 = "No estoy seguro… me perdí por el ruido de la alarma y gente gritando.";
    string respuestaContactoDirecto3 = "Sí, uno de los tubos reventó y me salpicó un poco, creo que fue mínimo.";

    string respuestaConfusionNeurologica1 = "No, estoy bien… creo… solo necesito un momento.";
    string respuestaConfusionNeurologica2 = "Solo dolor de cabeza. Debe ser estrés.";
    string respuestaConfusionNeurologica3 = "Sí… siento como… nublado. Es difícil explicarlo.";

    //PREGUNTAS SEGUN RIESGO
    string preguntaRiesgoNegado = "¿Qué hizo que no estuvieras en la zona afectada?";
    string preguntaRiesgoMedio = "¿Reconoces a la persona que pudo haber tenido el contacto?¿O a las personas que estaban cerca?";
    string preguntaRiesgoAlto = "¿Consideras que ello puede influir en lo que estás diciendo?";

    //RESPUESTAS SEGUN PREGUNTA POR RIESGO
    string respuestaRiesgoNegado_SospechaBAJA = "Estaba preparando los informes según el protocolo.";
    string respuestaRiesgoNegado_SospechaMEDIA = "Me dió algo de temor, llevo poco tiempo trabajando y es la primera vez que veo algo así.";
    string respuestaRiesgoNegado_SospechaALTA = "Acababa de salir de allí, no vi necesario volver.";

    string respuestaRiesgoMedio_SospechaBAJA = "No recuerdo bien pero creo que era alguien antiguo en el laboratorio";
    string respuestaRiesgoMedio_SospechaMEDIA = "Recuerdo haber visto varias personas salir de la zona pero solo eso..";
    string respuestaRiesgoMedio_SospechaALTA = "No, tengo la mente bastante en blanco ahora mismo.";

    string respuestaRiesgoAlto_SospechaBAJA = "No, estoy conciente de lo que digo, me siento capaz de cualquier actividad intelectual o física.";
    string respuestaRiesgoAlto_SospechaMEDIA = "Estoy nervioso por estar en este cuarto frío, nervioso...";
    string respuestaRiesgoAlto_SospechaALTA = "Yo… ¿Por qué me están juzgando tanto?";

    private void Start()
    {
        respuesta.text = "...";

        panelQuestions.SetActive(false);
        isOpenQUESTIONS = false;

        PreguntaDOBLEGO();

        preguntaDocDOBLE1text.text = pregunta1;
        preguntaDocDOBLE2text.text = pregunta2;
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

    public void PreguntaDOBLEGO()
    {
        preguntaDobleGO.gameObject.SetActive(true);
        preguntaUnicaGO.gameObject.SetActive(false);
    }

    public void PreguntaUNICAGO()
    {
        preguntaDobleGO.gameObject.SetActive(false);
        preguntaUnicaGO.gameObject.SetActive(true);
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
        esPregunta1 = true;
        esPregunta2 = false;

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
        SeleccionRAMA();
        PreguntaUNICAGO();
        preguntaDobleButton1.interactable = false;
    }

    public void Pregunta2() //PREGUNTA PRINCIPAL 2
    {
        esPregunta1 = false;
        esPregunta2 = true;

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
        SeleccionRIESGO();
        PreguntaUNICAGO();
        preguntaDobleButton2.interactable = false;
    }

    public void SeleccionRAMA()
    {
        if (ramaCotidiana == true)
        {
            preguntaDocUnicatext.text = preguntaRamaCotidiana;
        }
        else if (ramaContactoDirecto == true)
        {
            preguntaDocUnicatext.text = preguntaRamaContactoDirecto;
        }
        else if (ramaConfusionNeurologica == true)
        {
            preguntaDocUnicatext.text = preguntaRamaConfusionNeurologica;
        }
    }

    public void SeleccionRespuesta()
    {
        if (esPregunta1 == true)
        {
            SeleccionRespuestaRAMA();
        }
        else if (esPregunta2 == true)
        {
            SeleccionRespuestaRIESGO();
        }
        PreguntaDOBLEGO();
    }


    public void SeleccionRespuestaRAMA()
    {
        if (ramaCotidiana == true)
        {
            PreguntaRamaCOTIDIANA();
        }
        else if (ramaContactoDirecto == true)
        {
            PreguntaRamaCDIRECTO();
        }
        else if (ramaConfusionNeurologica == true)
        {
            PreguntaRamaCNEUROLOGICA();
        }

        PreguntaDOBLEGO();
    }

    public void PreguntaRamaCOTIDIANA()
    {
        int numRndm = Random.Range(1, 4);
        Debug.Log(numRndm);

        if (numRndm == 1)
        {
            respuesta.text = respuestaCotidiana1;
        }
        else if (numRndm == 2)
        {
            respuesta.text = respuestaCotidiana2;
        }
        else if (numRndm == 3)
        {
            respuesta.text = respuestaCotidiana3;
        }
    }

    public void PreguntaRamaCDIRECTO()
    {
        if (infectado == false) //Si no está infectado
        {
            int numRndm = Random.Range(1, 3);
            Debug.Log(numRndm);

            if (numRndm % 2 == 0) //Si es par, sosprecha baja
            {
                respuesta.text = respuestaContactoDirecto1;
            }
            else //Si es impar, respuesta sospecha media
            {
                respuesta.text = respuestaContactoDirecto2;
            }
        }
        else //SI ESTA INFECTADO
        {
            int numRndm = Random.Range(1, 3);
            Debug.Log(numRndm);

            if (numRndm % 2 == 0) //Si es par, respuesta sospecha media
            {
                respuesta.text = respuestaContactoDirecto2;
            }
            else //Si es impar, respuesta sospecha muy alta
            {
                respuesta.text = respuestaContactoDirecto3;
            }
        }
    }

    public void PreguntaRamaCNEUROLOGICA()
    {
        int numRndm = Random.Range(1, 4);
        Debug.Log(numRndm);

        if (numRndm == 1)
        {
            respuesta.text = respuestaConfusionNeurologica1;
        }
        else if (numRndm == 2)
        {
            respuesta.text = respuestaConfusionNeurologica2;
        }
        else if (numRndm == 3)
        {
            respuesta.text = respuestaConfusionNeurologica3;
        }
    }

    public void SeleccionRIESGO()
    {
        if (riesgoNulo == true)
        {
            preguntaDocUnicatext.text = preguntaRiesgoNegado;
        }
        else if (riesgoMedio == true)
        {
            preguntaDocUnicatext.text = preguntaRiesgoMedio;
        }
        else if (riesgoAlto == true)
        {
            preguntaDocUnicatext.text = preguntaRiesgoAlto;
        }
    }

    public void SeleccionRespuestaRIESGO()
    {
        if (riesgoNulo == true)
        {
            RespuestaRiesgoNEGADO();
        }
        else if (riesgoMedio == true)
        {
            RespuestaRiesgoMEDIO();
        }
        else if (riesgoAlto == true)
        {
            RespuestaRiesgoALTO();
        }
    }

    public void RespuestaRiesgoNEGADO()
    {
        int numRndm = Random.Range(1, 4);
        Debug.Log(numRndm);

        if (numRndm == 1)
        {
            respuesta.text = respuestaRiesgoNegado_SospechaBAJA;
        }
        else if (numRndm == 2)
        {
            respuesta.text = respuestaRiesgoNegado_SospechaMEDIA;
        }
        else if (numRndm == 3)
        {
            respuesta.text = respuestaRiesgoNegado_SospechaALTA;
        }
    }

    public void RespuestaRiesgoMEDIO()
    {
        int numRndm = Random.Range(1, 4);
        Debug.Log(numRndm);

        if (numRndm == 1)
        {
            respuesta.text = respuestaRiesgoMedio_SospechaBAJA;
        }
        else if (numRndm == 2)
        {
            respuesta.text = respuestaRiesgoMedio_SospechaMEDIA;
        }
        else if (numRndm == 3)
        {
            respuesta.text = respuestaRiesgoMedio_SospechaALTA;
        }
    }

    public void RespuestaRiesgoALTO()
    {
        int numRndm = Random.Range(1, 4);
        Debug.Log(numRndm);

        if (numRndm == 1) 
        {
            respuesta.text = respuestaRiesgoAlto_SospechaBAJA;
        }
        else if (numRndm == 2) 
        {
            respuesta.text = respuestaRiesgoAlto_SospechaMEDIA;
        }
        else if (numRndm == 3)
        {
            respuesta.text = respuestaRiesgoAlto_SospechaALTA;
        }
    }
}