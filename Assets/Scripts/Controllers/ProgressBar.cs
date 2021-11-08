using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    [SerializeField]
    private float _fillSpeed = 5f;

    private Slider slider;

    private void Awake() {
        slider = gameObject.GetComponent<Slider>();
    }
    
    public void SetProgress(float progress) {
        slider.value = Mathf.Lerp(slider.value, progress, Time.deltaTime * _fillSpeed);
    }
}
