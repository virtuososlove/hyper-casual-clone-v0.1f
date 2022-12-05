using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class uimanager : MonoBehaviour
{
    public static uimanager instance;
    public Text cointext;
    public Text wincointext;
    public Animator layoutanimator;
    public GameObject startbutton;
    public GameObject finger;
    int controller = 0;
    public GameObject cizgi;
    const string sd = "soundc";
    const string vd = "vibrationc";
    public GameObject vibrationcizgi;

    void Start()
    {
        instance = this;
        cointext.text = PlayerPrefs.GetInt("coin").ToString();
  
        if (PlayerPrefs.GetInt("soundc") == 0)
        {
            cizgi.SetActive(false);
            AudioListener.volume = 1;
        }
        else
        {
            cizgi.SetActive(true);
            AudioListener.volume = 0;
        }

        if (PlayerPrefs.GetInt("vibrationc") == 0)
        {
            vibrationcizgi.SetActive(false);
        }
        else
        {
            vibrationcizgi.SetActive(true);
        }
    }

    public void updatecointext(int value)
    {
        cointext.text = value.ToString();
    }

    public void updatewinpanelcoin(int value)
    {
        wincointext.text = value.ToString();
    }

    public void settingsanims()
    {
        if(controller == 0)
        {
            layoutanimator.SetTrigger("open");
            controller = 1;

        }
        else
        {
            layoutanimator.SetTrigger("close");
            controller = 0;
        }
    }

    public void startthegame()
    {
        if (transform.GetChild(2).transform.GetChild(0).gameObject.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("open")){
            transform.GetChild(2).transform.GetChild(0).gameObject.GetComponent<Animator>().SetTrigger("close");
        }
        finger.SetActive(false);
        startbutton.SetActive(false);
        collectablecubes.brickspeed = 25;
        charcontroller.brickspeed = 20;
        enemybrickcontroller.brickspeed = 25f;
        othercollectabletop.brickspeed = 25f;
        coin.coinspeed = 25f;
        finishtrigger.brickspeed = 25f;
        CubeController.brickspeed = 25f;
    }

    public void endthegame()
    {
        collectablecubes.brickspeed = 0;
        charcontroller.brickspeed = 0;
        enemybrickcontroller.brickspeed = 0f;
        othercollectabletop.brickspeed = 0f;
        coin.coinspeed = 0f;
        finishtrigger.brickspeed = 0f;
    }

    public void restartgamee()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void soundcontrol()
    {
        if(PlayerPrefs.GetInt("soundc") == 0)
        {
            PlayerPrefs.SetInt("soundc", 1);
            cizgi.SetActive(true);
            AudioListener.volume = 0;
        }
        else
        {
            PlayerPrefs.SetInt("soundc", 0);
            cizgi.SetActive(false);
            AudioListener.volume = 1;
        }
    }

    public void vibrationcontrol()
    {
        if (PlayerPrefs.GetInt("vibrationc") == 0)
        {
            PlayerPrefs.SetInt("vibrationc", 1);
            vibrationcizgi.SetActive(true);
        }
        else
        {
            PlayerPrefs.SetInt("vibrationc", 0);
            vibrationcizgi.SetActive(false);
        }
    }
}
