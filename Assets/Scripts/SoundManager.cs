using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip Ins1L1, Ins2L1, Ins3L1, 
    Ins4L1, Ins5L1, Ins6L1, Ins7L1, Ins8L1, Ins9L1;
    static AudioSource audioSource; 
    public GameObject pantallaIns;
    public GameObject arrow;
    public Animator animArrow;

    void Start()
    {
        Ins1L1 = Resources.Load<AudioClip>("Sonidos/instrucciones/Ins1L1");
        Ins2L1 = Resources.Load<AudioClip>("Sonidos/instrucciones/Ins2L1");
        Ins3L1 = Resources.Load<AudioClip>("Sonidos/instrucciones/Ins3L1");
        Ins4L1 = Resources.Load<AudioClip>("Sonidos/instrucciones/Ins4L1");
        Ins5L1 = Resources.Load<AudioClip>("Sonidos/instrucciones/Ins5L1");
        Ins6L1 = Resources.Load<AudioClip>("Sonidos/instrucciones/Ins6L1");
        Ins7L1 = Resources.Load<AudioClip>("Sonidos/instrucciones/Ins7L1");
        Ins8L1 = Resources.Load<AudioClip>("Sonidos/instrucciones/Ins8L1");
        Ins9L1 = Resources.Load<AudioClip>("Sonidos/instrucciones/Ins9L1");

        arrow.SetActive(false);
        audioSource = GetComponent<AudioSource>();
        PlaySound("Ins1L1");
        StartCoroutine(CambiarInstruccionPantalla("Ins1L1", "1Ins", "2Ins", 4, 15, 3));
    }

    public IEnumerator CambiarInstruccionPantalla(string nombreAnim, string nombreInstruccion, string nombreInstruccion2, int secsImagen1, int secsAnim,int secsImagen2)
    {
        yield return new WaitForSeconds(secsAnim);
        arrow.SetActive(true);
        animArrow.Play(nombreAnim);
               
        yield return new WaitForSeconds(secsImagen1);
        pantallaIns.GetComponent<Renderer>().material.mainTexture = Resources.Load("RecursosTutoriales/"+ nombreInstruccion) as Texture;

        if(!(nombreInstruccion2.Equals("")))
        {
            yield return new WaitForSeconds(secsImagen2);
            pantallaIns.GetComponent<Renderer>().material.mainTexture = Resources.Load("RecursosTutoriales/"+ nombreInstruccion2) as Texture;
        }   
    }

    public void activarAnimacion(string nombreAnim)
    {
        animArrow.Play(nombreAnim);
    }

    public void PlaySound(string clip){
        switch(clip){
        case "Ins1L1":
            audioSource.PlayOneShot(Ins1L1);
            break;
        case "Ins2L1":
            audioSource.PlayOneShot(Ins2L1);
            break;   
        case "Ins3L1":
            audioSource.PlayOneShot(Ins3L1);
            break;
        case "Ins4L1":
            audioSource.PlayOneShot(Ins4L1);
            break;
        case "Ins5L1":
            audioSource.PlayOneShot(Ins5L1);
            break;
        case "Ins6L1":
            audioSource.PlayOneShot(Ins6L1);
            break;
        case "Ins7L1":
            audioSource.PlayOneShot(Ins7L1);
            break;
        case "Ins8L1":
            audioSource.PlayOneShot(Ins8L1);
            break; 
        case "Ins9L1":
            audioSource.PlayOneShot(Ins9L1);
            break; 
        }
    }
}
