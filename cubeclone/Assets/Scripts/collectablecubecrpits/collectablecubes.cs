using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collectablecubes : MonoBehaviour
{
    GameObject cube;
    public GameObject cubepref;
    public static float brickspeed;
    public float accelarity = 1f;
    public GameObject topcollectable;
    public int i = 1;
    int j = 0;
    float addhigh = 5f;
    bool restrictive = true;
    GameObject player;
    private void Start()
    {
        player = GameObject.FindWithTag("Player");
    }
    void Update()
    {
        if (transform.GetChild(0).GetComponent<collectabletopcontrrol>().ust != null && restrictive == true)
        {
            topcollectable = transform.GetChild(0).GetComponent<collectabletopcontrrol>().ust;
            i += 1;
            restrictive = false;
        }
        if (topcollectable != null)
        {
            while (topcollectable.GetComponent<othercollectabletop>().topcollectable != null)
            {
                topcollectable = topcollectable.GetComponent<othercollectabletop>().topcollectable;                        
                i += 1;
            }
        }
        
        brick_move();
    }
    void brick_move()
    {
        
        transform.Translate(-brickspeed * Time.deltaTime, 0, 0);
    }

    private void OnCollisionEnter(Collision other)
    {
        if (!player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("win") && !player.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("dead"))
        {
            player.GetComponent<Animator>().SetTrigger("jump");
        }
            
        if (other.gameObject.GetComponent<CubeController>() != null && other.gameObject.GetComponent<CubeController>().ust != null)
        {
            cube = other.gameObject.GetComponent<CubeController>().ust;
            while (cube.GetComponent<CubeController>().ust != null)
            {
                cube = cube.GetComponent<CubeController>().ust;
            }
        }
        else if(other.gameObject.GetComponent<CubeController>() != null)
        {
            cube = other.gameObject;
        }
        if (cube != null)
        {
            for (j = 0; j < i; j++)
            {
                player.transform.position += new Vector3(0, 5f, 0);
                GameObject newcube = Instantiate(cubepref, cube.transform.position + new Vector3(0, addhigh, 0), Quaternion.identity);
                newcube.gameObject.transform.SetParent(cube.transform.parent);
                addhigh += 5;
            }
            if (gameObject.transform.parent != null)
            {
                Destroy(gameObject.transform.parent.gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
    }
}

