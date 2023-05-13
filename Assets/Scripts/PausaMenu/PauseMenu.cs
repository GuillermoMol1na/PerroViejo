using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
  public Slider audioSlider;
    
    public AudioMixer audioMixer;
    private Music_Manager mm;

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
   
   void Start(){
      mm = GameObject.FindGameObjectWithTag("Audio_Manager").GetComponent<Music_Manager>();
      audioSlider.value = mm.volRecord;
      Debug.Log("Valor RECIBIDO: " + audioSlider.value);
   }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GameIsPaused)
            {
                Resume();
            } else 
            {
                Pause();
            }
        }
    }

    public void Resume ()
    {
      pauseMenuUI.SetActive(false);
      Time.timeScale = 1f;
      GameIsPaused = false;
    }
    void Pause()
    {
      pauseMenuUI.SetActive(true);
      Time.timeScale = 0f;
      GameIsPaused = true;
    }

    public void LoadMenu()
    {
      SceneManager.LoadScene("Menu");
    }
    public void QuitGame()
    {
      Application.Quit();
    }

    public void SetVolume(float volume)
    {
      audioMixer.SetFloat("volume", volume);
      mm.volRecord = volume;
    }
}
