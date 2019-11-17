using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

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

    public GameObject botones;
    public GameObject btnJugar;

    public Submision submision0;
    public Submision submision1;
    public Submision submision2;

    public GameObject misionRequisitoJugar;

    public bool completadaSonido = false;


    public bool jugable = true;

    void Update()
    {
        StartCoroutine(verificarRequisitoJugar());
        verificarTurnoEsfera();
    }

    void verificarTurnoEsfera()
    {
        if (turnoUsuario)
        {
            tUsuario.SetActive(true);
            tPC.SetActive(false);
        }
        else if(turnoPC)
        {
            tPC.SetActive(true);
            tUsuario.SetActive(false);
        }
        else
        {
            tPC.SetActive(false);
            tUsuario.SetActive(false);
        }
    }

    IEnumerator verificarRequisitoJugar()
    {
        if((submision0.completada) && (submision1.completada) && (submision2.completada))
        {
            if (!completadaSonido)
            {
                completadaSonido = true;
                AudioSource.PlayClipAtPoint(correcto, Vector3.zero, 1.0f);
                yield return new WaitForSeconds(3);    
                completadaSonido = false;    
            }
            misionRequisitoJugar.SetActive(false);
            Invoke("BtnJugar", 2.0f);
        }
    }

    void BtnJugar()
    {
        botones.SetActive(false);
        btnJugar.SetActive(true);
        submision0.completada = false;
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
            print("NIVEL "+ nivel +" entra, i= "+ contador + " === BTN " +ListaAleatoria[contador]);

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
            Invoke("TurnoPC", Velocidad); //Velocidad
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
        print(" entra, j= "+ contadorUsusario + " === BTN " +ListaAleatoria[contador]);
        if (idBtn != ListaAleatoria[contadorUsusario])
        {
            print("GAME OVER");
            AudioSource.PlayClipAtPoint(incorrecto, Vector3.zero, 2.0f);
            turnoUsuario = false;
            turnoPC = false;
            jugable = false;
            Invoke("BtnJugar", 2.0f);
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

    public void Jugar()
    {
        jugable = true;
        contador = 0;
        contadorUsusario = 0;
        nivel = 0;
        ListaAleatoria.Clear();
        LlenarListaAleatoria();
        Invoke("MostrarElementosJugar", 2.0f);
        Invoke("TurnoPC", 4.0f);
    }

    void MostrarElementosJugar()
    {
        botones.SetActive(true);
        btnJugar.SetActive(false);
        turnoPC = true;
        turnoUsuario = false;
    }
}
