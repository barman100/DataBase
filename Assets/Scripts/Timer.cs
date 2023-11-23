using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] Text _timerText;  
    public float CurrentTime;
    public float InitialTime = 10;
    public float FinalTime;
    
    private void Start()
    {
        CurrentTime = InitialTime;
        UpdateTimerDisplay();
    }
    private void Update()
    {
        TimerDisplay();
    }
    private void TimerDisplay()
    {
        if (CurrentTime > 0)
        {
            CurrentTime -= Time.deltaTime;
            UpdateTimerDisplay();
        }

        if (CurrentTime <= 0)
        {
            CurrentTime = 0;
            UpdateTimerDisplay();
        }
    }
    private void UpdateTimerDisplay()
    {
        int seconds = Mathf.CeilToInt(CurrentTime);
        _timerText.text = seconds.ToString();
    }
    public void ResetTimer()
    {
        CurrentTime = InitialTime;
    }
}
