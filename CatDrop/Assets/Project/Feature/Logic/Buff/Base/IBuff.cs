using System;
using AppBase.CommonDeath.Timing;
using AppBase.EventDeath;

public interface IBuff
{
    void TriggerBuff();
    void EndBuff();
    bool CheckEnd();
}

public class BuffEndEvent : IEventData
{
    public BuffType Type;

    public BuffEndEvent(BuffType type)
    {
        Type = type;
    }
}

[Serializable]
public class BuffData
{
    public BuffType Type;
    public long EndTime = 0;

    public BuffData(BuffType type)
    {
        Type = type;
    }
}


/// <summary>
/// Buff基类
/// </summary>
public abstract class BuffBase : IBuff
{
    public BuffData BuffData;

    public long BuffLeftTime => Math.Max(0, BuffData.EndTime - TimeUtil.GetTimeStamp());

    /// <summary>
    /// 触发buff
    /// </summary>
    public virtual void TriggerBuff()
    {
        OnTrigger();
    }

    public abstract void OnTrigger();

    /// <summary>
    /// 添加时间
    /// </summary>
    public virtual void AddTime(long seconds)
    {
        if (BuffLeftTime == 0)
        {
            BuffData.EndTime = TimeUtil.GetTimeStamp();
            TriggerBuff();
        }
        BuffData.EndTime += seconds;
    }

    public bool CheckEnd()
    {
        return CheckTimeEnd();
    }

    /// <summary>
    /// 检测buff结束条件
    /// </summary>
    /// <returns></returns>
    public virtual bool CheckTimeEnd()
    {
        return BuffLeftTime == 0;
    }
    
    
    public virtual void EndBuff()
    {
        OnEnd();
    }
    /// <summary>
    /// 结束buff
    /// </summary>
    public abstract void OnEnd();

    
    /// <summary>
    /// 移除buff之后的方法
    /// </summary>
    public void AfterRemove()
    {
        OnAfterRemove();
    }
    
    public virtual void OnAfterRemove()
    {
        OnEnd();
    }
}