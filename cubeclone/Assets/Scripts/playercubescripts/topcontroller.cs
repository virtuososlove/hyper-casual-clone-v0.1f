using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class topcontroller : MonoBehaviour
{
    public GameObject ust;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject != transform.parent.gameObject && other.gameObject.GetComponent<CubeController>() != null)
        {
            ust = other.gameObject;
        }
      
    }
}
