using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BtnPressedInteraction : MonoBehaviour
{
    public int btnID;
    public float intensidadLuz;
    public Light Luz;
    public bool desactivando;
    public bool desactivado;
    public AudioClip sonido;
    //public ControladorJuego controlador;

    //Color baseColor;
    //Renderer renderer_;
    //Material mat;
    //float emission;

    void Start()
    {
        intensidadLuz = Luz.intensity; 
    }

    public void Activar(){
        desactivado = false;
        desactivando = false;
        Luz.intensity = intensidadLuz;
        Luz.gameObject.SetActive(true);

        // controlador. 
        AudioSource.PlayClipAtPoint(sonido, Vector3.zero, 1.0f);

        Invoke("Desactivar", 0.1f);
    }

    public void Desactivar(){
        desactivando = true;
    }

    void Update()
    {
        if(desactivando && !desactivado){
            Luz.intensity = Mathf.Lerp(Luz.intensity, 0, 0.065f);
        }

        if(Luz.intensity <= 0.02)
        {
            Luz.intensity = 0;
            desactivado = true;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        Activar();

    }
}
