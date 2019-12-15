using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmpezarJuegoPalabras : MonoBehaviour
{

    public float intensidadLuz;
    public Light Luz;
    public AudioClip sonido;
    public VerificadorPalabras controlador;
    public Animator anim;
    public GameObject btnJugar;

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

    public void Activar()
    {
        Luz.intensity = intensidadLuz;
        Luz.gameObject.SetActive(true);
        StartCoroutine(AnimPlay());
        AudioSource.PlayClipAtPoint(sonido, Vector3.zero, 1.0f);
        btnJugar.SetActive(false);
        controlador.Jugar();
    }

    void OnTriggerEnter()
    {

        if (!pTouched)
        {
            pTouched = true;
            Activar();
            //yield return new WaitForSeconds(3);    
            pTouched = false;    
            //print("Off "+ pTouched);
        }
    }

}