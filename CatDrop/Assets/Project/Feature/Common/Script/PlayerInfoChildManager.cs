using AppBase.CommonDeath;
using AppBase.PlayerInfo;

public class PlayerInfoChildManager : PlayerInfoManager
{
    /// <summary>
    /// 创建新存档
    /// </summary>
    protected override void OnNewRecord()
    {
        Game.UserAsset.SetAssetNum(ItemConst.Coin, 100);
        Game.UserAsset.SetAssetNum(ItemConst.Heart, 5);
        PlayerRecord.ArchiveData.deviceId = AppUtil.DeviceId;
        PlayerRecord.Save();
    }
}