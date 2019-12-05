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
    public GameObject level1;
    public GameObject level2;

    private void Start()
    {
        pTouched = false;
        anim.enabled = true;
        anim.SetBool("abrir", false);
        anim.SetBool("cerrar", false);
        level2.SetActive(false);
    }

    IEnumerator OnTriggerEnter(Collider col)
    {
        if (!pTouched)
        {
            pTouched = true;
            AudioClip sonido = Resources.Load<AudioClip>("Sonidos/elevator_movingup");
            MusicSource.PlayOneShot(sonido);
            anim.SetBool("cerrar", true);
            yield return new WaitForSeconds(8);
            MusicSource.Stop();
            MusicSource.PlayOneShot(sonidoPing);
            level1.SetActive(false);
            level2.SetActive(true);
            anim.SetBool("abrir", true);
            yield return new WaitForSeconds(2.1f);
            puertaElevador.SetActive(false);
        }
    }


    void OnTriggerExit(Collider col)
    {
        MusicSource.Stop();
    }


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
