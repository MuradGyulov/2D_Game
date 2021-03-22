using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Character_Controller : MonoBehaviour
{
    private enum Weapons { Gun, Mchine_Gunn, Shot_Gun};
    public enum State { Play, Pause, Dead };

    private Weapons weapon;
    public State state;

    public Menu_Manager MenManager;
    public Enemy_Spavner Spavner;

    public float nextFire;
    public float fireRate;

    public float Move_Speed;
    public float Max_HP;
    public float HP_Up;

    public float Collision_Damage;
    public float Bullet_Damage;

    public GameObject Bullet;
    public GameObject Buckshot;

    public AudioClip Gun;
    public AudioClip Mchine_Nun;
    public AudioClip Shot_gun;

    public Image HP_Bar;

    private  AudioSource AU;

    public void Change_Position()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    private void Start()
    {
        weapon = Weapons.Gun;

        AU = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (state == State.Play)
        {
            Vector3 targetDir = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            float angle = (Mathf.Atan2(targetDir.y, targetDir.x) * Mathf.Rad2Deg) - 90f;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

            transform.Translate(new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0) * Move_Speed * Time.deltaTime, Space.World);



            if (weapon == Weapons.Gun)
            {
                if (Input.GetButtonDown("Fire1"))
                {
                    AU.PlayOneShot(Gun);
                    Gun_Shooting();
                }
            }

            if (weapon == Weapons.Mchine_Gunn)
            {
                if (Input.GetButton("Fire1") && Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    AU.PlayOneShot(Mchine_Nun);
                    Mchinegun_Shooting();
                }
            }

            if (weapon == Weapons.Shot_Gun)
            {
                if (Input.GetButton("Fire1") && Time.time > nextFire)
                {
                    nextFire = Time.time + fireRate;
                    AU.PlayOneShot(Shot_gun);
                    Buckshot_Shooting();
                }
            }
        }

        if (Input.GetKey(KeyCode.Space)) { Time.timeScale = 0.01f; }else { Time.timeScale = 1; }
    }


    private void OnTriggerEnter2D(Collider2D collision_TR)
    {
        switch (collision_TR.gameObject.tag)
        {
            case "HP_UP":
                Max_HP += HP_Up;
                HP_Bar.fillAmount = Max_HP;
                break;

            case "Mchine Gun":
                weapon = Weapons.Mchine_Gunn;
                fireRate = 0.14f;
                break;


            case "Shot Gun":
                weapon = Weapons.Shot_Gun;
                fireRate = 1f;
                break;

            case "Enemy":
                Max_HP -= Collision_Damage;
                HP_Bar.fillAmount = Max_HP;
                if (Max_HP <= 0 && state == State.Play)
                {
                    state = State.Dead;
                    Spavner.State = false;
                    MenManager.YOu_Dead_Active();
                    Destroy(gameObject);
                }

                break;

            case "Enemy Bullet":
                Max_HP -= Bullet_Damage;
                HP_Bar.fillAmount = Max_HP;

                if (Max_HP <= 0 && state == State.Play)
                {
                    state = State.Dead;
                    Spavner.State = false;
                    MenManager.YOu_Dead_Active();
                    Destroy(gameObject);
                }
                break;

            case "Shooting Speed UP":
                if (weapon == Weapons.Mchine_Gunn)
                {
                    fireRate = 0.06f;
                    Invoke("Fire_Rate_Change", 8f);
                }

                if (weapon == Weapons.Shot_Gun)
                {
                    Invoke("Fire_Rate_Change", 8f);
                    fireRate = 0.1f;
                }
                break;

        }
    }

    private void Gun_Shooting()
    {
        Instantiate(Bullet, transform.position + (transform.up * 0.35f), transform.rotation);

    }


    private void Mchinegun_Shooting()
    {
        Instantiate(Bullet, transform.position + (transform.up * 0.35f), transform.rotation);

    }


    private void Buckshot_Shooting()
    {
        Instantiate(Buckshot, transform.position + (transform.up * 0.35f), transform.rotation);
    }

    private void Fire_Rate_Change()
    {
        if (weapon == Weapons.Mchine_Gunn)
        {
            fireRate = 0.14f;
        }
        if (weapon == Weapons.Shot_Gun)
        {
            fireRate = 1f;
        }
    }
}
