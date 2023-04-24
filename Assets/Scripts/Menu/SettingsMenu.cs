using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsMenu : MonoBehaviour
{
   public void PlayGame()
   
   {
    //Start from Day 0
       PlayerPrefs.SetInt("day",0);
       SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
   }    

   public void QuitGame() 

   {
       Debug.Log("Quit!");
       Application.Quit();
   }
}
