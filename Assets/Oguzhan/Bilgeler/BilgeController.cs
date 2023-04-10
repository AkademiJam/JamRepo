using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BilgeController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public string[] At�lMetins;
    public string[] BOYMetins;
    public string[] GunseliMetins;
    public string[] TolgayMetins; 
    public static int siraValue;
    public GameObject canvasMetin;
    public TextMeshProUGUI metinText;


    // Start is called before the first frame update
    void Start()
    {
        siraValue = 8;
        InvokeRepeating("Speak", 10, 15);
    }

    // Update is called once per frame
    void Update()
    {

    }
    //Karaktere yakla�t���nda siravalue de�eri g�ncelleniyor
    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {

            if (other.gameObject.tag == "At�l")
            {
                canvasMetin.SetActive(true);
                metinText.text = "Merhaba ben At�l sana bu yolda �ok �ey ��retece�im";
                audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
                Invoke("offCanvasMetin", 4);
                siraValue = 0;
            }
            else if (other.gameObject.tag == "BOY")
            {
                canvasMetin.SetActive(true);
                metinText.text = "Merhaba ben Sonat sana bu yolda �ok �ey ��retece�im";
                audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
                Invoke("offCanvasMetin", 4);
                siraValue = 1;
            }
            else if (other.gameObject.tag == "G�nseli")
            {
                canvasMetin.SetActive(true);
                metinText.text = "Merhaba ben Melike sana bu yolda her konuda yard�m edece�im";
                audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
                Invoke("offCanvasMetin", 4);
                siraValue = 2;
            }
            else if (other.gameObject.tag == "Tolgay")
            {
                canvasMetin.SetActive(true);
                metinText.text = "Merhaba ben Tolgay sana bu yolda �ok �ey ��retece�im";
                audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
                Invoke("offCanvasMetin", 4);
                siraValue = 3;
            }
        }

    }




    void Speak()
    {
        switch (siraValue)
        {
            case 0:
                {
                    canvasMetin.SetActive(true);
                    int index = Random.Range(0, At�lMetins.Length);
                    metinText.text = At�lMetins[index];
                    audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
                    Invoke("offCanvasMetin", 5);
                    break;
                }
            case 1:
                {
                    canvasMetin.SetActive(true);
                    int index = Random.Range(0, BOYMetins.Length);
                    metinText.text = BOYMetins[index];
                    audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
                    Invoke("offCanvasMetin", 5);
                    break;
                }
            case 2:
                {
                    canvasMetin.SetActive(true);
                    int index = Random.Range(0, GunseliMetins.Length);
                    metinText.text = GunseliMetins[index];
                    audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
                    Invoke("offCanvasMetin", 5);
                    break;
                }
            case 3:
                {
                    canvasMetin.SetActive(true);
                    int index = Random.Range(0, TolgayMetins.Length);
                    metinText.text = TolgayMetins[index];
                    audioSource.PlayOneShot(audioClips[Random.Range(0, audioClips.Length)]);
                    Invoke("offCanvasMetin", 5);

                    break;
                }
            default:
                {
                    break;
                }
        }

    }



    void offCanvasMetin()
    {
        canvasMetin.SetActive(false);

    }

}




