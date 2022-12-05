using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coin : MonoBehaviour
{
    const string coinnn = "coin";
    public static float coinspeed = 0;

    void Update()
    {
        transform.Translate(-coinspeed * Time.deltaTime, 0, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<CubeController>() != null)
        {
            int oldvalue = PlayerPrefs.GetInt("coin");
            PlayerPrefs.SetInt("coin", oldvalue + 5);
            uimanager.instance.updatecointext(PlayerPrefs.GetInt("coin"));

            Destroy(this.gameObject);
            
        }
    }
}
