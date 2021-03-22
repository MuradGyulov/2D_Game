using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HP_UP : MonoBehaviour
{
    public AudioClip HPSound;

    AudioSource AU;

    private void Start()
    {
        AU = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Character")
        {
            AU.PlayOneShot(HPSound);
            Invoke("Destroyed", 0.4f);
        }
    }

    private void Destroyed()
    {
        Destroy(this.gameObject);
    }
}
