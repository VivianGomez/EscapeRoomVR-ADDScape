using System.Collections;
using UnityEngine;

public class PlayAnimationAbrirPuerta : MonoBehaviour
{
    public Animator anim;

    public IEnumerator AnimPlay()
    {
        anim.SetBool("abrir", true);
        yield return new WaitForSeconds(1);
        //anim.SetBool("abrir", false);
    }
}
