using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoolEnemy : MonoBehaviour
{
    public Player player;
    // Start is called before the first frame update
    void Start()
    {
		GetComponent<BoolEnemy>().player = GameObject.Find("Player").GetComponent<Player>();
	}

    // Update is called once per frame
    void Update()
    {
        Aggression(player.hp,Vector3.Distance(transform.position, player.transform.position));
    }

    public void Aggression(float hp, float distance)
    {
        if (hp < 50 & distance < 10)
        {
            GetComponent<Renderer>().material.color = new Color(1, 0, 0, 1);
        }
        else {
			GetComponent<Renderer>().material.color = new Color(0, 0, 0, 1);
		}
    }
}
