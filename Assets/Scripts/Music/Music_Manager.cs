using UnityEngine;
using UnityEngine.Audio;

public class Music_Manager : MonoBehaviour
{
    private static Music_Manager instance;
    private AudioSource audioSource;
    private AudioClip day0;
    void Awake(){
        if(instance==null){
            instance= this;
            DontDestroyOnLoad(instance);
        }else{
            Destroy(gameObject);
        }
    }
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        day0 = Resources.Load<AudioClip>("Music/Track4-Day0");
        audioSource.loop=true;
        PlayTrack();
    }
    private void PlayTrack(){
        audioSource.clip = day0;
        audioSource.Play();
    }
    void Update()
    {
        
    }
}
