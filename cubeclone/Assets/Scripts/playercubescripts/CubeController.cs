using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public float accelarity = 1f;
    public Transform yerkontrol;
    public LayerMask ground;
    public bool touched;
    public GameObject ust;
    GameObject alt;
    Collider[] colliders;
    public bool canfall;
    bool fallable = false;
    float firstspawndelay = 0.1f;
    float first_y;
    public static float brickspeed = 25f;

    private void Start()
    {
        first_y = transform.position.y;
    }
    void Update()
    {
        firstspawndelay -= Time.deltaTime;
        if(firstspawndelay <= 0)
        {
            fallable = true;
        }
        if(fallable == true)
        {
            cubefallmech();
        }
    }
    void cubefallmech()
    {
        ust = transform.GetChild(2).GetComponent<topcontroller>().ust;  
        alt = transform.GetChild(3).GetComponent<botcontrroller>().alt;
        colliders = Physics.OverlapBox(transform.position - new Vector3(0, 2.5f, 0), new Vector3(5.0f, 0.07f, 5.0f));
        canfall = true;
        foreach (Collider col in colliders)
        {
            if (alt != null && alt.GetComponent<Collider>() == col)
            {
                canfall = false;
            }
        }
        if (!Physics.CheckSphere(yerkontrol.position, 0.4f, ground) && canfall == true)
        {
            float speed = -40f * Time.deltaTime;
            transform.Translate(0, speed, 0);
        }
        if (alt != null)
        {
            if (alt.transform.GetChild(0).gameObject.activeInHierarchy == true)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
        }
        if (touched == true)
        {
            transform.Translate(-brickspeed * Time.deltaTime, 0, 0);
            transform.SetParent(null);
            if (ust != null && ust.GetComponent<CubeController>().touched != true)
            {
                ust.transform.GetChild(0).gameObject.SetActive(true);
            }
            ust = null;
        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position - new Vector3(0, 2.5f, 0), new Vector3(5.0f, 0.05f, 5.0f));
    }
}
