using UnityEngine;



public class CameraZoom : MonoBehaviour
{
    [Header("Zoom Settings")]
    public float zoomSpeed = 5f;             // Base speed of the zoom-out
    public float maxZoomOutDistance = 50f;   // How far to zoom out (backward)
    public float upwardDistance = 20f;       // How high to move upward

    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private bool isZoomingOut = true;
    private float journeyLength;             // Total distance from start to target
    private float startTime;                 // Time when the zoom started

    void Start()
    {
        // Record initial position and calculate target
        initialPosition = transform.position;
        targetPosition = initialPosition 
            - transform.forward * maxZoomOutDistance 
            + Vector3.up * upwardDistance;

        // Calculate the total journey length (distance to target)
        journeyLength = Vector3.Distance(initialPosition, targetPosition);

        // Mark the start time of the zoom-out
        startTime = Time.time;
    }

    void Update()
    {
        if (isZoomingOut)
        {
            // Calculate how far along the journey we are (time-based progress)
            float distanceTraveled = (Time.time - startTime) * zoomSpeed;
            float journeyFraction = distanceTraveled / journeyLength;

            // Apply an easing function to slow down the zoom-out (ease out)
            journeyFraction = Mathf.SmoothStep(0f, 1f, journeyFraction);

            // Move the camera towards the target position
            transform.position = Vector3.Lerp(initialPosition, targetPosition, journeyFraction);

            // Stop when close enough to the target
            if (journeyFraction >= 1f)
                isZoomingOut = false;
        }
    }
}
