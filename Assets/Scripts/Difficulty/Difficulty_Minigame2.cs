using System.Linq;
public class Difficulty_Minigame2
{
    private float theTimeEasy= 420;
    private float theTimeMedium = 300;
    private float theTimeHard = 180;
    private System.Random rand;
    
    public float EasyTime(){
        return theTimeEasy;
    }
    public float MediumTime(){
        return theTimeMedium;
    }
    public float HardTime(){
        return theTimeHard;
    }
    public int numberOfCallsEasy(){
        rand = new System.Random();
        return rand.Next(3,5);
    }
    public int numberOfCallsMedium(){
        rand = new System.Random();
        return rand.Next(5,9);
    }
    public int numberOfCallsHard(){
        rand = new System.Random();
        return rand.Next(10,13);
    }
}
