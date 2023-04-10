using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CutsceneCamera : MonoBehaviour
{
    public GameObject thePlayer;
    public GameObject cutsceneCam;
    public Canvas finalCanva;
    public GameObject Bridges;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            canvaOn();
            Invoke("canvaOff", 5);
            Invoke("endGame", 7);
        }

    }


    void endGame()
    {
        Bridges.SetActive(false);
        cutsceneCam.SetActive(true);
        thePlayer.SetActive(false);
        BilgeController.siraValue = 5;
    }
    void canvaOn()
    {
        finalCanva.enabled = true;
    }
    void canvaOff()
    {
        finalCanva.enabled = false;
    }
}
