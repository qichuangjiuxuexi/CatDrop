using System;
using UnityEngine;

[Serializable]
public class HeartAddBuff : BuffBase
{
    public override void OnTrigger()
    {
        Debuggers.Log("Heart Buff", "开始加体力buff");
    }

    public override void OnEnd()
    {
        Game.Heart.AddHeartCount();
        if (!Game.Heart.IsMax)
        {
            Game.Buff.SetBuffEndTime(BuffData.Type, BuffData.EndTime + Game.Heart.GetAddHeartDuring());
            Game.Buff.ForceUpdateBuff();
        }
    }
}