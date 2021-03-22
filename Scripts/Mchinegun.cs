using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mchinegun : MonoBehaviour
{
    public AudioClip Mcinegun_Take;

    AudioSource AU;

    private void Start()
    {
        AU = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            AU.PlayOneShot(Mcinegun_Take);
            Invoke("Destroyed", 0.4f);
        }
    }

    private void Destroyed()
    {
        Destroy(this.gameObject);
    }
}
