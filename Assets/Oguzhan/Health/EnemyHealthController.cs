using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthController : MonoBehaviour
{
    public Animator enemyAnim;
    private int temp;
    // Start is called before the first frame update
    void Start()
    {
        enemyAnim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemyAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack01") && enemyAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            
            if (temp != Mathf.FloorToInt(enemyAnim.GetCurrentAnimatorStateInfo(0).normalizedTime))
            {
                HealthControllerChar.charHealth -= 10;
            }
            temp = Mathf.FloorToInt(enemyAnim.GetCurrentAnimatorStateInfo(0).normalizedTime);

        }
    }
}
