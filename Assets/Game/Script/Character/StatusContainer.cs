using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

using Prototype.Datas;

namespace Prototype.Characters
{
    public class StatusContainer : MonoBehaviour
    {
        public List<StatusData> statusDataList = new List<StatusData>();
        [SerializeField] private float currentTimeTick;
        [SerializeField] private float timeTick = 1f;

        private void Update()
        {
            UpdateTimeTick();
        }

        public void ApplyStatusData(List<StatusData> statusDatas)
        {
            foreach (StatusData s in statusDatas)
            {
                ApplyStatusData(s);
            }
        }

        public int ApplyStatusData(StatusData statusData)
        {
            var statusClone = statusData.Clone();
            if (statusData.ownerCharacter == null)
            {
                statusClone.ownerCharacter = GetComponent<Character>();
            }

            for (int i = 0; i < statusDataList.Count; i++)
            {
                StatusData s = statusDataList[i];
                s.OnAddStatus(statusClone);
            }

            int index = statusDataList.FindIndex(o => o.Equals(statusClone));
            if (index >= 0)
            {
                statusDataList[index].Add(statusClone);
                return statusClone.StackAmount;
            }

            statusDataList.Add(statusClone);

            return statusClone.StackAmount;
        }

        void UpdateTimeTick()
        {
            if (currentTimeTick < timeTick)
            {
                currentTimeTick += Time.deltaTime;
                return;
            }

            for (int i = 0; i < statusDataList.Count; i++)
            {
                StatusData statusData = statusDataList[i];
                statusData.OnSecondTick();
            }

            statusDataList = statusDataList.Where(x => x.Duration >= 0).ToList();
            currentTimeTick = 0f;
        }
    }
}

