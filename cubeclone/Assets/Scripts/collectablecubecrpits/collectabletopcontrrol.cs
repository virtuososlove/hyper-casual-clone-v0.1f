using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectabletopcontrrol : MonoBehaviour
{
    public GameObject ust;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject != transform.parent.gameObject && other.gameObject.tag == "collectablecubes")
        {
            ust = other.gameObject;
        }
    }
}
