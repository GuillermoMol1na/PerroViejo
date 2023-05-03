using UnityEngine;
using System.Linq;

public  class Dialogue_Storage
{
private System.Random rand;
    public string[,] scamCalls = {
                                    {"¿Qué tal? Como representante de VIGO, deseo brindarle el mejor servicio a nuestro usuario C3842JGR, el señor Erwin Gustavo con paquete platino", "¿Es usted verdad? Si se trata de usted, por favor deme su contraseña para restablecer su cuenta en el sistema."},
                                    {"Muy buenas tardes señor Ritchzen, le habla un representante de VIGO, como sabrá, nuestra base de datos ha sido comprometida, complicando en demasía el servicio que nosotros proporcionamos a usuarios del paquete plata como usted,", "sobre todo en zonas cercanas a la calle Ecuador, donde sabemos que el servicio puede ser deficiente a ratos. Permítame su contraseña y nro de tarjeta y estos problemas se solucionarán en breve."},
                                    {"Saludos don Eduardo, le habla un representante de VIGO, sabemos por lo que usted debe estar pasando", "por lo que le pido que me proporcione su contraseña cuanto antes para solucionar este contratiempo."}
                                 };
    public string[,] realCall = {
                                    {"Hola, la presente es la llamada verdadera", "¿Qué me dices?"}
                                };
    public string[] ScamConv(int index){
        int lenght = scamCalls.GetLength(1);
        string[] theArray = new string[lenght];
        for(int i=0;i<lenght;i++){
            theArray[i]= scamCalls[index,i];
        }
        return theArray;
    }
    public string[] RealCall(){
        int lenght = realCall.GetLength(1);
        string[] theArray = new string[lenght];
        for(int i=0;i<lenght;i++){
            theArray[i]= realCall[0,i];
        }
        return theArray;
    }
    public int[] RandomOrder(){
        rand = new System.Random();
        //int length = rand.Next(0,8);
        int lenght = scamCalls.GetLength(0);
        int[] thefill = new int[lenght];
        for(int i=0;i<lenght;i++){
            thefill[i]=i;
        }
        thefill = thefill.OrderBy(x=>rand.Next(0,lenght)).ToArray();
        return thefill;
    }
    public int NumberofScams(){
        return scamCalls.GetLength(0);
    }
}
