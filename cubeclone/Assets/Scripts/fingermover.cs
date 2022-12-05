using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fingermover : MonoBehaviour
{
    private void FixedUpdate()
    {
        transform.position = Vector3.Lerp(new Vector3(-104.5f,transform.position.y,-32), new Vector3(-102f, transform.position.y, -35.8f), Mathf.PingPong(Time.time,1));
    }
}
