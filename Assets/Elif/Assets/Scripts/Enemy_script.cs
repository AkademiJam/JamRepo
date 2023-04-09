using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_script : MonoBehaviour
{
    [SerializeField] private int damage = 5;
    [SerializeField] private float speed = 10f;
    public int enemy_hp = 30;
    public int current_enemy_hp;
    public HealthBar health_bar;

    [SerializeField] private Enemy_data enemy;
    private GameObject player;
    private Animator animator;
    private AudioSource _audio;
    public AudioClip walking_sound;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        animator = GetComponent<Animator>();
        current_enemy_hp = enemy.hp;
        health_bar.SetMaxHealth(enemy_hp);
        
        _audio = GetComponent<AudioSource>();
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
        if (animator.GetBool("isFollowing") && !_audio.isPlaying)
        {
            _audio.PlayOneShot(walking_sound);
        }
    }

    private void Follow()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void TakeDamage(int damage_amount)
    {
        enemy_hp -= damage_amount;
        health_bar.Set_health(current_enemy_hp);
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
