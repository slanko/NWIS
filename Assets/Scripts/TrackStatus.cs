using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TrackStatus
{
    public delegate void statusEvent();
    public static statusEvent trackComplete;
    public static statusEvent sceneryPlaced;
}
