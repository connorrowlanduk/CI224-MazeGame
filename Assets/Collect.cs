using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collect : MonoBehaviour
{ 
    // Use this for initialization
    void Start()
    {
        Debug.Log("Hello World");
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("ball get pushed");
        if (collision.collider.name == "Player")
        {
            Debug.Log("delete ball");
            Destroy(gameObject);
        }
    }
}