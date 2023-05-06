using UnityEngine;

[System.Serializable]
public class DayData
{
    public int theDay;
    public int theDayOver;
    public int theTutorial;
    public int theDifficulty;
    public float theMinutes;
    public float theSeconds;

    public DayData(int day, int dayOver, int tutorial,int difficulty, float minutes, float seconds){
        theDay = day;
        theDayOver=dayOver;
        theTutorial=tutorial;
        theDifficulty=difficulty;
        theMinutes=minutes;
        theSeconds=seconds;
    }
}
