using System.Collections;
using UnityEngine;

public class TransportadorNivel : MonoBehaviour
{
    //public string levelToLoad;
    public Animator anim;

    public IEnumerator AnimPlay()
    {
        anim.SetBool("cerrar", true);
        yield return new WaitForSeconds(1);
        //anim.SetBool("abrir", false);
    }

    void OnTriggerEnter(Collider col)
    {
        print(col.name);
        StartCoroutine(AnimPlay());
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
