using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybrickcontroller : MonoBehaviour
{
    public static float brickspeed;
    public float accelarity = 1f;
    void Update()
    {
        brick_move();
    }
    void brick_move()
    {
        transform.Translate(-brickspeed * Time.deltaTime, 0, 0);
    }
}
