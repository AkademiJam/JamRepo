using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_script : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float speed = 15f;
    public int enemy_hp = 30;

    [SerializeField] private Enemy_data enemy;
    private GameObject player;
    private Animator animator;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (animator.GetBool("isFollowing")) 
        {
            Follow();
        };

        // player scripti icine
        // player atak animasyonundan sonra
        // enemy icin --> animator.SetBool("isHit"); ama animatorina nasil ulasiriz??

        //private Enemy_script enemy_scriptInstance;

        //private void Awake()
        //{
        //    enemy_scriptInstance = FindObjectOfType<Enemy_script>();
        //}

        if (animator.GetBool("isHit"))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).normalizedTime > 1f)
            {
                //Debug.Log("enemy took damage");
                TakeDamage(10);
            }
        }
        
    }

    private void Follow()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void TakeDamage(int damage_amount)
    {
        enemy_hp -= damage_amount;
        if (enemy_hp <= 0 )
        {
            Die();
        }
    }

    void Die()
    {
        animator.SetBool("isDead", true);
        wait_();
        Destroy(gameObject);
    }
    static IEnumerator wait_()
    {
        Debug.Log("waiting");
        yield return new WaitForSeconds(2f);
    }
}
