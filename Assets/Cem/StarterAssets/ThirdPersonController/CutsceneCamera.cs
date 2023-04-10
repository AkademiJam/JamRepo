using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutsceneCamera : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject cutsceneCam;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            cutsceneCam.SetActive(true);
            thePlayer.SetActive(false);
        }
        
    }
}
