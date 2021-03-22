using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyObject", 1f);


        
    }

    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
