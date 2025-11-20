using AppBase.LoadingDeath;
using Cysharp.Threading.Tasks;
using AppBase.UI.Scene;

public class SwitchLobbySceneLoadingProcess : BaseProgress
{
    public SwitchLobbySceneLoadingProcess(float weight) : base(weight)
    {
            
    }

    public override async UniTask Process()
    {
        Game.UIScene.SwitchScene(new TransitionData(AAConst.LobbyUI));
    }
    
}