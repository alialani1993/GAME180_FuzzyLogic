using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuzzyEnemy : MonoBehaviour
{
    public Player player;
    public float maxHp, maxDist;
    private void Start()
    {

	    GetComponent<FuzzyEnemy>().player = GameObject.Find("Player").GetComponent<Player>();	

	}

    // Update is called once per frame
    void Update()
    {
        float aggression = Aggression(player.hp, Vector3.Distance(player.transform.position, transform.position));

		GetComponent<Renderer>().material.color = new Color(aggression,0,0,1);
        
    }

    public float Aggression(float hp, float distance)
    {
        float aggression = (1 - hp / maxHp) * 0.7f + (1 - distance / maxDist) * 0.3f;

		return Mathf.Clamp(aggression,0f,1f);
    }
}
