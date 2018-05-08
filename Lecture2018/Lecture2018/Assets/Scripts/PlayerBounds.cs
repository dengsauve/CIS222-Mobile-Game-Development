using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBounds : MonoBehaviour {

    private float minX, maxX;

    // Use this for initialization
    void Start () {
        Vector2 bounds = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));
        // assuming the camera is centered at 0 on the x-axis
        minX = -bounds.x;
        maxX = bounds.x;
    }

    // Update is called once per frame
    void Update () {
        Vector2 currentPos = transform.position;

        if (currentPos.x > maxX)
            currentPos.x = maxX;
        if (currentPos.x < minX)
            currentPos.x = minX;

        transform.position = currentPos;
    }
}
