using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public delegate void LoadNew(int currentDay);
    public static event LoadNew loadtheNewGame;
    public delegate void LoadReturn();
    public static event LoadReturn loadtheReturn;

    private int continueDay;
    private int continueDayOver;
    private int continueTutorial;
    private int difficulty;
    private float minutes;
    private float seconds;
    void Start(){
        //IN case the difficulty isn't selected, this will be easy
        PlayerPrefs.SetInt("difficulty",0);
    }
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
   public void SetDifficulty(int i){
        PlayerPrefs.SetInt("difficulty",i);
   }
   public void ContinueGame()
   {
        DayData data = SaveSystem.LoadData();
        continueDay = data.theDay;
        continueDayOver=data.theDayOver;
        continueTutorial=data.theTutorial;
        difficulty=data.theDifficulty;
        minutes=data.theMinutes;
        seconds=data.theSeconds;
        if(continueDay < 3){
            //Continue from Day
            PlayerPrefs.SetInt("day",continueDay);
            PlayerPrefs.SetInt("dayCompleted",continueDayOver);
            PlayerPrefs.SetInt("tutorial",continueTutorial);
            PlayerPrefs.SetInt("difficulty",difficulty);
            PlayerPrefs.SetFloat("minutes",minutes);
            PlayerPrefs.SetFloat("seconds",seconds);
            //Event to continue Day
             loadtheNewGame(continueDay);
        }
        else{
            //Thaks for playing
            loadtheReturn();
        }
        
   }    

   public void QuitGame() 

   {
       Debug.Log("Quit!");
       Application.Quit();
   }
}
