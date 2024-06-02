using UnityEngine;
using UnityEngine.Events;

public class TimerManager : MonoBehaviour
{
    [Header("Timer Variables")]
    [SerializeField][Range(2f, 10f)] private float startTimer = 5f;
    [SerializeField] private float _timer;
    [SerializeField] private float _elapsedTime = 0f;

    [System.Serializable]
    public class TimerEvent : UnityEvent { }
    public TimerEvent onTimerEnd;

    void Awake()
    {
        _timer = startTimer;
    }

    void Update()
    {
        UpdateTimerValues();

        CheckIfTimerEndToMakeHideBlock();

        ChangeStartTimer();
    }

    private void UpdateTimerValues()
    {
        _elapsedTime += Time.deltaTime;
        _timer -= Time.deltaTime;
    }

    //---------------------------------------------------------------------------------------------------
    //  If timer <=0 that mean time end and know active block hide effect 
    //
    //---------------------------------------------------------------------------------------------------
    private void CheckIfTimerEndToMakeHideBlock()
    {
        if (_timer <= 0)
        {
            onTimerEnd.Invoke();
            _timer = startTimer;
        }
    }
    //---------------------------------------------------------------------------------------------------
    //  Change difficulty Game Here By de decrease _startTimer to 2
    //
    //---------------------------------------------------------------------------------------------------
    private void ChangeStartTimer()
    {
        float decreaseRate = 0.3f;
        float limitUpdate = 5f;
        int minValuedecrease = 2;
        if (_elapsedTime >= limitUpdate && startTimer > minValuedecrease)
        {
            startTimer -= decreaseRate;
            _elapsedTime = 0f;
        }
    }
}
