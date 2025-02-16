using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BooleanBraking : MonoBehaviour
{
    public float speed;
    public float distanceToCarAhead;

    public float maxSpeed = 50f;
    public float brakeThreshold = 10f; // Distance at which braking starts
    public float brakingForce = 10f;   // Fixed braking force

    private Rigidbody rb;
    [SerializeField] private Transform stoppedCar;
    [SerializeField] private Image indicator;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * maxSpeed;  // Initial movement
        
    }

    void Update()
    {
        distanceToCarAhead = Vector3.Distance(transform.position, stoppedCar.position);
        speed = rb.velocity.magnitude;

        if (distanceToCarAhead < brakeThreshold && speed > 0f)
        {
            ApplyBraking();
            indicator.color = Color.red;
        }
        else {
            indicator.color = Color.white;
        }   
    }

    void ApplyBraking()
    {
        rb.AddForce(-rb.velocity.normalized * brakingForce, ForceMode.Acceleration);
    }
}
