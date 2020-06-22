using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallManager : MonoBehaviour
{
    public GameObject Top;
    public GameObject Bottom;
    public GameObject Right;
    public GameObject Left;

    private Camera _mainCamera;

    private float _lastX;
    //private Vector3 _lastBottomLeft = new Vector3(0, 0, 0);
    //private Vector3 _lastTopRight = new Vector3(0, 0, 0);

    // Start is called before the first frame update
    void Start()
    {
        _mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        //NB: 
        // after playing, looks like camera automatically maintains height 
        // and 'crops' width... so just need an x boundary :)

        // grab current resolution
        Vector3 bottomLeft = _mainCamera.ViewportToWorldPoint(Vector3.zero);
        //Vector3 topRight = _mainCamera.ViewportToWorldPoint(new Vector3(1, 1, 0));

        // resize walls (if necessary)
        //if ((Mathf.Abs(Vector3.Distance(_lastBottomLeft, bottomLeft)) < 0.1f) &&
        //   (Mathf.Abs(Vector3.Distance(_lastTopRight, topRight)) < 0.1f))
        //    return; //not necessary
        if (Mathf.Approximately(_lastX, bottomLeft.x))
            return;

        // calc and position walls
        Debug.Log($"Bottom Left: {bottomLeft.x}, {bottomLeft.y}, {bottomLeft.z}");
        Left.transform.SetPositionAndRotation(new Vector3(bottomLeft.x - 0.5f, 0), Quaternion.identity);
        Right.transform.SetPositionAndRotation(new Vector3(bottomLeft.x * -1 + 0.5f, 0), Quaternion.identity);

        // capture new camera size
        //_lastBottomLeft = bottomLeft;
        //_lastTopRight = topRight;
        _lastX = bottomLeft.x;
    }
}