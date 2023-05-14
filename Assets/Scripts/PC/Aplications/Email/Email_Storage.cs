using UnityEngine;

public class Email_Storage
{ 
  public string[,] dayZero = { {"Tutorial","Hijo","Gladys","Gerardo", "Promociones","Seguro", "Mejores aplicaciones"},
                               {"Recomendaciones", "Encontré esto", "Musica","Ya te tengo", "MIRA ESTO","Documentos", "DESCARGA AQUÍ"},
                               {"Recuerda, no debes abrir links sospechosos enviados por personas que no conozcas. El día de hoy solo debes abrir tus emails sin hacer click en nada feo. ¿Sencillo verdad?",
                                "Hola Pa, encontré una vieja foto entre mis archivos, la adjunto en el link.", "Hola erwin, espero que te encuentres bien, estoy enterada acerca de la mudanza de tu hijo. Las cosas van a mejorar, hay formas de lidiar con la soledad, como la música. Hablando de eso, encontré un nuevo sitio para descargar música. ¿Podrías descargar algunas canciones para mí mañana?","Tal vez te hayas salido con la tuya hace algunos años, pero ya se termino tu suerte jaja."+System.Environment.NewLine+System.Environment.NewLine+"Peón a G7", "Descarga la última sensación","Buenas tardes Don Erwin, le escribo para que pueda ir completando los pasos para su jubilación. sabemos que una decisión no muy fácil, por lo que le pedimos únicamente una revisión previa a su firma, muchas gracias.","haz click en el enlace"},
                               {"", "unaviejafoto.jpg", "","ChessWorldScreenshot.png","www.miraesto.com","form1.doc","http://buenasfotos.com"} };

  public string[,] dayOne = { {"Tutorial","Gladys","Gerardos"},
                                {"Recomendaciones", "Descargar Canciones", "JAJA"},
                               {"Recuerda no hacer clic en enlaces muy vistosos o insistentes o  que contengan errores de ortografía. Abre la aplicación de Internet para activar la actividad del día.", "Muchas gracias por descargar las canciones Erwin, no soy buena con éstas cosas, por lo que aprecio muchísimo tu ayuda. Por cierto ¿Cómo va tu muchacho? Espero que se encuentre muy bien. Besos y abrazos, listaré las canciones a descargar: "+ System.Environment.NewLine+System.Environment.NewLine+
                                "hamilton008796465746757394234532.mp3"+ System.Environment.NewLine+
                               "tomjones634268543977413253633245.mp3"+ System.Environment.NewLine+
                               "julioiglesias8521647932554123974.mp3", "De seguro te sigues lamiendo las heridas ¿Eh? No te sientas mal, tan solo estuviste extendiendo tu fracaso por... ¿Digamos unos 3 meses?"+ System.Environment.NewLine+"PD: Acmoda el tablero para la siguiente"},
                               {"", "", ""}  };
  public string[,] dayTwo = { {"Tutorial","VIGO",},
                              {"Llamadas", "Inf Usuario"},
                              {"Para contestar llamadas debes oprimir la tecla [F], presta atención a los datos que te da fuentes confiables.", "02/05/23"+ System.Environment.NewLine+"Le entregamos su factura del mes mientras que notificamos a todos nuestros usuarios que la base de datos se borró requieriendo algunas confirmaciones. Un representante de VIGO le llamará más tarde hoy."+ System.Environment.NewLine+" Gracias por la comprensión.",},
                              {"", "factura_vigo.jpg"}   };
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
