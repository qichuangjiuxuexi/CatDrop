using AppBase.Module;

public class HeartManager : ModuleBase
{
    private int MaxNum => GetMaxHeartCount();
    
    /// <summary>
    /// 当前体力数
    /// </summary>
    public int HeartCount => GetHeartCount();

    /// <summary>
    /// 是否是满体力
    /// </summary>
    public bool IsMax => IsMaxCount();

    protected override void OnInit()
    {
        base.OnInit();
    }

    protected override void OnAfterInit()
    {
        base.OnAfterInit();
        if (HeartCount < 5 && !Game.Buff.HasBuffing(BuffType.HeartAdd))
        {
            Game.Buff.AddBuff(BuffType.HeartAdd, 5);
        }
    }

    private int GetHeartCount()
    {
        return (int)Game.UserAsset.GetAssetItem(ItemConst.Heart).assetNum;
    }

    public bool IsMaxCount()
    {
        return GetHeartCount() >= MaxNum;
    }

    /// <summary>
    /// 添加体力
    /// </summary>
    /// <param name="count"></param>
    public void AddHeartCount(int count = 1)
    {
        if (IsMax)
        {
            Debuggers.Error(TAG, "体力都满了 还加呢？");
            return;
        }
        Game.UserAsset.AddAssetNum(ItemConst.Heart, count);
        if (IsMax)
        {
            Game.UserAsset.SetAssetNum(ItemConst.Heart, MaxNum);
            Game.Buff.RemoveBuff(BuffType.HeartAdd);
        }
    }

    public void SubHeartCount(int count = 1)
    {
        if (HeartCount <=0)
        {
            Debuggers.Error(TAG, "体力都没了 还减少呢？");
            return;
        }
        Game.UserAsset.AddAssetNum(ItemConst.Heart, -count);
        if (!Game.Buff.HasBuffing(BuffType.HeartAdd))
        {
            Game.Buff.AddBuff(BuffType.HeartAdd, GetAddHeartDuring());
        }
    }

    /// <summary>
    /// 获取每加一个体力的间隔
    /// </summary>
    /// <returns></returns>
    public int GetAddHeartDuring()
    {
        return int.Parse(Game.Config.GetValueWithKey<GlobalConfig>(AAConst.GlobalConfig, "AddHeartTime")) * 60;
    }

    /// <summary>
    /// 获取最大体力数
    /// </summary>
    /// <returns></returns>
    private int GetMaxHeartCount()
    {
        return int.Parse(Game.Config.GetValueWithKey<GlobalConfig>(AAConst.GlobalConfig, "MaxHeartCount"));
    }

    /// <summary>
    /// 获取下一次加体力的剩余时间
    /// </summary>
    /// <returns></returns>
    public long GetNextHeartLeft()
    {
        return Game.Buff.GetBuffLeftTime(BuffType.HeartAdd);
    }
}