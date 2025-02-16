using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class FuzzyAggression : MonoBehaviour
{
    public enum State
    { 
        Passive,
        Aggressive,
        Berserk
    }

    public State currentState;

    public Player player;            
    public float maxDist;
    public float distWeight, hpWeight; //Should sum to 1
    
    public float aggression;
    public Slider slider;
    public TextMeshProUGUI text;
    // Update is called once per frame
    void Update()
    {
        
        aggression = CalculateAggression(player);
        if (aggression < 0.3f)
        {
            currentState = State.Passive;
        }
        else if (aggression < 0.7f)
        {
            currentState = State.Aggressive;
        }
        else if (aggression <= 1.0f)
        {
            currentState = State.Berserk;
        }

        slider.value = aggression;
        text.text = currentState.ToString();
    }

    public float CalculateAggression(Player player)
    {
        float distance = Vector3.Distance(player.transform.position, transform.position);

        float hpFactor = (1 - player.hp / player.maxHP);
        float distFactor = (1 - distance / maxDist);
        float aggression = (hpFactor * hpWeight) + (distFactor * distWeight);

        return aggression;
    }
}
