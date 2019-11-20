using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VerificadorPalabras : MonoBehaviour
{

    private List<GameObject> bloques;
    public GameObject gOPrefab;
    public float xI;
    public float yI;
    public float zI;
    public float espacio = 0.3f;

    public int completada = 0;
    private string palabra;
    public int palabraActual = 0;
    public GeneradorPalabras generadorPalabras;

    void Start()
    {
        empezarJuego();
    }

    void Update()
    {
        print(completada+" = "+palabra.Length);
        if(completada == palabra.Length)
        {
            palabraActual++;
            destruirBloquesPalAnterior();
            empezarJuego();
            Invoke("Jugar", 2.0f);
        }
    }

    public void empezarJuego()
    {
        completada = 0;
        palabra = generadorPalabras.CambiarPalabra(palabraActual);
        bloques = new List<GameObject>();
        LlenarGameObjectsVacios();
    }


    public void Jugar()
    {
        char[] arr = palabra.ToCharArray(0, palabra.Length);
        for (int i = 0; i < arr.Length; i++)
        {
            bloques[i] = Instantiate(gOPrefab, new Vector3((xI += espacio), yI, zI), Quaternion.Euler(new Vector3(0, 0, 0))) as GameObject;
            //gOModelo.transform.localScale += new Vector3(3f, 3f, 3f);
            bloques[i].name = "" + arr[i];
            bloques[i].AddComponent<VerificarCaracter>();
        }
    }


    public void LlenarGameObjectsVacios()
    {
        for (int i = 0; i < palabra.Length; i++)
        {
            bloques.Add(gOPrefab);
        }
    }

    public void destruirBloquesPalAnterior()
    {
        for (int i = 0; i < palabra.Length; i++)
        {
            Destroy(bloques[i]);
        }
    }



    public void verificarPalabraCompletada()
    {       
            for (int i = 0; i < palabra.Length; i++)
            {
                if(bloques[i].gameObject.GetComponent<VerificarCaracter>()!=null)
                {
                    if(bloques[i].gameObject.GetComponent<VerificarCaracter>().completada)
                    {
                        completada++;
                    }
                }
            }       
    }
}