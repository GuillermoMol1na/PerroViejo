using UnityEngine;

public class Email_Storage
{ 
  public string[,] dayZero = { {"Tutorial","Hijo","Gladys","Gerardo", "Estafa 1","Seguro", "Estafa 2"},
                               {"Recomendaciones", "Saber de ti", "Musica","Ya te tengo", "MIRA ESTO","Documentos", "DESCARGA AQUÍ"},
                               {"Debes...", "Hola Pa, encontré una vieja foto entre mis archivos, la adjunto en el link.", "Encontré un nuevo sitio para descargar música","Peón a G7", "Descarga la última sensación","Buenas tardes Don Erwin, le escribo para que pueda ir completando los pasos para su jubilación. sabesmos que una decisión no muy fácil, por lo que le pedimos únicamente una revisión previa a su firma, muchas gracias.","haz click en el enlace"},
                               {"", "unaviejafoto.jpg", "","ChessWorldScreenshot.png","www.6969696.com","form1.doc","www.estafaobvia.com"} };

  public string[,] dayOne = { {"Contacto1","Contacto2","Gladys", "Contacto4", "Contacto5"},
                                {"Subject1", "Descargar Canciones por favor", "Subject3", "Subject4", "Subjects5"},
                               {"Email1", "hamilton008796465746757394234532.mp3"+ System.Environment.NewLine+
                               "tomjones634268543977413253633245.mp3"+ System.Environment.NewLine+
                               "julioiglesias8521647932554123974.mp3", "Email3","Email4","Email5"},
                               {"", "", "","",""}   };
  public string[,] dayTwo = { {"Contacto1","Contacto2","Contacto3", "Contacto4", "Contacto5"},
                                {"Subject1", "Subject2", "Subject3", "Subject4", "Subjects5"},
                               {"Email1", "Email2", "Email3","Email4","Email5"}  };
  public int getDay0Length(){
    return dayZero.GetLength(1);
  }
  public int getDay1Length(){
    return dayOne.GetLength(1);
  }
  public int getDay2Length(){
    return dayTwo.GetLength(1);
  }
}
