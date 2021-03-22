using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotGun : MonoBehaviour
{
    public AudioClip Shotgun_Reload;

    AudioSource AU;

    private void Start()
    {
        AU = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            AU.PlayOneShot(Shotgun_Reload);
            Invoke("Destroyed", 1f);
        }
    }

    private void Destroyed()
    {
        Destroy(this.gameObject);
    }
}
