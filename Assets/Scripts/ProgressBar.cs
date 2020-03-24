using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ProgressBar : MonoBehaviour
{
    RectTransform trans;
    Image img;
    [SerializeField] Color finishedColor;
    private void Start()
    {
        trans = GetComponent<RectTransform>();
        img = GetComponent<Image>();
        TrackStatus.sceneryPlaced += Done;
    }
    private void OnDestroy()
    {
        TrackStatus.sceneryPlaced -= Done;
    }
    void Update()
    {
        float totalProgress = (TrackGenerator.progress / 3) + (SceneryPlacer.progress * (2f / 3f));
        SetWidth(totalProgress * Screen.width);
    }
    void SetWidth(float width)
    {
        Vector2 size = trans.sizeDelta;
        size.x = width;
        trans.sizeDelta = size;
    }
    void Done()
    {
        SetWidth(Screen.width);
        img.color = finishedColor;
        this.enabled = false;
    }
}
