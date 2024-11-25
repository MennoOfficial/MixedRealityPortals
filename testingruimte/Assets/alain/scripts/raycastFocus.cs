using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.OpenXR.Input;

public class raycastFocus : MonoBehaviour
{
    public Camera fpsCam;
    private float focusRange = 3f;
    public Transform focusEnd;
    RaycastHit hit;
    private LineRenderer laserLine;
    private float Timer;
    private int seconde = 1;
    private int moodMeter = 50;
    // voeg als raycast iets raakt toe
    // Start is called before the first frame update
    void Start()
    {
        fpsCam = gameObject.GetComponent<Camera>();
        laserLine = GetComponentInChildren<LineRenderer>();
        StartCoroutine(addSecond());
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 rayOrigin = fpsCam.ViewportToWorldPoint(new Vector3(.5f, .5f, 0));
        RaycastHit hit;
        laserLine.SetPosition(0, focusEnd.position);
        // Check if our raycast has hit anything
        if (Physics.Raycast(rayOrigin, fpsCam.transform.forward, out hit, focusRange))
        {
            // Set the end position for our laser line 
            laserLine.SetPosition(1, hit.point);
            // Check if the object we hit has a rigidbody attached
            if (hit.rigidbody != null)
            {
                Timer += Time.deltaTime;

                if (Timer >= seconde)
                {
                    Timer = 0f;
                    moodMeter = moodMeter + 1;
                    Debug.Log(moodMeter);
                }
            }
        }
        else
        {
            // If we did not hit anything, set the end of the line to a position directly in front of the camera at the distance of weaponRange
            laserLine.SetPosition(1, rayOrigin + (fpsCam.transform.forward * focusRange));
        }
    }
    IEnumerator addSecond()
    {
        while (true)
        {
            //Wait for 30 seconds
            yield return new WaitForSeconds(30);

            //Increment Speed
            incrementMeter();
        }

    }

    void incrementMeter()
    {
        moodMeter = moodMeter + 1;
    }
}
