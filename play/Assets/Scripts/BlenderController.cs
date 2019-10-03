﻿using System.Collections;
using UnityEngine;
using System.Collections.Generic;

public class BlenderController : MonoBehaviour
{
    public Camera cam;
    private float maxWidth;

    // Use this for initializaton
    void Start()
    {
        if (cam == null){
            cam = Camera.main;
        }
        Vector3 upperCorner = new Vector3 (Screen.width, Screen.height, 0.0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint (upperCorner);
        float blenderWidth = GetComponent<Renderer>().bounds.extents.x;
        maxWidth = targetWidth.x - blenderWidth;
    }

    // Update is called once once per physics timestep
    void FixedUpdate()
    {
        Vector3 rawPosition = cam.ScreenToWorldPoint (Input.mousePosition);
        Vector3 targetPosition = new Vector3 (rawPosition.x, 0.0f, 0.0f);
        float targetWidth = Mathf.Clamp (targetPosition.x, -maxWidth, maxWidth);
        targetPosition = new Vector3 (targetWidth, targetPosition.y, targetPosition.z);
        GetComponent<Rigidbody2D>().MovePosition (targetPosition);
    }
}
