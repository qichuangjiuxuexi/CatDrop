using AppBase.LoadingDeath;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class InitGameLoadingProgress : BaseProgress
{
    public InitGameLoadingProgress(float weight) : base(weight)
    {
            
    }

    public override async UniTask Process()
    {
        await UniTask.Delay(1);
        //屏幕永不休眠
        Screen.sleepTimeout = SleepTimeout.NeverSleep;
        //帧率
        Application.targetFrameRate = 60;
        Game.Instance.Init();
    }
}