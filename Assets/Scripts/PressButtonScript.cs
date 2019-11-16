using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressButtonScript : MonoBehaviour
{
    public Animator anim;

    IEnumerator OnTriggerEnter()
    {
        anim.SetBool("press", true);
        yield return new WaitForSeconds(2);
        anim.SetBool("press", false);
    }
}
