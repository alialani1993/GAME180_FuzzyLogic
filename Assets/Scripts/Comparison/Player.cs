using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float hp, maxHP;
    public Slider hpSlider;
    public TextMeshProUGUI hpLabel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hp = hpSlider.value*100;
        hpLabel.text = "HP: " + hp.ToString("n0");
    }
}
