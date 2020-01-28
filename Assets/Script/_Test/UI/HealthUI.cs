using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour {

    public static HealthUI Get { get; private set; }
    [HideInInspector]
    public Slider slider;
    [HideInInspector]
    public Image fill;

    HealthUI() {
        Get = this;
    }
    private void Awake() {
        slider = GetComponent<Slider>();
        fill = slider.fillRect.GetComponent<Image>();
    }
}
