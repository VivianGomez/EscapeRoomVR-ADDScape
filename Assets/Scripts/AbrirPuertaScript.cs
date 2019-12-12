using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbrirPuertaScript : MonoBehaviour
{
    public bool completada = false;
    public AudioClip push;
    public AudioClip incorrecto;

    public PlayAnimationAbrirPuerta playAnimationAbrirPuerta;

    void OnTriggerEnter(Collider col)
    {
        if(col.name == this.name)
        {
            AudioSource.PlayClipAtPoint(push, Vector3.zero, 1.0f);
            completada = true;
            StartCoroutine(playAnimationAbrirPuerta.AnimPlay());
            Destroy(col.gameObject);
        }
        else{
            if (!(col.name == "CustomHandRight") || !(col.name == "CustomHandLeft") || !(col.name == "AvatarGrabberLeft") || !(col.name == "AvatarGrabberRight") || !(col.name == "LeftHandAnchor") || !(col.name == "RightHandAnchor") || !(col.name == "LeftControllerAnchor") || !(col.name == "RightControllerAnchor"))
            {
                AudioSource.PlayClipAtPoint(incorrecto, Vector3.zero, 1.0f);
            }
        }
    }

}
