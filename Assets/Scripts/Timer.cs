using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] private Text timerText;
    
    public float currentTime;
    public int initialTime = 10;
    
    private void Start()
    {
        currentTime = initialTime;
        UpdateTimerDisplay();
    }
    private void Update()
    {
        if (currentTime > 0)
        {
            currentTime -= Time.deltaTime;
            UpdateTimerDisplay();
        }

        if (currentTime <= 0)
        {
            currentTime = 0;
            UpdateTimerDisplay();
        }
    }
    private void UpdateTimerDisplay()
    {
        int seconds = Mathf.CeilToInt(currentTime);
        timerText.text = seconds.ToString();
    }
    public void ResetTimer()
    {
        currentTime = initialTime;
    }
}
