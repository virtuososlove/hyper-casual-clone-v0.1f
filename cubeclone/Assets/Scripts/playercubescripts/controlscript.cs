using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlscript : MonoBehaviour
{
    public bool touched;
    private void Update()
    {
        if (touched == true)
        {
            transform.parent.gameObject.GetComponent<CubeController>().touched = true;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Respawn")
        {
            touched = true;
        }
    }
}
