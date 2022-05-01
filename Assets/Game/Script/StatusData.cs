using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class StatusData
{
    public Status status;
    public int duration;
    public int stackAmount;

    [HideInInspector] public Character ownerCharacter;

    public StatusData(Status _status, int _duration = 0, int _stackAmount = 0)
    {
        status = _status;
        duration = _duration;
        stackAmount = _stackAmount;
    }

    public void Add(StatusData _statusData)
    {
        Status _status = _statusData.status;

        duration += _statusData.duration;
        stackAmount += _statusData.stackAmount;

        duration = _status.isDurationOverride ? _statusData.duration : duration;
        stackAmount = _status.isStackOverride ? _statusData.stackAmount : stackAmount;
    }

    public StatusData Clone()
    {
        return (StatusData)this.MemberwiseClone();
    }
}
