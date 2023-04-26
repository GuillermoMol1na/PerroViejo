using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
    public delegate void LoadNew();
    public static event LoadNew loadtheNewGame;
   public void PlayNewGame()
   {
    //Start from Day 0
       PlayerPrefs.SetInt("day",0);
       PlayerPrefs.SetInt("dayCompleted",0);
       PlayerPrefs.SetInt("tutorial",1);
       PlayerPrefs.SetInt("minibar",1);
       PlayerPrefs.SetInt("bookshelf",1);
       PlayerPrefs.SetInt("pc",1);
       //Event to Start a New Game
       loadtheNewGame();
   }    

   public void QuitGame() 

   {
       Debug.Log("Quit!");
       Application.Quit();
   }
}
