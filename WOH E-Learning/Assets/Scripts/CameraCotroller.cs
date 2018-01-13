﻿using UnityEngine;
using System.Collections;

public class CameraCotroller : MonoBehaviour {

    public Transform lookAt;

    private Vector3 desiredPosition;
    private Vector3 offset;

    private Vector2 touchPosition;
    private float swipeResistence = 200.0f;

    private float smoothSpeed = 7.5f;
    private float distance = 5.0f;
    private float yOffset = 3.5f;

    private void Start()
    {
        offset = new Vector3(0, yOffset, -1f * distance);
    }

    private void Update()
    {

        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            touchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0) || Input.GetMouseButtonUp(1))
        {
            float swipeForce = touchPosition.x - Input.mousePosition.x;
            if(Mathf.Abs(swipeForce) > swipeResistence)
            {
                if(swipeForce < 0)
                {
                    SlideCamera(true);
                }else
                {
                    SlideCamera(false);
                }
            }
        }

    }

    private void FixedUpdate()
    {
        desiredPosition = lookAt.position + offset;
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(lookAt.position + Vector3.up);
    }

    public void SlideCamera(bool left)
    {
        if (left)
        {
            offset = Quaternion.Euler(0, 90, 0) * offset;
        }else
        {
            offset = Quaternion.Euler(0, -90, 0) * offset;
        }
    }

}
