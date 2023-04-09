using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackController : MonoBehaviour
{
    public Animator charAnim;
    private int temp;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerStay(Collider other)
    {
        Debug.Log("OnTrigerStayÇalýþtý");
        Debug.Log(other.gameObject.name);
        if (other.gameObject.tag == "Enemy")
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                Debug.Log("Hasar Verildi");
                other.GetComponent<Enemy_script>().TakeDamage(10, ref Enemy_script.isAlive);
            }

                
        }
    }
}
