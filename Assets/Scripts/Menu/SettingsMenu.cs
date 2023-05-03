using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public delegate void LoadNew(int currentDay);
    public static event LoadNew loadtheNewGame;

    private int continueDay;
    private int continueDayOver;
    private int continueTutorial;
    private float minutes;
    private float seconds;
   public void PlayNewGame()
   {
       //Start from Day 0
       PlayerPrefs.SetInt("day",0);
       PlayerPrefs.SetInt("dayCompleted",0);
       PlayerPrefs.SetInt("tutorial",1);
       PlayerPrefs.SetFloat("minutes",0);
       PlayerPrefs.SetFloat("seconds",0);
       //Event to Start a New Game
       loadtheNewGame(0);
   }
   public void ContinueGame()
   {
        DayData data = SaveSystem.LoadData();
        continueDay = data.theDay;
        continueDayOver=data.theDayOver;
        continueTutorial=data.theTutorial;
        minutes=data.theMinutes;
        seconds=data.theSeconds;

        //Continue from Day
       PlayerPrefs.SetInt("day",continueDay);
       PlayerPrefs.SetInt("dayCompleted",continueDayOver);
       PlayerPrefs.SetInt("tutorial",continueTutorial);
       PlayerPrefs.SetFloat("minutes",minutes);
       PlayerPrefs.SetFloat("seconds",seconds);
       //Event to continue Day
        loadtheNewGame(continueDay);
   }    

   public void QuitGame() 

   {
       Debug.Log("Quit!");
       Application.Quit();
   }
}
