using System.Collections.Generic;
using AppBase.CommonDeath.Timing;
using AppBase.Module;

public class BuffManager : ModuleBase, IUpdateSecond
{
    private BuffRecord record;
    
    private Dictionary<BuffType, BuffBase> buffingItems;

    private List<BuffType> removeList;

    private bool HasDirty;

    protected override void OnInit()
    {
        base.OnInit();
        record = AddModule<BuffRecord>();
        //注册Buff工厂
        RegisterFactory();
        //读取存档buff
        InitRecordBuff();
        
        Game.Time.SubscribeSecondUpdate(this);
    }

    /// <summary>
    /// 初始化时加载存档buff信息
    /// </summary>
    private void InitRecordBuff()
    {
        buffingItems = new();
        removeList = new();
        var buffs = record.GetBuffs();
        foreach (var (type, data) in buffs)
        {
            BuffBase buff = CreateBuff(data.Type, data);
            buffingItems.TryAdd(type, buff);
        }
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
        Game.Time.UnsubscribeSecondUpdate(this);
    }

    /// <summary>
    /// 注册所有buff
    /// </summary>
    private void RegisterFactory()
    {
        BuffFactory.RegisterBuff<HeartAddBuff>(BuffType.HeartAdd);
    }

    public void AddBuff(BuffType type, long seconds)
    {
        var buff = GetOrCreateBuff(type);
        buff.AddTime(seconds);
    }
    
    /// <summary>
    /// 直接设置buff 结束时间
    /// </summary>
    /// <param name="type"></param>
    /// <param name="endTime"></param>
    public void SetBuffEndTime(BuffType type, long endTime)
    {
        var buff = GetOrCreateBuff(type);
        buff.BuffData.EndTime = endTime;
    }


    /// <summary>
    /// 是否在buff中
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public bool HasBuffing(BuffType type)
    {
        return buffingItems.ContainsKey(type);
    }

    private BuffBase GetOrCreateBuff(BuffType type)
    {
        if (buffingItems.TryGetValue(type, out var buff))
        {
            return buff;
        }
        else
        {
            BuffData data = new(type);
            buff = CreateBuff(type, data);
            
            record.AddBuff(type, data);
            HasDirty = true;
            
            buffingItems.TryAdd(type, buff);
            return buff;
        }
    }

    /// <summary>
    /// 创建buff
    /// </summary>
    /// <param name="type"></param>
    /// <param name="data"></param>
    /// <returns></returns>
    private BuffBase CreateBuff(BuffType type, BuffData data)
    {
        BuffBase buff = BuffFactory.CreateBuff(type);
        buff.BuffData = data;
        return buff;
    }


    /// <summary>
    /// 直接移除Buff
    /// </summary>
    /// <param name="type"></param>
    public void RemoveBuff(BuffType type)
    {
        if (buffingItems.ContainsKey(type) && !removeList.Contains(type))
        {
            removeList.Add(type);
        }
    }

    /// <summary>
    /// 每秒更新buff数据
    /// </summary>
    public void OnUpdateSecond()
    {
        if (buffingItems.Count == 0) return;
        
        //更新buff时机
        ForceUpdateBuff();

        //检测是否需要保存
        CheckSetDirty();
    }

    /// <summary>
    /// 强制更新buff数据
    /// </summary>
    public void ForceUpdateBuff()
    {
        List<BuffType> removeTypes = new List<BuffType>();
        List<BuffBase> removeBuffs = new List<BuffBase>();
        
        //强制删除buff
        foreach (var buffType in removeList)
        {
            buffingItems.Remove(buffType);
            record.RemoveBuff(buffType);
            HasDirty = true;
        }
        
        foreach (var (key, buff) in buffingItems)
        {
            if (buff.CheckEnd())
            {
                removeBuffs.Add(buff);
                removeTypes.Add(key);
            }
        }

        if (removeTypes.Count > 0)
        {
            foreach (var removeBuff in removeTypes)
            {
                buffingItems.Remove(removeBuff);
                record.RemoveBuff(removeBuff);
                HasDirty = true;
            }   
        }
        
        if (removeBuffs.Count > 0)
        {
            foreach (var buff in removeBuffs)
            {
                buff.AfterRemove();
            }   
        }
    }

    /// <summary>
    /// 检测是否需要保存数据
    /// </summary>
    private void CheckSetDirty()
    {
        if (HasDirty)
        {
            HasDirty = false;
            record.Save();
        }
    }

    /// <summary>
    /// 获取buff剩余时间
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public long GetBuffLeftTime(BuffType type)
    {
        if (buffingItems.TryGetValue(type, out BuffBase buff))
        {
            return buff.BuffLeftTime;
        }

        return 0;
    }
}
