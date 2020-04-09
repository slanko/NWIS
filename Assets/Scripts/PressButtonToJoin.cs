using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PressButtonToJoin : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] string joinButton;
    [SerializeField] string leaveButton;
    public UnityEvent join;
    public UnityEvent leave;
    bool joined = false;
    private void Start()
    {
        PlayerData.players.Clear();
    }
    private void Update()
    {
        if (Input.GetButtonDown(joinButton)&&!joined)
        {
            joined = true;
            join.Invoke();
            PlayerData.players.Add(player);
        }
        if (Input.GetButtonDown(leaveButton)&&joined)
        {
            joined = false;
            leave.Invoke();
            PlayerData.players.Remove(player);
        }
    }
}
