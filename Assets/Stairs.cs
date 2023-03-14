
using UnityEngine;

public class Stairs : MonoBehaviour
{
    public Collider2D stairsColl;
    public Collider2D playerCol;
    private LevelLoader2 thelevelLoader;
    void Start(){
        thelevelLoader = LevelLoader2.FindObjectOfType<LevelLoader2>();
        playerCol = GameObject.FindGameObjectWithTag("Player").GetComponent<Collider2D>();
        stairsColl = GameObject.FindGameObjectWithTag("Stairs").GetComponent<Collider2D>();
    }

    void Update(){
        if(playerCol.IsTouching(stairsColl))
            thelevelLoader.LoadBedRoom();


    }
    /*void OnCollisionStay(Collision collisionInfo) {
     if (collisionInfo.gameObject.tag == "Player") {
         thelevelLoader.LoadBedRoom();
     }*/



}
