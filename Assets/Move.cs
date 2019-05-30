using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    //Text txt;
    UnityEngine.UI.Text txt;

    int collectedBall = 0;

    // Use this for initialization
    void Start()
    {
        Debug.Log("Hello World");

        // Load the Arial font from the Unity Resources folder.
        Font arial;
        arial = (Font)Resources.GetBuiltinResource(typeof(Font), "Arial.ttf");

        // Create Canvas GameObject.
        GameObject canvasGO = new GameObject();
        canvasGO.name = "Canvas";
        canvasGO.AddComponent<Canvas>();
        canvasGO.AddComponent<CanvasScaler>();
        canvasGO.AddComponent<GraphicRaycaster>();

        // Get canvas from the GameObject.
        Canvas canvas;
        canvas = canvasGO.GetComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;

        // Create the Text GameObject.
        GameObject textGO = new GameObject();
        textGO.transform.parent = canvasGO.transform;
        textGO.AddComponent<Text>();

        // Set Text component properties.
        txt = textGO.AddComponent<UnityEngine.UI.Text>();
        txt.font = arial;
        txt.text = "0/8 Ball";
        txt.fontSize = 48;
        txt.alignment = TextAnchor.MiddleCenter;

        // Provide Text position and size using RectTransform.
        RectTransform rectTransform;
        rectTransform = txt.GetComponent<RectTransform>();
        rectTransform.localPosition = new Vector3(-650, -300, 0);
        rectTransform.sizeDelta = new Vector2(600, 200);
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

            txt.text = collectedBall + "/8 Ball";
        }
    }
}