using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charcontroller : MonoBehaviour
{
    float x;
    public static float brickspeed = 0;
    public bool cantmove = false;
    Collider[] colliders;
    GameObject block;
    bool canlive = true;
    public GameObject endgame;

    void Update()
    {
        if(transform.childCount <= 1 && canlive == true)
        {
            endgame.SetActive(true);
            CubeController.brickspeed = 0f;
            uimanager.instance.endthegame();
            Time.timeScale = 1f;
            transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("dead");
            canlive = false;
        }
        colliders = Physics.OverlapBox(transform.position + new Vector3(0f, 2.5f, 0), new Vector3(3f, 1f, 2.575f));
        cantmove = false;
        foreach (Collider col in colliders)
        {
           if(col.gameObject.GetComponent<enemybrickcontroller>() != null)
            {
                block = col.gameObject;
                cantmove = true;
            }
        }
        if (Input.GetKeyDown(KeyCode.A) && cantmove == true && block.transform.position.z < transform.position.z)
        {
            transform.Translate(0, 0, 0.5f);    
        }
        if(Input.GetKeyDown(KeyCode.D) && cantmove == true && block.transform.position.z > transform.position.z)
        {
            transform.Translate(0, 0, -0.5f);
        }
        if (cantmove == false)
        {
            brick_move();
        }
    }
    void brick_move()
    {
        x = Input.GetAxis("Horizontal");
        float newz = transform.position.z - x * Time.deltaTime * brickspeed;
        newz = Mathf.Clamp(newz, -10, 10);
        transform.position = new Vector3(transform.position.x, transform.position.y, newz);
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(transform.position +new Vector3(0f,2.5f,0), new Vector3(3f, 1f, 5f));
    }
}
