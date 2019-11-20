using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorPalabras : MonoBehaviour
{
    public List<string> palabras;

    public string CambiarPalabra(int siguente)
    {
        return palabras[siguente];
    }
}
