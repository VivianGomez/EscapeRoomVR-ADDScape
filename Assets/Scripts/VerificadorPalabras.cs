using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class VerificadorPalabras : MonoBehaviour
{

    private List<GameObject> bloques;
    public GameObject gOPrefab;
    public string palabra;
    public float xI;
    public float yI;
    public float zI;
    public float espacio = 0.3f;


    void Start()
    {
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
        }
    }


    public void LlenarGameObjectsVacios()
    {
        for (int i = 0; i < palabra.Length; i++)
        {
            bloques.Add(gOPrefab);
        }
    }
}