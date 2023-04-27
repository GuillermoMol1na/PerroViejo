using UnityEngine;

[System.Serializable]
public class DayData
{
    public int theDay;
    public int theDayOver;
    public int theTutorial;

    public DayData(int day, int dayOver, int tutorial){
        theDay = day;
        theDayOver=dayOver;
        theTutorial=tutorial;
    }
}
