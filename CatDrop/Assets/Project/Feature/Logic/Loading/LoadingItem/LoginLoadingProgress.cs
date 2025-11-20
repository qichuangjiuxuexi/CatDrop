using AppBase;
using AppBase.LoadingDeath;
using AppBase.NetworkDeath;
using Cysharp.Threading.Tasks;

public class LoginLoadingProgress : BaseProgress
{
    public LoginLoadingProgress(float weight) : base(weight)
    {
            
    }


    public override async UniTask Process()
    {
        await UniTask.Delay(10);
        SetProgress(0.5f);
        await Game.Network.Send(new LoginProtocol());
        SetProgress(0.6f);
        await UniTask.Delay(10);
    }
}