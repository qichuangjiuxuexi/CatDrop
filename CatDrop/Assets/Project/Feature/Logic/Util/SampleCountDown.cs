using System;
using TMPro;
using UnityEngine;

internal struct TimeSeparate
{
    public int hour;

    public int min;

    public int second;

    public TimeSeparate(float totalSeconds)
    {
        var timeSpan = TimeSpan.FromSeconds(totalSeconds);
        hour = timeSpan.Hours;
        if (timeSpan.Days > 0)
        {
            hour += timeSpan.Days * 24;
        }
        min = timeSpan.Minutes;
        second = timeSpan.Seconds;
    }
}

public class SampleCountDown : MonoBehaviour
{
    private Action<TimeSpan> OnUpdate { set; get; }   //更新回调
    private Action OnComplete { set; get; }           //完成回调
    private float LeftSeconds { set; get; }          //剩余秒数
    private bool IsCountDown { set; get; }         //开始倒数
    private float Interval { set; get; }          //每次更新时间间隔
    private TextMeshProUGUI _text;                   //label
    private DateTime EndTimeSpan;                     //结束时间
    private bool IsAbbr;                          //是否展示缩写 h:m:s
    private bool updateEnabled;

    public void Init(TextMeshProUGUI textMeshProUGUI, float countTime, Action onComplete = null, bool abbr = false, float updateTime = 1)
    {
        StopCountDown();
        _text = textMeshProUGUI;
        LeftSeconds = countTime;
        OnComplete = onComplete;
        Interval = updateTime;
        EndTimeSpan = DateTime.Now.AddSeconds(LeftSeconds);
        IsAbbr = abbr;
        updateEnabled = true; //默认开启
        StartCountDown();
    }

    private void StartCountDown()
    {
        if (IsCountDown)
        {
            Debug.LogWarning("不对劲怎么有开始了呢");
            return;
        }

        IsCountDown = true;
        InvokeRepeating(nameof(UpdateTime), 0, Interval);
    }

    public void StopCountDown()
    {
        if (!IsCountDown) return;
        IsCountDown = false;
        CancelInvoke(nameof(UpdateTime));
    }
    
    /// <summary>
    /// 设置是否更新
    /// </summary>
    /// <param name="pEnabled"></param>
    public void SetUpdateEnable(bool pEnabled)
    {
        updateEnabled = pEnabled;
    }

    private void UpdateTime()
    {
        if (!IsCountDown) return;
        if (_text == null) return;
        if (!updateEnabled) return;
        
        
        int leftSeconds = (int)(EndTimeSpan - DateTime.Now).TotalSeconds;
        LeftSeconds = leftSeconds;
        if (leftSeconds > 0)
        {
            RefreshText(leftSeconds);
        }
        else
        {
            IsCountDown = false;
            OnComplete?.Invoke();
            StopCountDown();
        }
        OnUpdate?.Invoke(EndTimeSpan - DateTime.Now);
    }

    public void RefreshText(float totalSeconds)
    {
        if (_text == null) return;

        string text = "";
        text = IsAbbr ? GetTimeCountDownStringWithAbbr(totalSeconds) : GetTimeCountDownString(totalSeconds);
        _text.text = text;
    }
    
    private string GetTimeCountDownString(float totalSeconds)
    {
        TimeSeparate span = new TimeSeparate(totalSeconds);

        string hour = span.hour >= 10 ? span.hour.ToString() : "0" + span.hour;
        string min = span.min >= 10 ? span.min.ToString() : "0" + span.min;
        string second = span.second >= 10 ? span.second.ToString() : "0" + span.second;
        
        if (span.hour >= 1)
        {
            if (span.min == 0)
            {
                return span.hour + "h";
            }

            return hour + ":" + min + ":" + second;
        }
        
        return  min + ":" + second;
    }

    public void AddLeftTime(int offset, bool isNeedRefresh = true)
    {
        LeftSeconds += offset;
        EndTimeSpan = EndTimeSpan.AddSeconds(offset);
        if (isNeedRefresh)
            UpdateTime();
    }
    
    public void SetOnUpdate(Action<TimeSpan> action)
    {
        OnUpdate = action;
    }

    private string GetTimeCountDownStringWithAbbr(float totalSeconds)
    {
        TimeSeparate span = new TimeSeparate(totalSeconds);
        var hour = span.hour;
        var min = span.min;
        //大于一天
        if (hour >= 24)
        {
            var remainHour = hour % 24;
            if (remainHour == 0)
            {
                return (hour / 24) + "d";
            }
            return (hour / 24) + "d " + remainHour + "h";
        }
        
        if (hour >= 1)
        {
            if (min == 0)
            {
                return hour + "h";
            }

            return hour + "h" + min + "m";
        }
        
        return  min + "m" + span.second + "s";
    }

    /// <summary>
    /// 获取剩余时间
    /// </summary>
    /// <returns></returns>
    public float GetRemainTime()
    {
        return (float)(EndTimeSpan - DateTime.Now).TotalSeconds;
    }
}