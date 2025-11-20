using System.Collections;
using System.Collections.Generic;
using AppBase.UI;
using UnityEngine;

public partial class Common_CoinBar : UIView 
{
    public void Init()
    {
        numText.TextMeshProUGUI.text = Game.UserAsset.GetAssetNum(ItemConst.Coin).ToString();
    }
}
