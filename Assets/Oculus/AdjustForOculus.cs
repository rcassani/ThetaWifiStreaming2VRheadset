﻿using UnityEngine;
using System.Collections;

public class AdjustForOculus : MonoBehaviour {
    public GameObject oculus_camera;
    [Range(20, 220)]
    public int oculus_sphere_size = 220;

	// Use this for initialization
	void Start ()
    {
        Debug.Log("Theta S Wifi streaming in Oculus");
        ResizeSphere();
        ResetOrientation();
	}

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            ResetOrientation();
        }
        if (Input.GetKey(KeyCode.W))
        {
            oculus_sphere_size = oculus_sphere_size + 50;
            ResizeSphere();
        }
        if (Input.GetKey(KeyCode.S))
        {
            oculus_sphere_size = oculus_sphere_size - 50;
            ResizeSphere();
        }


    }

    void ResetOrientation()
    {
        // Obtain Oculus camera orientation
        Vector3 oculus_orientation = oculus_camera.transform.localEulerAngles;
        Vector3 sphere_orientation = new Vector3(0,0,0);
        // Rotate Y in the Sphere such that the difference between Oculus and the Sphere is -90
        sphere_orientation.y = oculus_orientation.y + 90;
        transform.localEulerAngles = sphere_orientation;     
    }

    void ResizeSphere()
    {
        oculus_sphere_size = Mathf.Clamp(oculus_sphere_size, 20, 220);
        Vector3 sphere_scale = new Vector3(-1, 1, 1);
        transform.localScale = oculus_sphere_size * sphere_scale;
        Debug.Log("Sphere size set to:" + oculus_sphere_size.ToString());
    }


}
