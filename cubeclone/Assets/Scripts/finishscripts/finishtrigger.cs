using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finishtrigger : MonoBehaviour
{
    public static float brickspeed;
    public float accelarity = 1f;
    public GameObject player;
    public GameObject character;
    int prevcoin;
    public GameObject winpanel;
    public GameObject uicanvas;
    private void Start()
    {
        Time.timeScale = 1.5f;
        prevcoin = PlayerPrefs.GetInt("coin");
    }
    void Update()
    {
        brick_move();
    }
    void brick_move()
    {
        transform.Translate(-brickspeed * Time.deltaTime, 0, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.GetComponent<CubeController>() != null)
        {
            player.GetComponent<Animator>().SetTrigger("win");

            uicanvas.SetActive(false);
            winpanel.SetActive(true);
            uimanager.instance.updatewinpanelcoin(PlayerPrefs.GetInt("coin") - prevcoin);
            charcontroller.brickspeed = 0;
            brickspeed = 0;
            Time.timeScale = 0.5f;
        }
    }

}
