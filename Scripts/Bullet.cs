using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Bullet_Speed;
    public float Bullet_Life_Time;


    private void Update()
    {
        transform.Translate(0, Bullet_Speed * Time.deltaTime, 0);
        Invoke("Destroy_Bullet", Bullet_Life_Time);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                Destroy_Bullet();
                break;

            case "Character":
                Destroy_Bullet();
                break;

            case "Wall":
                Destroy_Bullet();
                break;
        }
    }

    private void Destroy_Bullet()
    {
        Destroy(this.gameObject);
    }
}
