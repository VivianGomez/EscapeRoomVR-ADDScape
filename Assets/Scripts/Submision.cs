using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Submision : MonoBehaviour
{
    public bool completada = false;
    public AudioClip push;
    public AudioClip incorrecto;

    public Submision otro1;
    public Submision otro2;

    private SoundManager soundManager;

    public  bool inst4 = false;


    void Awake()
    {
        soundManager = GameObject.FindObjectOfType<SoundManager>();
    }   

    void OnTriggerEnter(Collider col)
    {
        if(col.name == this.name)
        {
            AudioSource.PlayClipAtPoint(push, Vector3.zero, 1.0f);
            completada = true;
            if((!inst4)  && (!otro1.inst4) && (!otro2.inst4))
            {
                soundManager.PlaySound("Ins4L1");
                StartCoroutine(soundManager.CambiarInstruccionPantalla("", "4Ins", "", 0, 2, 0));
                inst4 = true;
            }
        }
        else{
            AudioSource.PlayClipAtPoint(incorrecto, Vector3.zero, 1.0f);
        }
    }
}
