using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using CodeMonkey.Utils;

public class SpeedGraph : MonoBehaviour
{
    [SerializeField] private Sprite circleSprite;
    private RectTransform graphContainer;

    private void Awake()
    {
        graphContainer = transform.Find("graphContainer").GetComponent<RectTransform>();
        ShowGraph(CollectLap.Instance.speeds);
    }

    private GameObject CreatePoint(Vector2 anchoredPositon)
    {
        GameObject gameObject = new GameObject("point", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
            gameObject.GetComponent<Image>().sprite = circleSprite;
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = anchoredPositon;
        rectTransform.sizeDelta = new Vector2(5, 5);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        return gameObject;
    }

    private void ShowGraph(List<float> speeds)
    {
        float graphHeight = graphContainer.sizeDelta.y;
        float yMaximum = 280f;
        float xSize = 3f;

        GameObject lastPointGameObject = null;

        for (int i = 0; i < speeds.Count; i++)
        {
            float xPos = i * xSize;
            float yPos = (speeds[i] / yMaximum) * graphHeight;
            GameObject pointGameObject = CreatePoint(new Vector2(xPos, yPos));
            if(lastPointGameObject != null)
            {
                PointConnector(lastPointGameObject.GetComponent<RectTransform>().anchoredPosition, pointGameObject.GetComponent<RectTransform>().anchoredPosition);
            }
            lastPointGameObject = pointGameObject;
        }
    }

    private void PointConnector(Vector2 pointPosA, Vector2 pointPosB)
    {
        GameObject gameObject = new GameObject("pointConnection", typeof(Image));
        gameObject.transform.SetParent(graphContainer, false);
        gameObject.GetComponent<Image>().color = new Color(1,1,1,1f);
        RectTransform rectTransform = gameObject.GetComponent<RectTransform>();
        Vector2 dir = (pointPosB - pointPosA).normalized;
        float distance = Vector2.Distance(pointPosA, pointPosB);
        rectTransform.anchorMin = new Vector2(0, 0);
        rectTransform.anchorMax = new Vector2(0, 0);
        rectTransform.sizeDelta = new Vector2(distance, 3f);
        rectTransform.anchoredPosition = pointPosA + dir * distance * .5f;
        rectTransform.localEulerAngles = new Vector3(0, 0, UtilsClass.GetAngleFromVectorFloat(dir));
    }
}
