using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManagerScript : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        DebugUIBuilder.instance.Hide();
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
}
