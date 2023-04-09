using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BilgeController : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] audioClips;
    public string[] At�lMetins = {"Merhaba ben At�l","At�l Ben Merhaba","At�l Mesaj Balonu"};
    public string[] BOYMetins = { "Merhaba ben BOY", "BOY Ben Merhaba", "BOY Mesaj Balonu" };
    public string[] GunseliMetins = { "Merhaba ben G�nseli", "G�nseli Ben Merhaba", "G�nseli Mesaj Balonu" };
    public string[] TolgayMetins = { "Merhaba ben Tolgay", "Tolgay Ben Merhaba", "Tolgay Mesaj Balonu" };
    public int siraValue;
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
        if (Input.GetKeyDown(KeyCode.A))
        {
            siraValue = 0;
        }
        else if (Input.GetKeyDown(KeyCode.S))
        {
            siraValue = 1;
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            siraValue = 2;
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            siraValue = 3;
        }
    }
    //Karaktere yakla�t���nda siravalue de�eri g�ncelleniyor
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && gameObject.tag == "At�l")
        {
            siraValue = 0;
        }
        else if (other.gameObject.tag == "Player" && gameObject.tag == "BOY")
        {
            siraValue = 1;
        }
        else if (other.gameObject.tag == "Player" && gameObject.tag == "G�nseli")
        {
            siraValue = 2;
        }
        else if (other.gameObject.tag == "Player" && gameObject.tag == "Tolgay")
        {
            siraValue = 3;
        }
    }




    void Speak()
    {
        Debug.Log("Fonksiyona girildi");
        switch (siraValue)
        {
            case 0:
                {
                    canvasMetin.SetActive(true);
                    int index = Random.Range(0, At�lMetins.Length);
                    metinText.text = At�lMetins[index];
                    audioSource.PlayOneShot(audioClips[Random.Range(0,audioClips.Length)]);
                    Invoke("offCanvasMetin", 5);
                    break;
                }
            case 1:
                {
                    canvasMetin.SetActive(true);
                    int index = Random.Range(0,BOYMetins.Length);
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




