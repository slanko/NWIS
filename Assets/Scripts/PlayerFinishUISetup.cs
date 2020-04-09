using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFinishUISetup : MonoBehaviour
{
    [SerializeField] PositionData[] positions = new PositionData[4];
    [SerializeField] FinishScreen[] screens;
    [SerializeField] GameObject finalScreen;

    private void Start()
    {
        RaceStateEvents.playerFinish += Finish;
    }
    private void OnDestroy()
    {
        RaceStateEvents.playerFinish -= Finish;
    }
    public void Finish(Player player)
    {
        screens[player.number - 1].gameObject.SetActive(true);
        screens[player.number - 1].SetImage(positions[player.position-1]);
        if(FinishLine.playersFinished== PlayerData.players.Count)
        {
            finalScreen.SetActive(true);
        }
    }
}
