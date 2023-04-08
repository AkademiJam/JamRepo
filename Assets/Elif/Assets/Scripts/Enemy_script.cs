using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_script : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float speed = 10f;
    public float enemy_hp = 30f;

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
                //Debug.Log("hp-10");
                enemy_hp = enemy_hp - 10f;
            }
        }
        
    }

    private void Follow()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

}
