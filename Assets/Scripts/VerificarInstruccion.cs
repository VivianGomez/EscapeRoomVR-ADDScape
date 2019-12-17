using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerificarInstruccion : MonoBehaviour
{
    public bool ins3 = false;
    private SoundManager soundManager;

    public VerificarInstruccion submision1;
    public VerificarInstruccion submision2;

    void Awake()
    {
        soundManager = GameObject.FindObjectOfType<SoundManager>();
    }   

    void OnTriggerEnter(Collider col)
    {
        if ((col.tag.Equals("mano")) && !ins3 && ((!submision1.ins3) && (!submision2.ins3))) 
        {
            soundManager.PlaySound("Ins3L1");
            StartCoroutine(soundManager.CambiarInstruccionPantalla("Ins3L1", "3Ins", "", 0, 2, 0));
            ins3 = true;
        }
    }
}
