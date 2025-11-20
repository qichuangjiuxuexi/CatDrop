using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Linq;

public class CustomSnapScrollRect : MonoBehaviour, IEndDragHandler
{
    public ScrollRect scrollRect;
    public RectTransform content;
    public RectTransform[] pages; // 拖进Inspector
    public float snapTime = 0.2f;

    public int currentPage = 0;
    private float[] pageAnchors; // 每一页左侧在Content坐标系下的target锚点位置

    void Start()
    {
        if (pages == null || pages.Length == 0)
        {
            pages = content.GetComponentsInChildren<RectTransform>(true)
                .Where(r => r != content).ToArray();
        }

        CalculateAnchors();
        content.anchoredPosition = new Vector2(-pageAnchors[currentPage], content.anchoredPosition.y); //初始化默认位置
    }
    

    /// <summary>
    /// 计算左侧锚点
    /// </summary>
    private void CalculateAnchors()
    {
        pageAnchors = new float[pages.Length];
        float x = 0;
        for (var i = 0; i < pages.Length; i++)
        {
            pageAnchors[i] = x;
            x += pages[i].rect.width;
        }
    }
    
    /// <summary>
    /// 结束拖动时，检测是吸附页数
    /// </summary>
    /// <param name="eventData"></param>
    public void OnEndDrag(PointerEventData eventData)
    {
        float posX = Mathf.Abs(content.anchoredPosition.x);
        int targetIndex = 0;
        float minDis = posX;
        
        for (var i = 1; i < pageAnchors.Length; i++)
        {
            float width = Mathf.Abs(pageAnchors[i] - pageAnchors[i - 1]);
            float offsetX = currentPage <= targetIndex ? -width / 2 : width / 2;
            float dis = Mathf.Abs(pageAnchors[i] - posX);
            
            if (dis+offsetX < minDis)
            {
                minDis = dis;
                targetIndex = i;
            }
        }
        
        SnapToPage(targetIndex);
    }

    /// <summary>
    /// 内部调用吸附到某一页
    /// </summary>
    /// <param name="index"></param>
    private void SnapToPage(int index)
    {
        int targetIndex = Mathf.Clamp(index, 0, pages.Length);
        float targetPosX = -pageAnchors[targetIndex];
        StopAllCoroutines();
        StartCoroutine(MoveToPageAnima(content.anchoredPosition.x, targetPosX));
        currentPage = index;
    }

    IEnumerator MoveToPageAnima(float start, float end)
    {
        float t = 0;
        while (t < 1)
        {
            t += Time.deltaTime / snapTime;
            float x = Mathf.Lerp(start, end, Mathf.SmoothStep(0, 1, t));
            content.anchoredPosition = new Vector2(x, content.anchoredPosition.y);
            yield return null;
        }
        content.anchoredPosition = new Vector2(end, content.anchoredPosition.y);
    }

    /// <summary>
    /// 外部调用跳转到某一页
    /// </summary>
    /// <param name="index"></param>
    public void ScrollTo(int index)
    {
        SnapToPage(index);
    }
}
