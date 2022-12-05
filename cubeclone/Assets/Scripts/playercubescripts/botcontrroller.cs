using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class botcontrroller : MonoBehaviour
{
    public GameObject alt;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject != transform.parent.gameObject && other.gameObject.GetComponent<CubeController>() != null)
        {
            alt = other.gameObject;
            
        }

    }
}
