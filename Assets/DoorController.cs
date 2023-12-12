using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour
{
    public KeyCode doorKey = KeyCode.B; // Change this to the desired key
    private bool isDoorOpen = false;
    private Animator doorAnimator;

    private void Start()
    {
        // Assuming you have an Animator component attached to the door GameObject
        doorAnimator = GetComponent<Animator>();
    }

    private void Update()
    {
        // Check if the player presses the interactKey
        if (Input.GetKeyDown(doorKey))
        {
            // Toggle the door state
            ToggleDoor();
        }
    }

    private void ToggleDoor()
    {
        // Toggle the door's open/close state
        isDoorOpen = !isDoorOpen;

        // Trigger the door animation (assuming you have an Animator with "Open" parameter)
        doorAnimator.SetBool("Open", isDoorOpen);
    }
}
