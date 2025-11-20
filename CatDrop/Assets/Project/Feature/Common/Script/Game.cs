using System;
using System.Collections.Generic;
using AppBase;
using AppBase.CommonDeath.Timing;
using AppBase.ConfigDeath;
using AppBase.EventDeath;
using AppBase.LoadingDeath;
using AppBase.Resource;
using AppBase.UI.Dialog;
using AppBase.UI.Scene;
using AppBase.ArchiveDeath;
using AppBase.NetworkDeath;
using AppBase.PlayerInfo;
using GameSDK.UserAssets;
using Project.Logic;
using UnityEngine.Scripting;

public class Game: GameBase
{
    public static Game Module => (Game)Instance;
    
    public static CameraManager Cameras { get; private set; }
    public static NetworkManager Network { get; private set; }
    public static PlayerInfoChildManager PlayerInfo { get; private set; }
    public static UserAssetManager UserAsset { get; private set; }
    public static ConfigManager Config { get; private set; }
    public static ResourceManager Resource { get; private set; }
    public static EventManager Event { get; private set; }
    
    public static DialogManager Dialog { get; private set; }
    
    public static UISceneManager UIScene { get; private set; }
    public static ArchiveManager ArchiveManager { get; private set; }
    
    public static TimingManager Time  { get; private set; }

    public static LevelConfigManager LevelConfigManager { get; private set; }

    public static MatchManager MatchManager { get; private set; }
    
    public static DialogueManager Dialogue  { get; private set; }
    
    public static BuffManager Buff { get; private set; }
    
    public static HeartManager Heart { get; private set; }


    private static Action<float> OnProcess;
    /// <summary>
    /// 启动游戏
    /// </summary>
    [Preserve]
    public static void Start(Action<float> callback)
    {
        if (Instance == null)
        {
            Instance = new Game();
        }
        
        
        OnProcess = callback;
        Instance.InitProcesses();
    }

    public override void InitProcesses()
    {
        var control = new LoadingController(new List<BaseProgress>() { 
            new InitGameLoadingProgress(20),
            new LoginLoadingProgress(20),
            new InitConfigLoadingProgress(20), 
            new SwitchLobbySceneLoadingProcess(10)
        });
        
        control.OnProcess = OnProcess;
        control.Start();
        
    }
    
    
    /// <summary>
    /// 这里初始化既不依赖配置，也不依赖存档的模块
    /// </summary>
    protected override void OnInit()
    {
        Cameras = AddModule<CameraManager>();
        ArchiveManager = AddModule<ArchiveManager>();
        UserAsset = AddModule<UserAssetManager>();
        Heart = AddModule<HeartManager>();
        Resource = AddModule<ResourceManager>();
        Config = AddModule<ConfigManager>();
        Event = AddModule<EventManager>();
        Dialog = AddModule<DialogManager>();
        UIScene = AddModule<UISceneManager>();
        LevelConfigManager = AddModule<LevelConfigManager>();
        MatchManager = AddModule<MatchManager>();
        Time = AddModule<TimingManager>();
        Dialogue = AddModule<DialogueManager>();
        Buff = AddModule<BuffManager>();
        
        PlayerInfo = AddModule<PlayerInfoChildManager>();
        Network = AddModule<NetworkManager>();
    }

    public void StartFightGame()
    {
        World.SwitchToLevel();
    }
}