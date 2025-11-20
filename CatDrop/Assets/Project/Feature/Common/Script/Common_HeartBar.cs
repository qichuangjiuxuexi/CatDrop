using System;
using AppBase.UI;
using GameSDK.UserAssets;

public partial class Common_HeartBar : UIView
{
    private SampleCountDown countDown;
    
    private void Awake()
    {
        Game.Event.AddEventListener<EventUserAssetChange>(OnAssetChange);
    }

    private void OnDestroy()
    {
        Game.Event.RemoveEventListener<EventUserAssetChange>(OnAssetChange);
    }

    private void OnAssetChange(EventUserAssetChange evt)
    {
        if (evt.assetId == ItemConst.Heart)
        {
            numText.TextMeshProUGUI.text = Game.Heart.HeartCount.ToString();
            UpdateTimeText();
        }
    }


    public void Init()
    {
        numText.TextMeshProUGUI.text = Game.Heart.HeartCount.ToString();
        UpdateTimeText();
    }

    private void UpdateTimeText()
    {
        FullText.SetActive(Game.Heart.IsMax);
        TimeText.SetActive(!Game.Heart.IsMax);
        if (Game.Heart.IsMax)
        {
            if (countDown != null)
            {
                countDown.StopCountDown();
            }
        }
        else
        {
            countDown = TimeText.TextMeshProUGUI.SetCountDown(Game.Heart.GetNextHeartLeft());
        }
    }
}
