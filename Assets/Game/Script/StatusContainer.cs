using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class StatusContainer : MonoBehaviour
{
    public List<StatusData> statusDataList = new List<StatusData>();
    [SerializeField] private float currentTimeTick;
    [SerializeField] private float timeTick = 1f;

    private void Update()
    {
        if (currentTimeTick < timeTick)
        {
            currentTimeTick += Time.deltaTime;
            return;
        }

        for (int i = 0; i < statusDataList.Count; i++)
        {
            StatusData statusData = statusDataList[i];
            statusData.status.OnSecondTick(GetComponent<Character>(), statusData);
        }

        statusDataList = statusDataList.Where(x => x.duration >= 0).ToList();
        currentTimeTick = 0f;
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
            s.status.OnAddStatus(s, GetComponent<Character>(), statusClone);
        }

        int index = statusDataList.FindIndex(o => o.status == statusClone.status);
        if (index >= 0)
        {
            statusDataList[index].Add(statusClone);
            return statusClone.stackAmount;
        }

        statusDataList.Add(statusClone);


        return statusClone.stackAmount;
    }
}
