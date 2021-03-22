using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Spavner : MonoBehaviour
{
    public GameObject Enemy;

    public float Next_Spavn;
    public float Spavn_Rate;
    public bool State = true;
    public float Vertical_Axis;
    public float Horizontal_Axis;

    private void Update()
    {
        if(State == true && Time.time > Next_Spavn)
        {
            Vertical_Axis = Random.Range(-4.3f, 4.3f);
            Horizontal_Axis = Random.Range(-8.3f, 8.3f);

            Next_Spavn = Time.time + Spavn_Rate;

            transform.position = new Vector3(Horizontal_Axis, Vertical_Axis, 0);

            Just_do_it();
        }
    }

    private void Just_do_it()
    {
        Instantiate(Enemy, transform.position, transform.rotation);
    }
}
