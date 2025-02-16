using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuzzyBraking : MonoBehaviour
{
    public float speed;
    public float distanceToCarAhead;
    public float brakingForce;

    public float maxSpeed = 50f;
    public float maxDistance = 30f;
    public float minBraking = 0.1f;
    public float maxBraking = 10f;

    [SerializeField] private float speedWeight = 0.7f;   // Speed has a higher impact
    [SerializeField] private float distanceWeight = 0.3f; // Distance has a lower impact

    private Rigidbody rb;
    [SerializeField] private Transform stoppedCar;

    public Slider slider;
    [SerializeField] private float brakeIntensityThreshold;
    [SerializeField] private float distanceThreshold;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * maxSpeed;  // Initial movement
    }

    void Update()
    {
        distanceToCarAhead = Vector3.Distance(transform.position, stoppedCar.position);
        speed = rb.velocity.magnitude;

        brakingForce = CalculateBraking(speed, distanceToCarAhead);
        ApplyBraking(brakingForce);
        
    }

    float CalculateBraking(float speed, float distance)
    {
        // Normalize inputs between 0 and 1
        float speedFactor = Mathf.Clamp01(speed / maxSpeed); // 0 (stopped) to 1 (max speed)
        float distanceFactor = Mathf.Clamp01(1 - (distance / maxDistance)); // 1 (close) to 0 (far)

        // Weighted braking intensity
        float brakeIntensity = (speedFactor * speedWeight) + (distanceFactor * distanceWeight);


        // 
        if (brakeIntensity > brakeIntensityThreshold && distanceFactor > distanceThreshold)
        {
            return brakeIntensity;
        }
        else {
            return 0f;
        }
        
    }

    void ApplyBraking(float brakeAmount)
    {
        float deceleration = Mathf.Lerp(minBraking, maxBraking, brakeAmount);
        rb.AddForce(-rb.velocity.normalized * deceleration, ForceMode.Acceleration);
        slider.value = brakeAmount;
    }


}
    