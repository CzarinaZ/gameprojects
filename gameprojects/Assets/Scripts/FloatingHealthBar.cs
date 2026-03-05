using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class FloatingHealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider; 

    public void UpdateHealthBar(float currentHealth, float startingHealth) {
        slider.value = currentHealth / startingHealth;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
