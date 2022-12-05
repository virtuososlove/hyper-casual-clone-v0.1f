using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class othercollectabletop : MonoBehaviour
{
    public GameObject topcollectable = null;
    public static float brickspeed;

    void Update()
    {
        if (transform.GetChild(0).GetComponent<collectabletopcontrrol>().ust != null)
        {
            topcollectable = transform.GetChild(0).GetComponent<collectabletopcontrrol>().ust;
        }
        brick_move();
    }
   
void brick_move()
{

    transform.Translate(-brickspeed * Time.deltaTime, 0, 0);
}
}
