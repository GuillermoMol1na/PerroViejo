using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
   public void PlayGame()
   
   {
    //Start from Day 0
       PlayerPrefs.SetInt("day",0);
       PlayerPrefs.SetInt("dayCompleted",0);
       PlayerPrefs.SetInt("tutorial",1);
       PlayerPrefs.SetInt("minibar",1);
       PlayerPrefs.SetInt("bookshelf",1);
       PlayerPrefs.SetInt("pc",1);
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }    

   public void QuitGame() 

   {
       Debug.Log("Quit!");
       Application.Quit();
   }
}
