using UnityEngine;
using TMPro;
public class Timer_2 : MonoBehaviour
{
    private GameObject background;
    private Music_Manager mm;
    private float timeValue;
    private bool isActive;
    public TMP_Text timerText;
    private float refresh;
    private float minutes;
    private float seconds;
    private Difficulty_Minigame2 difficulty = new Difficulty_Minigame2();
    public delegate void GameOver();
    public static event GameOver goToGameOver;
    void Start(){
        mm = GameObject.FindGameObjectWithTag("Audio_Manager").GetComponent<Music_Manager>();
        timerText.transform.SetAsLastSibling();
        background = this.transform.GetChild(0).gameObject;
        DeactivateTimer();

        //Get the DIFFICULTY OF THE DAY
        switch(PlayerPrefs.GetInt("difficulty")){
            case 0:
                timeValue = difficulty.EasyTime();
            break;
            case 1:
                timeValue = difficulty.MediumTime();
            break;
            case 2:
                timeValue = difficulty.HardTime();
            break;
        }
        refresh = timeValue;
    }
    void Update()
    {
        if(isActive){
            if(timeValue>0){
                timeValue -= Time.deltaTime;
            }else{
                timeValue = 0;
            }
            DisplayTime(timeValue);
        }
    }
    void DisplayTime(float timeToDisplay){
        if(timeToDisplay < 0){
            timeToDisplay=0;
            //Time Over->Game Over
            goToGameOver();
            //Restart time
            timeValue=refresh;
        }
        if(timeToDisplay < 11){
            timerText.color = new Color32(255,0,0,255);
        }
        minutes = Mathf.FloorToInt(timeToDisplay / 60);
        seconds = Mathf.FloorToInt(timeToDisplay % 60);
        //Save value for results
        PlayerPrefs.SetFloat("minutes",refresh - minutes);
        PlayerPrefs.SetFloat("seconds",refresh - seconds);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
    public void ActivateTimer(){
        mm.Play("Track12-Minigame2",true);
        isActive = true;
        //this.gameObject.SetActive(isActive);
        background.SetActive(isActive);
        timerText.enabled = isActive;
    }
    public void DeactivateTimer(){
        mm.Stop("Track12-Minigame2");
        //Save value of results
        PlayerPrefs.SetFloat("minutes",minutes);
        PlayerPrefs.SetFloat("seconds",seconds);
        isActive = false;
        background.SetActive(isActive);
        timerText.enabled = isActive;
    }
    public bool GetActive(){
        return isActive;
    }
}
