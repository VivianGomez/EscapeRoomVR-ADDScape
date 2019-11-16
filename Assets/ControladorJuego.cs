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

    void Start()
    {
        LlenarListaAleatoria();
        turnoPC = true;
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
                cambiarTurno();
            }
            else
            {
                contador++;
            }
        }

        Invoke("Velocidad", Velocidad);
        
    }

    public void cambiarTurno()
    {
        if(turnoPC)
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
        }
    } 
}
