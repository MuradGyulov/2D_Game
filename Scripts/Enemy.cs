using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public float Muving_Speed;
    public float Attack_Distance;
    public int Health;

    public float NextFire;
    public float FireRate;

    private Transform target;
    public GameObject Bullet;

    public GameObject MchineGunUP;
    public GameObject ShootGunUP;
    public GameObject SpeedPowerUP;

    private AudioSource AU;
    private SpriteRenderer SR;
    public AudioClip Shoot_Sound;

    private void Start()
    {
        Attack_Distance = Random.Range(1.0f, 6.0f);
        Muving_Speed = Random.Range(1.0f, 3.0f);
        FireRate = Random.Range(0.5f, 2.0f);

        SR = GetComponentInChildren<SpriteRenderer>();
        AU = GetComponent<AudioSource>();

        target = GameObject.FindGameObjectWithTag("Character").GetComponent<Transform>();

    }


    private void Update()
    {
        if (Vector2.Distance(transform.position, target.position) > Attack_Distance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, Muving_Speed * Time.deltaTime);   
        }

        if(Vector2.Distance(transform.position, target.position) < Attack_Distance)
        {
            if(Time.time > NextFire)
            {
                Shooting();
                NextFire = Time.time + FireRate;
            }
        }

        transform.right = target.position - transform.position;
    }



    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Bullet":
                SR.color = Color.white;
                Invoke("Collor_Change", 0.15f);
                Health -= 1;
                if (Health == 0) { Destroy_enemy(); }
                break;

            case "Character":
                SR.color = Color.white;
                Invoke("Collor_Change", 0.15f);
                Health -= 2;
                if(Health == 0) { Destroy_enemy(); }
                break;
        }
    }


    private void Shooting()
    {
        Instantiate(Bullet, transform.position + (transform.right * 0.35f), transform.rotation * Quaternion.Euler(0, 0, -90f));
        AU.PlayOneShot(Shoot_Sound);
    }



    private void Collor_Change()
    {
        SR.color = Color.red;
    }

    private void Destroy_enemy()
    {

        Destroy(gameObject);
    }
}
