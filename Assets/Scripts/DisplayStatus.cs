using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DisplayStatus : MonoBehaviour
{
    Text textElement;
    [SerializeField] string buildingTrackText = "Generating Track...";
    [SerializeField] string placingSceneryText = "Placing Scenery...";
    [SerializeField] string doneText = "Ready!";
    private void Start()
    {
       textElement = GetComponent<Text>();
        Building();
        TrackStatus.trackComplete += Scenery;
        TrackStatus.sceneryPlaced += Done;
    }
    private void OnDestroy()
    {
        TrackStatus.trackComplete -= Scenery;
        TrackStatus.sceneryPlaced -= Done;
    }
    public void Building()
    {
        textElement.text = buildingTrackText;
    }
    public void Scenery()
    {
        textElement.text = placingSceneryText;
    }
    public void Done()
    {
        textElement.text = doneText;
    }
}
