using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submision : MonoBehaviour
{
    public bool completada = false;
    public AudioClip push;
    public AudioClip incorrecto;

    void OnTriggerEnter(Collider col)
    {
        if(col.name == this.name)
        {
            AudioSource.PlayClipAtPoint(push, Vector3.zero, 1.0f);
            completada = true;
        }
        else{
            AudioSource.PlayClipAtPoint(incorrecto, Vector3.zero, 1.0f);
        }
    }
}
