﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonPress : MonoBehaviour {
    
    // How long to look at Menu Item before taking action
    public float timerDuration = 2f;
    // This value will count down from the duration
    private float lookTimer = 0f;
    public Image image;
    // Box Collider
    private BoxCollider myCollider;
    // Is player looking at me?
    private bool isLookedAt = false;
    public GameObject IntroManager;

    // MonoBehaviour Start
    void Start()
    {
        // My Collider
        myCollider = GetComponent<BoxCollider>();
        image.fillAmount = 1;
    }

    // MonoBehaviour Update
    void Update()
    {
        // While player is looking at me
        if (isLookedAt)
        {
            // Reduce Timer
            lookTimer += Time.deltaTime;
            image.fillAmount = 1 - (lookTimer / timerDuration);
            
            if (lookTimer > timerDuration)
            {
                // Reset timer
                lookTimer = 0f;

                // disable collider
                myCollider.enabled = false;

                IntroManager.GetComponent<Intro>().GameIntro();
                // Disappear
                gameObject.SetActive(false);
            }
        }
        else
        {
            // Reset Timer
            lookTimer = 0f;
            image.fillAmount = 1;
        }
    }

    // Google Cardboard Gaze
    public void SetGazedAt(bool gazedAt)
    {
        // Set the local bool to the one passed from Event Trigger
        isLookedAt = gazedAt;
    }
}
