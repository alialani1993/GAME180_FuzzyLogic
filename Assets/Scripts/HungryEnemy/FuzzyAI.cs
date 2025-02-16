using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class FuzzyAI : MonoBehaviour
{
    public NavMeshAgent agent;
    public Transform food;
    [Range(0,1)] public float hunger;
    public float maxMoveSpeed;
    public float maxDistance;
    public Slider urgencySlider;
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
		
	}

    // Update is called once per frame
    void Update()
    {
        float foodUrgency = FoodUrgency(hunger, Vector3.Distance(transform.position, food.position));
        urgencySlider.value = foodUrgency;
        
        if (foodUrgency > 0.3f)
        {
            
            agent.speed = maxMoveSpeed * foodUrgency;
			agent.SetDestination(food.position);
			agent.isStopped = false;
		}
        else {
            agent.isStopped = true;
        }
         


    }

    public float FoodUrgency(float hunger, float distance)
    {
        float distanceFactor = 1 - distance / maxDistance;
        return Mathf.Clamp01((hunger * 0.7f) + (distanceFactor * 0.3f));
    }
}
