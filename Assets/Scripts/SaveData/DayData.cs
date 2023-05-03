using UnityEngine;

[System.Serializable]
public class DayData
{
    public int theDay;
    public int theDayOver;
    public int theTutorial;
    public float theMinutes;
    public float theSeconds;

    public DayData(int day, int dayOver, int tutorial, float minutes, float seconds){
        theDay = day;
        theDayOver=dayOver;
        theTutorial=tutorial;
        theMinutes=minutes;
        theSeconds=seconds;
    }
}
