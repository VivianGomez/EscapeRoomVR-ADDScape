using System.Collections;
using UnityEngine;

public class TransportadorNivel : MonoBehaviour
{
    //public string levelToLoad;
    public Animator anim;
    public AudioSource MusicSource;
    public GameObject puertaElevador;
    private bool pTouched = false;
    public AudioClip sonidoPing;
    public GameObject Btnlevel1;
    public GameObject Btnlevel2;
    public GameObject level1;
    public GameObject level2;
    public Animator animPuertaCuarto;

    private SoundManager soundManager;

    void Awake()
    {
        soundManager = GameObject.FindObjectOfType<SoundManager>();
    }  

    private void Start()
    {
        pTouched = false;
        anim.enabled = true;
        anim.SetBool("abrir", false);
        anim.SetBool("cerrar", false);
        Btnlevel2.SetActive(false);
    }

    IEnumerator OnTriggerEnter(Collider col)
    {
        if (!pTouched)
        {
            pTouched = true;
            AudioClip sonido = Resources.Load<AudioClip>("Sonidos/elevator_movingup");
            MusicSource.PlayOneShot(sonido);
            anim.SetBool("cerrar", true);
            yield return new WaitForSeconds(2);
            level1.SetActive(false);
            level2.SetActive(true);
            yield return new WaitForSeconds(6);
            MusicSource.Stop();
            MusicSource.PlayOneShot(sonidoPing);
            Btnlevel1.SetActive(false);
            Btnlevel2.SetActive(true);
            anim.SetBool("abrir", true);
            yield return new WaitForSeconds(2.1f);
            puertaElevador.SetActive(false);
            animPuertaCuarto.SetBool("abrir", true);
            soundManager.PlaySound("Ins1L2");
            StartCoroutine(soundManager.CambiarInstruccionPantalla("Ins1L2", "Ins1L2", "", 0, 0, 0));
            yield return new WaitForSeconds(13);
            soundManager.PlaySound("Ins2L2");
            StartCoroutine(soundManager.CambiarInstruccionPantalla2("Ins2L2", 0, "Ins2L2", 0));
            yield return new WaitForSeconds(13);
            soundManager.PlaySound("Ins3L2");
            StartCoroutine(soundManager.CambiarInstruccionPantalla2("Ins3L2", 0, "Ins2L2", 0));
            yield return new WaitForSeconds(13);
        }
    }

    /**
    void OnTriggerExit(Collider col)
    {
        MusicSource.Stop();
        animPuertaCuarto.SetBool("cerrar", true);
        animPuertaCuarto.SetBool("abrir", false);
    }
     */

    /**

    public void LoadScene(string sceneName)
    {
        StartCoroutine(ShowOverlayAndLoad(sceneName));
    }

    IEnumerator ShowOverlayAndLoad(string sceneName)

    {
        yield return new WaitForSeconds(1f);
        // Load Scene and wait til complete
        AsyncOperation asyncLoad = UnityEngine.SceneManagement.SceneManager.LoadSceneAsync(sceneName);
        while (!asyncLoad.isDone)
        {
            yield return null;
        }
        yield return null;
    }

    void OnTriggerEnter(Collider other)
    {
        LoadScene(levelToLoad);
    }

    */
}
