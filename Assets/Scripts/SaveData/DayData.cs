using UnityEngine;

[System.Serializable]
public class DayData
{
    public int theDay;
    public bool refreshLiving;

    public DayData(int day, bool refre){
        theDay = day;
        refreshLiving = refre;
    }
}
