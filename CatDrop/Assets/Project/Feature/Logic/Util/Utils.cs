using System;
using System.Collections.Generic;
using AppBase.Resource;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Object = UnityEngine.Object;

public static class Utils
{
    #region ---------- Transform 坐标扩展 ----------

    /// <summary>
    /// 局部坐标x位置扩展
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="newX"></param>
    public static void SetLocalPositionX(this Transform transform, float newX)
    {
        if (transform == null || transform.gameObject == null) return;
        var pos = transform.localPosition;
        pos.x = newX;
        transform.localPosition = pos;
    }

    /// <summary>
    /// 局部坐标y位置扩展
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="newY"></param>
    public static void SetLocalPositionY(this Transform transform, float newY)
    {
        if (transform == null || transform.gameObject == null) return;
        var pos = transform.localPosition;
        pos.y = newY;
        transform.localPosition = pos;
    }

    /// <summary>
    /// 局部坐标z位置扩展
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="newZ"></param>
    public static void SetLocalPositionZ(this Transform transform, float newZ)
    {
        if (transform == null || transform.gameObject == null) return;
        var pos = transform.localPosition;
        pos.z = newZ;
        transform.localPosition = pos;
    }

    /// <summary>
    /// 局部坐标x,y位置扩展
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="newX"></param>
    /// <param name="newY"></param>
    public static void SetLocalPositionXY(this Transform transform, float newX, float newY)
    {
        if (transform == null || transform.gameObject == null) return;
        var pos = transform.localPosition;
        pos.x = newX;
        pos.y = newY;
        transform.localPosition = pos;
    }

    /// <summary>
    /// 局部坐标x,z位置扩展
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="newX"></param>
    /// <param name="newZ"></param>
    public static void SetLocalPositionXZ(this Transform transform, float newX, float newZ)
    {
        if (transform == null || transform.gameObject == null) return;
        var pos = transform.localPosition;
        pos.x = newX;
        pos.y = newZ;
        transform.localPosition = pos;
    }

    /// <summary>
    /// 局部坐标y,z位置扩展
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="newY"></param>
    /// <param name="newZ"></param>
    public static void SetLocalPositionYZ(this Transform transform, float newY, float newZ)
    {
        if (transform == null || transform.gameObject == null) return;
        var pos = transform.localPosition;
        pos.y = newY;
        pos.z = newZ;
        transform.localPosition = pos;
    }

    /// <summary>
    /// 设置新世界坐标x
    /// </summary>
    /// <param name="transform"> </param>
    /// <param name="x"> </param>
    public static void SetX(this Transform transform, float x)
    {
        if (transform == null || transform.gameObject == null) return;
        var pos = transform.position;
        pos.x = x;
        transform.position = pos;
    }

    /// <summary>
    /// 设置新世界坐标y
    /// </summary>
    /// <param name="transform"> </param>
    /// <param name="y">Value of y.</param>
    public static void SetY(this Transform transform, float y)
    {
        if (transform == null || transform.gameObject == null) return;
        var pos = transform.position;
        pos.y = y;
        transform.position = pos;
    }

    /// <summary>
    /// 设置新世界坐标z
    /// </summary>
    /// <param name="transform"> </param>
    /// <param name="z">Value of z.</param>
    public static void SetZ(this Transform transform, float z)
    {
        if (transform == null || transform.gameObject == null) return;
        var pos = transform.position;
        pos.z = z;
        transform.position = pos;
    }

    #endregion ---------- Transform 位置扩展 ----------

    #region ---------- Transform 旋转扩展 ----------
    
    /// <summary>
    /// 局部角度x旋转扩展
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="newX"></param>
    public static void SetLocalRotateX(this Transform transform, float newX)
    {
        if (transform == null || transform.gameObject == null) return;
        var localEulerAngles = transform.localEulerAngles;
        localEulerAngles.x = newX;
        transform.localEulerAngles = localEulerAngles;
    }

    /// <summary>
    /// 局部角度y旋转扩展
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="newY"></param>
    public static void SetLocalRotateY(this Transform transform, float newY)
    {
        if (transform == null || transform.gameObject == null) return;
        var localEulerAngles = transform.localEulerAngles;
        localEulerAngles.y = newY;
        transform.localEulerAngles = localEulerAngles;
    }

    /// <summary>
    /// 局部角度z旋转扩展
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="newZ"></param>
    public static void SetLocalRotateZ(this Transform transform, float newZ)
    {
        if (transform == null || transform.gameObject == null) return;
        var localEulerAngles = transform.localEulerAngles;
        localEulerAngles.z = newZ;
        transform.localEulerAngles = localEulerAngles;
    }

    /// <summary>
    /// 局部角度x,y旋转扩展
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="newX"></param>
    /// <param name="newY"></param>
    public static void SetLocalRotateXY(this Transform transform, float newX, float newY)
    {
        if (transform == null || transform.gameObject == null) return;
        var localEulerAngles = transform.localEulerAngles;
        localEulerAngles.x = newX;
        localEulerAngles.y = newY;
        transform.localEulerAngles = localEulerAngles;
    }

    /// <summary>
    /// 局部角度x,z旋转扩展
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="newX"></param>
    /// <param name="newZ"></param>
    public static void SetLocalRotateXZ(this Transform transform, float newX, float newZ)
    {
        if (transform == null || transform.gameObject == null) return;
        var localEulerAngles = transform.localEulerAngles;
        localEulerAngles.x = newX;
        localEulerAngles.z = newZ;
        transform.localEulerAngles = localEulerAngles;
    }

    /// <summary>
    /// 局部角度y,z旋转扩展
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="newY"></param>
    /// <param name="newZ"></param>
    public static void SetLocalRotateYZ(this Transform transform, float newY, float newZ)
    {
        if (transform == null || transform.gameObject == null) return;
        var localEulerAngles = transform.localEulerAngles;
        localEulerAngles.y = newY;
        localEulerAngles.z = newZ;
        transform.localEulerAngles = localEulerAngles;
    }

    #endregion ---------- Transform 旋转扩展 ----------

    #region ---------- Transform 缩放扩展 ----------
    
    /// <summary>
    /// x缩放扩展
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="newX"></param>
    public static void SetLocalScaleX(this Transform transform, float newX)
    {
        if (transform == null || transform.gameObject == null) return;
        var pos = transform.localScale;
        pos.x = newX;
        transform.localScale = pos;
    }

    /// <summary>
    /// y缩放扩展
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="newY"></param>
    public static void SetLocalScaleY(this Transform transform, float newY)
    {
        if (transform == null || transform.gameObject == null) return;
        var pos = transform.localScale;
        pos.y = newY;
        transform.localScale = pos;
    }

    /// <summary>
    /// z缩放扩展
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="newZ"></param>
    public static void SetLocalScaleZ(this Transform transform, float newZ)
    {
        if (transform == null || transform.gameObject == null) return;
        var pos = transform.localScale;
        pos.z = newZ;
        transform.localScale = pos;
    }

    /// <summary>
    /// x,y缩放扩展
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="newX"></param>
    /// <param name="newY"></param>
    public static void SetLocalScaleXY(this Transform transform, float newX, float newY)
    {
        if (transform == null || transform.gameObject == null) return;
        var pos = transform.localScale;
        pos.x = newX;
        pos.y = newY;
        transform.localScale = pos;
    }

    /// <summary>
    /// x,z缩放扩展
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="newX"></param>
    /// <param name="newZ"></param>
    public static void SetLocalScaleXZ(this Transform transform, float newX, float newZ)
    {
        if (transform == null || transform.gameObject == null) return;
        var pos = transform.localScale;
        pos.x = newX;
        pos.z = newZ;
        transform.localScale = pos;
    }

    /// <summary>
    /// y,z缩放扩展
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="newY"></param>
    /// <param name="newZ"></param>
    public static void SetLocalScaleYZ(this Transform transform, float newY, float newZ)
    {
        if (transform == null || transform.gameObject == null) return;
        var pos = transform.localScale;
        pos.y = newY;
        pos.z = newZ;
        transform.localScale = pos;
    }

    /// <summary>
    /// 同比放缩
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="bat">倍数</param>
    public static void SetLocalScaleBat(this Transform transform, float bat)
    {
        if (transform == null || transform.gameObject == null) return;
        var pos = transform.localScale;
        transform.localScale = pos * bat;
    }
    
    /// <summary>
    /// 设置transform.scale
    /// </summary>
    public static void SetLocalScaleSameXY(this Transform transform, float value)
    {
        if (transform == null) return;
        transform.localScale = new Vector3(value, value, 1);
    }

    #endregion ---------- Transform 缩放扩展 ----------

    #region ---------- RectTransform 扩展 ----------
        
    /// <summary>
    /// 转换为 RectTransform
    /// </summary>
    /// <param name="t"></param>
    /// <returns></returns>
    public static RectTransform GetRectTransform(this Transform t)
    {
        if (t != null)
        {
            return t as RectTransform;
        }

        return null;
    }
    
    /// <summary>
    /// 安全设置sizeDelta.x
    /// </summary>
    public static void SetSizeDeltaX(this RectTransform rect, float w)
    {
        if (rect == null || rect.gameObject == null) return;
        var size = rect.sizeDelta;
        size.x = w;
        rect.sizeDelta = size;
    }

    /// <summary>
    /// 安全设置sizeDelta.y
    /// </summary>
    public static void SetSizeDeltaY(this RectTransform rect, float h)
    {
        if (rect == null || rect.gameObject == null) return;
        var size = rect.sizeDelta;
        size.y = h;
        rect.sizeDelta = size;
    }

    /// <summary>
    /// 安全设置sizeDelta
    /// </summary>
    public static void SetSizeDelta(this RectTransform rect, Vector2 size)
    {
        if (rect == null || rect.gameObject == null) return;
        rect.sizeDelta = size;
    }
    
    /// <summary>
    /// 设置 RectTransform 真实尺寸
    /// </summary>
    /// <param name="trans"></param>
    /// <param name="newSize"></param>
    public static void SetRectTransformSize(this RectTransform trans, Vector2 newSize)
    {
        if (trans != null)
        {
            var oldSize = trans.rect.size;
            var deltaSize = newSize - oldSize;
            var pivot = trans.pivot;
            trans.offsetMin -= new Vector2(deltaSize.x * pivot.x, deltaSize.y * pivot.y);
            trans.offsetMax += new Vector2(deltaSize.x * (1f - pivot.x), deltaSize.y * (1f - pivot.y));
        }
    }
    
    /// <summary>
    /// 将屏幕空间点转换为 RectTransform 的局部空间中位于其矩形平面上的位置。
    /// </summary>
    /// <param name="rect"></param>
    /// <param name="screenPoint"></param>
    /// <param name="cam"></param>
    /// <param name="localPoint"></param>
    /// <returns></returns>
    public static bool ScreenPointToLocalPointInRectangle(this RectTransform rect, Vector2 screenPoint, Camera cam, out Vector2 localPoint)
    {
        return RectTransformUtility.ScreenPointToLocalPointInRectangle(rect, screenPoint, cam, out localPoint);
    }

    /// <summary>
    /// 将世界坐标转换为局部坐标
    /// </summary>
    /// <param name="rect"></param>
    /// <param name="worldPos"></param>
    /// <returns></returns>
    public static Vector3 World2LocalPosition(this RectTransform rect, Vector3 worldPos)
    {
        Vector3 localPoint = (Vector2) rect.InverseTransformPoint(worldPos);
        return localPoint;
    }

    #endregion ---------- RectTransform 扩展 ----------

    #region ---------- 其他扩展 ----------

    /// <summary>
    /// 搜索第一个存在的路径Transform
    /// </summary>
    /// <param name="transform"></param>
    /// <param name="paths"></param>
    /// <returns></returns>
    public static Transform Finds(this Transform transform, params string[] paths)
    {
        if (transform == null || paths.Length == 0) return null;
        foreach (var name in paths)
        {
            var t = transform.Find(name);
            if (t != null) return t;
        }

        return null;
    }
    
    /// <summary>
    /// 移除对象
    /// </summary>
    public static void DestroyObject(this GameObject obj)
    {
        if (obj == null) return;
        Object.Destroy(obj);
    }

    /// <summary>
    /// 取所有子结点，单层的
    /// <param name="transform">结点</param>
    /// <param name="predicate">满足条件限制，可为空</param>
    /// </summary>
    public static List<Transform> GetAllChildren(this Transform transform, Func<Transform, int, bool> predicate = null)
    {
        var result = new List<Transform>();
        if (transform == null) return result;
        for (int i = 0; i < transform.childCount; i++)
        {
            var child = transform.GetChild(i);
            if (predicate == null || predicate(child, i))
                result.Add(child);
        }

        return result;
    }
    
    /// <summary>
    /// 删除所有child
    /// </summary>
    /// <param name="this"></param>
    public static void DestroyChildren(this Transform @this)
    {
        if (@this == null) return;
        var childCount = @this.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            Object.Destroy(@this.GetChild(i).gameObject);
        }
    }

    /// <summary>
    /// 删除所有child，除了指定的
    /// </summary>
    /// <param name="this"></param>
    /// <param name="except">除了这个对象</param>
    public static void DestroyChildrenExcept(this Transform @this, GameObject except)
    {
        var childCount = @this.childCount;
        for (int i = childCount - 1; i >= 0; i--)
        {
            var gameObject = @this.GetChild(i).gameObject;
            if (gameObject != except)
            {
                Object.Destroy(gameObject);
            }
        }
    }

    /// <summary>
    /// 隐藏所有child，除了指定的
    /// </summary>
    /// <param name="this"></param>
    /// <param name="except">除了这个对象</param>
    public static void HideChildrenExcept(this Transform @this, GameObject except)
    {
        if (@this == null)
            return;
        for (int i = @this.childCount - 1; i >= 0; i--)
        {
            var gameObject = @this.GetChild(i).gameObject;
            if (gameObject != except)
            {
                gameObject.SetActive(false);
            }
        }
    }

    /// <summary>
    /// 隐藏所有child
    /// </summary>
    public static void HideChildren(this Transform @this)
    {
        if (@this == null)
            return;
        for (int i = @this.childCount - 1; i >= 0; i--)
        {
            @this.GetChild(i).gameObject.SetActive(false);
        }
    }

    /// <summary>
    /// 设置所有子对象层级，不包含本身
    /// </summary>
    /// <param name="transform">父对象</param>
    /// <param name="layerName">层级名字</param>
    /// <param name="recursive">是否只设置单层子对象层级</param>
    public static void SetChildLayers(this Transform transform, string layerName, bool recursive = false)
    {
        var layer = LayerMask.NameToLayer(layerName);
        SetChildLayersHelper(transform, layer, recursive);
    }
    
    /// <summary>
    /// 设置层级，包含本身
    /// </summary>
    /// <param name="transform">设置对象</param>
    /// <param name="layerName">层级名字</param>
    /// <param name="recursive">是否设置子对象</param>
    public static void SetObjLayers(this Transform transform, string layerName, bool recursive = false)
    {
        var layer = LayerMask.NameToLayer(layerName);
        transform.gameObject.layer = layer;
        if (recursive)
            SetChildLayersHelper(transform, layer, true);
    }

    /// <summary>
    /// （递归）设置对象层级，包含所有子对象
    /// </summary>
    /// <param name="transform">设置对象</param>
    /// <param name="layer">层级数字</param>
    /// <param name="recursive">是否设置子对象</param>
    private static void SetChildLayersHelper(Transform transform, int layer, bool recursive)
    {
        foreach (Transform child in transform)
        {
            child.gameObject.layer = layer;

            if (recursive)
                SetChildLayersHelper(child, layer, true);
        }
    }
    
    /// <summary>
    /// 设置父类并设置局部坐标，缩放，角度为默认
    /// </summary>
    /// <param name="gameObject"></param>
    /// <param name="parent"></param>
    public static void SetParentAndReset(this GameObject gameObject, Transform parent = null)
    {
        if (gameObject != null)
        {
            if (parent != null)
            {
                gameObject.transform.SetParent(parent);
            }

            if (gameObject != null)
            {
                gameObject.transform.localPosition = Vector3.zero;
                gameObject.transform.localRotation = Quaternion.identity;
                gameObject.transform.localScale = Vector3.one;
            }
        }
    }

    /// <summary>
    /// 设置父对象扩展
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="parent"></param>
    public static void SetParent(this GameObject obj, Transform parent)
    {
        if(obj != null || obj.transform == null || parent == null) return;
        obj.transform.SetParent(parent);
    }    
    /// <summary>
    /// 设置父对象扩展
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="parentObj"></param>
    public static void SetParent(this GameObject obj, GameObject parentObj)
    {
        if(parentObj == null || parentObj.transform == null) return;
        obj.SetParent(parentObj.transform);
    }

    public static SampleCountDown SetCountDown(this TextMeshProUGUI text, float time, Action onComplete = null)
    {
        if (text == null) return null;
        var countDown = text.GetOrAddComponent<SampleCountDown>();
        countDown.Init(text, time, onComplete);
        
        return countDown;
    } 
    #endregion ---------- 其他扩展 ----------
    
    #region ---------- Button 扩展 ----------
    /// <summary>
    /// 安全设置onClick.AddListener
    /// </summary>
    public static void AddListener(this Button button, UnityAction action)
    {
        if (button != null)
        {
            button.onClick.RemoveAllListeners();
            if (action != null)
            {
                button.onClick.AddListener(action);
            }
            button.transition = Selectable.Transition.Animation;
            Animator animator = button.GetOrAddComponent<Animator>();
            Game.Resource.LoadAsset<RuntimeAnimatorController>(AAConst.BaseButtonController, button.GetResourceReference(),
                animatorController => { animator.runtimeAnimatorController = animatorController; });
        }
    }

    /// <summary>
    /// 安全设置button.interactable
    /// </summary>
    public static void SetInteractable(this Button button, bool interactable)
    {
        if (button != null)
        {
            button.interactable = interactable;
        }
    }
    #endregion ---------- Button 扩展 ----------
    
    #region ---------- Component扩展 ----------

    /// <summary>
    /// 获取或者添加组件
    /// </summary>
    /// <typeparam name="T">组件的类型</typeparam>
    /// <param name="transform">添加的组件对象</param>
    /// <returns>获取或者添加的组件</returns>
    public static T GetOrAddComponent<T>(this Component transform) where T : Component
    {
        if (transform == null)
        {
            return null;
        }

        T behaviour = transform.GetComponent<T>();
        if (behaviour == null)
        {
            behaviour = transform.gameObject.AddComponent<T>();
        }

        return behaviour;
    }

    /// <summary>
    /// 获取或者添加组件
    /// </summary>
    /// <typeparam name="T">组件的类型</typeparam>
    /// <param name="gameObject">添加的组件对象</param>
    /// <returns>获取或添加的组件</returns>
    public static T GetOrAddComponent<T>(this GameObject gameObject) where T : Component
    {
        if (gameObject == null)
        {
            return null;
        }

        if (!gameObject.TryGetComponent(out T behaviour))
        {
            behaviour = gameObject.AddComponent<T>();
        }

        return behaviour;
    }
    
    /// <summary>
    /// 控制显隐
    /// </summary>
    /// <param name="component"></param>
    /// <param name="isActive"></param>
    public static void SetActive(this Component component, bool isActive)
    {
        if (component != null && component.gameObject.activeSelf != isActive)
        {
            component.gameObject.SetActive(isActive);
        }
    }
    
    /// <summary>
    /// 绑定输入组件回调
    /// </summary>
    /// <param name="btn"></param>
    /// <param name="action"></param>
    public static void AddInputFiledEndListener(this InputField btn, UnityAction<string> action)
    {
        if (btn == null) return;
        btn.onSubmit.RemoveAllListeners();
        btn.onSubmit.AddListener(action);
    }
    #endregion
}