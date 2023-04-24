using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Welcome_Tutorial : MonoBehaviour
{
    private GameMaster  gm;
    private MessageTrigger msgTrigg;
    private string[] welcomeday0 = {"Bienvenido al juego, presiona [SPACE] para continuar.",
                                    "Lo primero de hoy es hacer la cama, una vez finalizado aquello podrás bajar a la sala.",
                                    "Presiona la tecla [F] en tu teclado para interactuar con tu entorno.",
                                    "No te olvides beber algo y leer un poco antes de encender tu PC.",
                                    "Buena suerte."};
    private string[] welcomeday1 = {"El día de ayer fue informativo, pero el día de hoy las cosas no serán tan sencillas.",
                                    "erwin debe seguir su rutina, pero al finalizar debe revisar su correo.",
                                    "Su amiga Gladys le pidió un favor ayer de todas formas.",
                                    "Buena suerte."};
    private string[] welcomeday2 = {"El día de hoy debes hacer...",
                                    "Al parecer nada.",
                                    "No hay nada claro de momento, por lo que Erwin debe seguir su rutina como siempre.",
                                    "Buena suerte."};
    private Messages welcTut = new Messages();
    void Start()
    {
        Invoke("ShowMeTutorial",2f);
    }
    private void ShowMeTutorial(){
        msgTrigg = GameObject.FindGameObjectWithTag("Trgg_Messag").GetComponent<MessageTrigger>();
        switch(PlayerPrefs.GetInt("day")){
        case 0:
        welcTut.Include(welcomeday0);
        break;
        case 1:
        welcTut.Include(welcomeday1);
        break;
        case 2:
        welcTut.Include(welcomeday2);
        break;
        }
        msgTrigg.UsetheMessages(welcTut);
        msgTrigg.TriggerMessage();
    }
}
