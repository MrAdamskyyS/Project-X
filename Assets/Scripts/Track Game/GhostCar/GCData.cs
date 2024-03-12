using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GCData
{
    [SerializeField]
    List<GCDataList> ghostCarRecorderList = new List<GCDataList>();

    public void AddDataItem(GCDataList gcDataList)
    {
        ghostCarRecorderList.Add(gcDataList);
    }

    public List<GCDataList> GetDataList()
    {
        return ghostCarRecorderList;
    }
}
