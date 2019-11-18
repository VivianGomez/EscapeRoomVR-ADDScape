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
    public ControladorJuego controlador;
    public Animator anim;

    private bool pTouched = false;



    void Start()
    {
        intensidadLuz = Luz.intensity;
        pTouched = false;
    }

    IEnumerator AnimPlay()
    {
        anim.SetBool("press", true);
        yield return new WaitForSeconds(1);
        anim.SetBool("press", false);
    }

    public void Activar() {
        
        if(controlador.jugable)
        {
            //print("btnID "+btnID);
            desactivado = false;
            desactivando = false;
            Luz.intensity = intensidadLuz;
            Luz.gameObject.SetActive(true);
            StartCoroutine(AnimPlay());

            if (controlador.turnoUsuario)
            {
                print("mi turno ");
                controlador.JuegaUsuario(btnID);
            }

            AudioSource.PlayClipAtPoint(sonido, Vector3.zero, 1.0f);
            Invoke("Desactivar", 0.1f);
        }

    }

    public void Desactivar() {
        desactivando = true;
    }

    void Update()
    {
        if (desactivando && !desactivado) {
            Luz.intensity = Mathf.Lerp(Luz.intensity, 0, 0.065f);
        }

        if (Luz.intensity <= 0.02)
        {
            Luz.intensity = 0;
            desactivado = true;
        }
    }

    IEnumerator OnTriggerEnter()
    {
        if (!pTouched && (controlador.turnoUsuario))
        {
            pTouched = true;
            Activar();
            yield return new WaitForSeconds(2);    
            pTouched = false;    
            print("Off "+ pTouched);
        }
    }

    /**
    void OnMouseDown()
    {
        Activar();
    }*/

 
    

}
