using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificarCaracter : MonoBehaviour
{
    public bool completada = false;
    public AudioClip correcto;
    public AudioClip incorrecto;

    private void Start()
    {
        correcto = Resources.Load<AudioClip>("Sonidos/positive-beeps");
        incorrecto = Resources.Load<AudioClip>("Sonidos/negative-beeps");
    }

    void OnTriggerEnter(Collider col)
    {
        print(col.name);

        if (((col.name.ToLower()) == this.name) || (col.name == ("block-"+this.name)))
        {
            AudioSource.PlayClipAtPoint(correcto, Vector3.zero, 1.0f);
            completada = true;
            this.gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
        else
        {
            AudioSource.PlayClipAtPoint(incorrecto, Vector3.zero, 1.0f);
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
        }
    }

}
