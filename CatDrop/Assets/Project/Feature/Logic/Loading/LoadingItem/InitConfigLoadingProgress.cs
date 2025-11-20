using AppBase.LoadingDeath;
using Cysharp.Threading.Tasks;

public class InitConfigLoadingProgress : BaseProgress
{
    public InitConfigLoadingProgress(float weight) : base(weight)
    {
            
    }


    public override async UniTask Process()
    {
        await UniTask.Delay(1);
        SetProgress(0.5f);
        //TODO:初始化配置
        SetProgress(0.6f);
        await UniTask.Delay(1);
        SetProgress(0.99f);
        Game.Instance.AfterInit();
    }
}