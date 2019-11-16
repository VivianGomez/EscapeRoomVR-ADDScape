using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ControladorJuego : MonoBehaviour
{
    public BtnPressedInteraction[] btns;
    public List<int> ListaAleatoria = new List<int>();

    public bool listaLlena;
    public bool turnoPC;
    public bool turnoUsuario;

    public int contador;
    public int contadorUsusario;
    public int nivel;

    [Range(0.1f, 2f)]
    public float Velocidad;

    public Text gameOver;

    public AudioClip incorrecto;
    public AudioClip correcto;
    public AudioClip nb;

    public GameObject tUsuario;
    public GameObject tPC;


    void Update()
    {
        if (turnoUsuario)
        {
            tUsuario.SetActive(true);
            tPC.SetActive(false);
        }
        else
        {
            tPC.SetActive(true);
            tUsuario.SetActive(false);
        }
    }

    void Start()
    {
        LlenarListaAleatoria();
        turnoPC = true;
        turnoUsuario = false;
        nivel = 0;
        Invoke("TurnoPC", 0.5f);
    }

    void LlenarListaAleatoria()
    {
        for(int i = 0; i <= 1000; i++)
        {
            ListaAleatoria.Add(Random.Range(0, 4));
        }
        listaLlena = true;
    }

    void TurnoPC()
    {
        if (listaLlena && turnoPC)
        {
            btns[ListaAleatoria[contador]].Activar();
            if (contador >= nivel)
            {
                nivel++;
                CambiarTurno();
            }
            else
            {
                contador++;
            }
            Invoke("TurnoPC", 3.0f); //Velocidad
        }
    }

    public void CambiarTurno()
    {
        AudioSource.PlayClipAtPoint(correcto, Vector3.zero, 1.0f);
        if (turnoPC)
        {
            turnoPC = false;
            turnoUsuario = true;
        }
        else
        {
            turnoPC = true;
            turnoUsuario = false;
            contador = 0;
            contadorUsusario = 0;
            Invoke("TurnoPC", 3.0f);
        }
    }

    public void JuegaUsuario(int idBtn)
    {
        if (idBtn != ListaAleatoria[contadorUsusario])
        {
            print("GAME OVER");
            AudioSource.PlayClipAtPoint(incorrecto, Vector3.zero, 1.0f);
            //turnoUsuario = false;
            //turnoPC = false;
            return;
        }
        if (contadorUsusario == contador)
        {
            print("Nivel actual" + nivel);
            CambiarTurno();
        }
        else
        {
            contadorUsusario++;
        }
    }
}
