using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    Text txt;
    int collectedBall = 0;

    // Use this for initialization
    void Start()
    {
        Text txt = gameObject.GetComponent<Text>();

        Debug.Log("Hello World");
    }

    // Update is called once per frame
    void Update()
    {
        float x = 0.0f;
        float z = 0.0f;

        if (Input.GetKey("w") || Input.GetKey("up"))
            x += 1.0f;
        if (Input.GetKey("a") || Input.GetKey("left"))
            z += 1.0f;
        if (Input.GetKey("s") || Input.GetKey("down"))
            x += -1.0f;
        if (Input.GetKey("d") || Input.GetKey("right"))
            z += -1.0f;

        transform.Translate(new Vector3(x, 0.0f, z) * 10 * Time.deltaTime, Space.World);
    }

    void OnCollisionEnter(Collision collision)
    {
        //Debug.Log("ball get pushed");
        if (collision.collider.name == "Collect")
        {
            collectedBall++;

            txt.text = collectedBall + " collected ball";
        }
    }
}