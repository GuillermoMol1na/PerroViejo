using UnityEngine;
using System;
using UnityEngine.Audio;
using System.Collections;
using UnityEngine.SceneManagement;

public class Music_Manager : MonoBehaviour
{
    private static Music_Manager instance;
    private object[] loadedMusic;
    public Sound[] sounds;
    private int lastSceneIndex;
    private int newSceneIndex;
    private AudioClip[] theclips;
    //private AudioClip day0;
    void Awake(){
        if(instance==null){
            instance= this;
            DontDestroyOnLoad(instance);
        }else{
            Destroy(gameObject);
        }
        loadedMusic = Resources.LoadAll ("Music",typeof(AudioClip)) ;
        theclips = new AudioClip[loadedMusic.Length];
        sounds = new Sound[loadedMusic.Length];
        loadedMusic.CopyTo (theclips,0);
        for(int i=0; i<loadedMusic.Length;i++){
            sounds[i] = new Sound();
        }
        //Add AudioSource to each Sound 
        foreach(Sound s in sounds){
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.name = s.name;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }
        //Assign the clips to the Sound obbjects
        for(int i=0; i<loadedMusic.Length;i++){
            sounds[i].source.clip = theclips[i];
            sounds[i].clip = theclips[i];
            sounds[i].name = theclips[i].name;
        }
    }
    void Start()
    {
        lastSceneIndex =SceneManager.GetActiveScene().buildIndex;
        Play("Track0_MainMenu",true);
    }
    public void Play(string name, bool loop){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null){
            Debug.LogError("NO SE ENCONTRÓ LA PISTA DE AUDIO");
            return;
        }
        s.source.loop = loop;
        s.source.Play();
    }
    public void StopMain(){
                switch(PlayerPrefs.GetInt("day")){
            case 0:
                SlowStop("Track4-Day0");
            break;
            case 1:
                SlowStop("Track4-Day1");
            break;
            case 2:
                SlowStop("Track4-Day2");
            break;
        }
    }
    public void StartMain(){
        switch(PlayerPrefs.GetInt("day")){
            case 0:
                Play("Track4-Day0",true);
            break;
            case 1:
                Play("Track4-Day1",true);
            break;
            case 2:
                Play("Track4-Day2",true);
            break;
        }
    }
    public IEnumerator FadeOut(AudioSource source){
        float startVolume = source.volume;
        while (source.volume > 0) {
            source.volume -= startVolume * Time.deltaTime / 0.5f;
            yield return null;
        }
        source.Stop ();
        source.volume = startVolume;
    }
    public void SlowStop(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
            return;
        StartCoroutine(FadeOut(s.source));
    }
    public void Stop(string name){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
            return;
        s.source.Stop();
    }
    public void Volume(string name, float vol){
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
            return;
        s.source.volume = vol;
    }
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnLevelFinishedLoading;
    }     
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnLevelFinishedLoading;
    }
    void OnLevelFinishedLoading(Scene scene, LoadSceneMode mode)
    {
        newSceneIndex = scene.buildIndex;
        if(newSceneIndex * lastSceneIndex != 2 && newSceneIndex==2){
            StartMain();
        }
        lastSceneIndex = newSceneIndex;
    }

}
