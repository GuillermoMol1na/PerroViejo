using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint_Bed : MonoBehaviour
{
    private GameMaster  gm;
    public Collider2D bedColl;
    private PlayerMovement player;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
        player= PlayerMovement.FindObjectOfType<PlayerMovement>();
    }
    void Update(){
        if(player.baseColl.IsTouching(bedColl) && Input.GetKeyDown(KeyCode.F)){
            gm.BedMade= true;
            Debug.Log("Se ha guardado la cama HECHA");
        }
    }

}
