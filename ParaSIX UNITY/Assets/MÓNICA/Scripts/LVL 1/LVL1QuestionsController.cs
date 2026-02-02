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

    //RESPUESTAS SEGUN PREGUNTA POR RAMAS
    string respuestaCotidiana1 = "Sí, un poco de irritación en la piel por los nervios, supongo.";
    string respuestaCotidiana2 = "He tenido tensión muscular, pero llevo horas en esta silla.";
    string respuestaCotidiana3 = "No, me siento perfectamente.";

    string respuestaContactoDirecto1 = "Sí, uno de los tubos reventó y me salpicó un poco, pero fue mínimo.";
    string respuestaContactoDirecto2 = "No estoy seguro… Había vapor, golpes, gente gritando.";
    string respuestaContactoDirecto3 = "No, solo me acerqué unos segundos a revisar una alarma.";

    string respuestaConfusionNeurologica1 = "Sí… siento como… nublado. Es difícil explicarlo.";
    string respuestaConfusionNeurologica2 = "Solo dolor de cabeza. Debe ser estrés.";
    string respuestaConfusionNeurologica3 = "No, estoy bien… creo… solo necesito un momento.";

    //PREGUNTAS SEGUN RIESGO
    string preguntaRiesgoNegado = "Desde la fuga… ¿has sentido alguna molestia o cambio, aunque sea algo pequeño?";
    string preguntaRiesgoMedio = "¿Hubo algún tipo de exposición a sangre, fluidos o a la zona dañada del contenedor?";
    string preguntaRiesgoAlto = "¿Te has sentido raro desde el incidente? Mareos, temblores o problemas para concentrarte.";

    //RESPUESTAS SEGUN PREGUNTA POR RIESGO
    string respuestaRiesgoNegado_SospechaBAJA = "Sí, un poco de irritación en la piel por los nervios, supongo.";
    string respuestaRiesgoNegado_SospechaMEDIA = "He tenido tensión muscular, pero llevo horas en esta silla.";
    string respuestaRiesgoNegado_SospechaALTA = "No, me siento perfectamente.";

    string respuestaRiesgoMedio_SospechaBAJA = "Sí, uno de los tubos reventó y me salpicó un poco, pero fue mínimo.";
    string respuestaRiesgoMedio_SospechaMEDIA = "No estoy seguro… Había vapor, golpes, gente gritando.";
    string respuestaRiesgoMedio_SospechaALTA = "No, solo me acerqué unos segundos a revisar una alarma.";

    string respuestaRiesgoAlto_SospechaBAJA = "Sí… siento como… nublado. Es difícil explicarlo.";
    string respuestaRiesgoAlto_SospechaMEDIA = "Solo dolor de cabeza. Debe ser estrés.";
    string respuestaRiesgoAlto_SospechaALTA = "No, estoy bien… creo… solo necesito un momento.";

    private void Start()
    {
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
        if (infectado == false) //Si no está infectado
        {
            int numRndm = Random.Range(1, 3);
            Debug.Log(numRndm);

            if (numRndm % 2 == 0) //Si es par, sosprecha baja
            {
                respuesta.text = respuestaConfusionNeurologica1;
            }
            else //Si es impar, respuesta sospecha media
            {
                respuesta.text = respuestaConfusionNeurologica2;
            }
        }
        else //SI ESTA INFECTADO
        {
            int numRndm = Random.Range(1, 3);
            Debug.Log(numRndm);

            if (numRndm % 2 == 0) //Si es par, respuesta sospecha media
            {
                respuesta.text = respuestaConfusionNeurologica2;
            }
            else //Si es impar, respuesta sospecha muy alta
            {
                respuesta.text = respuestaConfusionNeurologica3;
            }
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

        }
        else if (riesgoMedio == true)
        {

        }
        else if (riesgoAlto == true)
        {

        }
    }

    public void RespuestaRiesgoNEGADO()
    {
        if (infectado == false) //Si no está infectado
        {
            int numRndm = Random.Range(1, 3);
            Debug.Log(numRndm);

            if (numRndm % 2 == 0) //Si es par, sosprecha baja
            {
                respuesta.text = respuestaRiesgoNegado_SospechaBAJA;
            }
            else //Si es impar, respuesta sospecha media
            {
                respuesta.text = respuestaRiesgoNegado_SospechaMEDIA;
            }
        }
        else //SI ESTA INFECTADO
        {
            int numRndm = Random.Range(1, 3);
            Debug.Log(numRndm);

            if (numRndm % 2 == 0) //Si es par, respuesta sospecha media
            {
                respuesta.text = respuestaRiesgoNegado_SospechaMEDIA;
            }
            else //Si es impar, respuesta sospecha muy alta
            {
                respuesta.text = respuestaRiesgoNegado_SospechaALTA;
            }
        }
    }

    public void RespuestaRiesgoMEDIO()
    {
        if (infectado == false) //Si no está infectado
        {
            int numRndm = Random.Range(1, 3);
            Debug.Log(numRndm);

            if (numRndm % 2 == 0) //Si es par, sosprecha baja
            {
                respuesta.text = respuestaRiesgoMedio_SospechaBAJA;
            }
            else //Si es impar, respuesta sospecha media
            {
                respuesta.text = respuestaRiesgoMedio_SospechaMEDIA;
            }
        }
        else //SI ESTA INFECTADO
        {
            int numRndm = Random.Range(1, 3);
            Debug.Log(numRndm);

            if (numRndm % 2 == 0) //Si es par, respuesta sospecha media
            {
                respuesta.text = respuestaRiesgoMedio_SospechaMEDIA;
            }
            else //Si es impar, respuesta sospecha muy alta
            {
                respuesta.text = respuestaRiesgoMedio_SospechaALTA;
            }
        }
    }

    public void RespuestaRiesgoALTO()
    {
        if (infectado == false) //Si no está infectado
        {
            int numRndm = Random.Range(1, 3);
            Debug.Log(numRndm);

            if (numRndm % 2 == 0) //Si es par, sosprecha baja
            {
                respuesta.text = respuestaRiesgoAlto_SospechaBAJA;
            }
            else //Si es impar, respuesta sospecha media
            {
                respuesta.text = respuestaRiesgoAlto_SospechaMEDIA;
            }
        }
        else //SI ESTA INFECTADO
        {
            int numRndm = Random.Range(1, 3);
            Debug.Log(numRndm);

            if (numRndm % 2 == 0) //Si es par, respuesta sospecha media
            {
                respuesta.text = respuestaRiesgoAlto_SospechaMEDIA;
            }
            else //Si es impar, respuesta sospecha muy alta
            {
                respuesta.text = respuestaRiesgoAlto_SospechaALTA;
            }
        }
    }
}
