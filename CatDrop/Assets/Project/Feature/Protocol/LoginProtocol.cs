using AppBase.ArchiveDeath;
using AppBase.PlayerInfo;
using Newtonsoft.Json.Linq;

namespace AppBase.NetworkDeath
{
    /// <summary>
    /// 删档协议
    /// </summary>
    public class LoginProtocol : NetworkProtocol
    {
        public override string service => "player";
        public override string action => "login";
        public override string contentType => "json";
        
        public override byte[] requestBytes => new byte[] { };

        private ArchiveManager archiveManager => GameBase.Instance.GetModule<ArchiveManager>();
        private PlayerInfoArchiveData playerInfo => archiveManager?.GetArchiveData<PlayerInfoArchiveData>(nameof(PlayerInfoRecord));

        public override bool OnSend()
        {
            return true;
        }
        
       
        public override bool OnResponse()
        {
            JObject jsonObj = JObject.Parse(ResponseJson);
            var player = jsonObj["data"]["player"];
            playerInfo.PlayerId = (string)player["id"];
            playerInfo.deviceId = (string)player["device_id"];
            playerInfo.PlayerName = (string)player["username"];
            Game.PlayerInfo.PlayerRecord.Save();
            
            return true;
        }
        
        public override void OnFail()
        {
            
        }
    }
}