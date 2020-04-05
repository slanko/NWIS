using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PressButtonToJoin : MonoBehaviour
{
    [SerializeField] int playerNum;
    [SerializeField] string joinButton;
    [SerializeField] string leaveButton;
    public UnityEvent join;
    public UnityEvent leave;
    bool joined = false;
    private void Update()
    {
        if (Input.GetButtonDown(joinButton)&&!joined)
        {
            joined = true;
            join.Invoke();
            PlayerData.players.Add(playerNum);
            PlayerData.playerCount++;
        }
        if (Input.GetButtonDown(leaveButton)&&joined)
        {
            joined = false;
            leave.Invoke();
            PlayerData.players.Remove(playerNum);
            PlayerData.playerCount--;
        }
    }
}
