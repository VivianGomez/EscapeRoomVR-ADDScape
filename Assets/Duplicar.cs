using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Duplicar : MonoBehaviour
{

    public void CrearDuplicado()
    {
        Instantiate(this.gameObject, transform);
    }
}
