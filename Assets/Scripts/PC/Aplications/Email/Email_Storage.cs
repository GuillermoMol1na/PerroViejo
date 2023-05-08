using UnityEngine;

public class Email_Storage
{ 
  public string[,] dayZero = { {"Tutorial","Hijo","Gladys","Gerardo", "Estafa 1","Seguro", "Estafa 2"},
                               {"Recomendaciones", "Saber de ti", "Musica","Ya te tengo", "MIRA ESTO","Documentos", "DESCARGA AQUÍ"},
                               {"Recuerda, no debes abrir links sospechosos enviados por personas que no conozcas. El día de hoy solo debes abrir tus emails sin hacer click en nada feo. ¿Sencillo verdad?",
                                "Hola Pa, encontré una vieja foto entre mis archivos, la adjunto en el link.", "Encontré un nuevo sitio para descargar música","Peón a G7", "Descarga la última sensación","Buenas tardes Don Erwin, le escribo para que pueda ir completando los pasos para su jubilación. sabesmos que una decisión no muy fácil, por lo que le pedimos únicamente una revisión previa a su firma, muchas gracias.","haz click en el enlace"},
                               {"", "unaviejafoto.jpg", "","ChessWorldScreenshot.png","www.miraesto.com","form1.doc","http://buenasfotos.com"} };

  public string[,] dayOne = { {"Contacto1","Contacto2","Gladys", "Contacto4", "Contacto5"},
                                {"Subject1", "Descargar Canciones por favor", "Subject3", "Subject4", "Subjects5"},
                               {"Email1", "Muchas gracias por descargar las canciones Erwin, no soy buena con éstas cosas, por lo que aprecio muchísimo tu ayuda. Por cierto ¿Cómo va tu muchacho? Espero que se encuentre muy bien. Besos y abrazos, listaré las canciones a descargar: "+ System.Environment.NewLine+
                                "hamilton008796465746757394234532.mp3"+ System.Environment.NewLine+
                               "tomjones634268543977413253633245.mp3"+ System.Environment.NewLine+
                               "julioiglesias8521647932554123974.mp3", "Email3","Email4","Email5"},
                               {"", "", "","",""}   };
  public string[,] dayTwo = { {"Contacto1","VIGO","Contacto3", "Contacto4", "Contacto5"},
                                {"Subject1", "Inf Usuario", "Subject3", "Subject4", "Subjects5"},
                               {"Email1", "02/05/23"+ System.Environment.NewLine+"Le entregamos su factura del mes mientras que notificamos a todos nuestros usuarios que la base de datos se borró requieriendo algunas confirmaciones. Un representante de VIGO le llamará más tarde hoy."+ System.Environment.NewLine+" Gracias por la comprensión.",
                                " Algo","Email4","Email5"},
                               {"", "factura_vigo.jpg", "","",""}   };
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
