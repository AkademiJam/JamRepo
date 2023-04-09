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
    public AudioClip attack_audio;
    public AudioClip dying_sound;
    public static bool isAlive = true;

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
        if (animator.GetBool("isFollowing") && !animator.GetBool("isDead")) 
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

        if (animator.GetBool("isAttacking") && !_audio.isPlaying)
        {
            _audio.volume = 0.5f;
            _audio.PlayOneShot(attack_audio);
        }

        if (animator.GetBool("isFollowing") && !_audio.isPlaying && isAlive)
        {
            _audio.volume = 0.2f;
            _audio.PlayOneShot(walking_sound);
        }


    }

    private void Follow()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
    }

    public void TakeDamage(int damage_amount, ref bool isAlive)
    {
        animator.SetBool("isHit",true);
        enemy_hp -= damage_amount;
        health_bar.Set_health(enemy_hp);
        if (enemy_hp <= 0 && !animator.GetBool("isDead"))
        {
            animator.SetBool("isDead", true);
            animator.SetBool("isAttacking", false);
            isAlive = false;
            _audio.volume = 0.4f;
            _audio.PlayOneShot(dying_sound);
            Invoke("Die", 3);
        }
        
    }

    void Die()
    {
        gameObject.SetActive(false);
    }
}
