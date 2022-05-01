using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Prototype.Characters;

namespace Prototype.Datas
{
    [System.Serializable]
    public class StatusData
    {
        [SerializeField] private Status status;
        [SerializeField] private int duration;
        [SerializeField] private int stackAmount;

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

        public void OnAddStatus(StatusData applyStatusData)
        {
            status.OnAddStatus(this, ownerCharacter, applyStatusData);
        }

        public void OnSecondTick()
        {
            status.OnSecondTick(ownerCharacter, this);
            duration -= 1;
        }

        public StatusData Clone()
        {
            return (StatusData)this.MemberwiseClone();
        }

        public bool Equals(StatusData statusDataToCompare)
        {
            return Status == statusDataToCompare.Status;
        }

        public Status Status
        {
            get { return status; }
        }

        public int Duration
        {
            get { return duration; }
        }

        public int StackAmount
        {
            get { return stackAmount; }
        }
    }
}

