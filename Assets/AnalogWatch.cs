using UnityEngine;
using System;

public class AnalogWatch : MonoBehaviour
{
    public Transform hourHand;   // Assign Hour Hand
    public Transform minuteHand; // Assign Minute Hand
    public Transform secondHand; // Assign Second Hand

    private float timer = 0f; // Tracks elapsed time

    void Start()
    {
        UpdateClock(); // Update immediately on start
    }

    void Update()
    {
        timer += Time.deltaTime; // Increment timer

        if (timer >= 1f) // If 1 second has passed
        {
            UpdateClock();
            timer = 0f; // Reset timer
        }
    }

    void UpdateClock()
    {
        DateTime currentTime = DateTime.Now;

        float seconds = currentTime.Second + currentTime.Millisecond / 1000f;
        float minutes = currentTime.Minute + seconds / 60f;
        float hours = currentTime.Hour % 12 + minutes / 60f;

        // Convert time to rotation angles
        float secondAngle = seconds * 6f; // 360° / 60
        float minuteAngle = minutes * 6f; // 360° / 60
        float hourAngle = hours * 30f;    // 360° / 12

        // Apply rotations
        if (secondHand) secondHand.localRotation = Quaternion.Euler(secondAngle, 0, 0);
        if (minuteHand) minuteHand.localRotation = Quaternion.Euler(minuteAngle, 0, 0);
        if (hourHand) hourHand.localRotation = Quaternion.Euler(hourAngle, 0, 0);
    }
}
