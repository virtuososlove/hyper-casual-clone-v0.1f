using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    Collider[] colliders;
    bool canfall;
    public LayerMask ground;
    Animator playeranimator;
    void Start()
    {
        playeranimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.localPosition = new Vector3(0, transform.localPosition.y, 0);
        if (!Physics.CheckBox(transform.position, new Vector3(5.0f, 0.2f, 5.0f)))    
        {
            if (!playeranimator.GetAnimatorTransitionInfo(0).IsName("win") && !playeranimator.GetAnimatorTransitionInfo(0).IsName("dead"))
            {
                playeranimator.SetTrigger("fall");
            }
            float speed = -40f * Time.deltaTime;
            transform.Translate(0, speed, 0);
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position - new Vector3(0,0.05f,0) , new Vector3(5.0f, 0.2f, 5.0f));

    }

}
