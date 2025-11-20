using System;
using UnityEngine;
using UnityEngine.UI;

namespace AppBase.UI.Canvas
{
    public class CanvasScaleAdapter : MonoBehaviour
    {
        private void Awake()
        {
            var canvasScaler = GetComponent<CanvasScaler>();
            var res = canvasScaler.referenceResolution;
            canvasScaler.matchWidthOrHeight = (float)Screen.width / Screen.height >= res.x / res.y ? 1 : 0;
        }
    }
}