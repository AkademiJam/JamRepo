using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charactercontroller : MonoBehaviour
{
    public float speed;
    public float verticalinput;
    public float horizontalinput;
    public float rotateSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalinput = Input.GetAxis("Horizontal");
        verticalinput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.right*speed*horizontalinput*Time.deltaTime);
        transform.Translate(Vector3.forward*speed*verticalinput*Time.deltaTime);

        Vector3 rotation = new Vector3(horizontalinput, 0.0f, verticalinput);
        if (rotation != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(rotation);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotateSpeed * Time.deltaTime);
        }
            
        

    }
}
