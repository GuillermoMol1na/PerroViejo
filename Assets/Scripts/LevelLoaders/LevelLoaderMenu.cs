using System.Collections;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LevelLoaderMenu : MonoBehaviour
{
    public TMP_Text titleText;
    public Animator transition;
    private Music_Manager mm;

    private string tutorial= "¡Hola! Bienvenido, Déjame presentarte a Erwin Ritchzen, él es un señor que vive tranquilo en su retiro, él tiene 7 décadas de vida, pero no dejes que su edad te confunda él está sorprendente bien para su edad con mucha energía para hacer actividades y tomar retos, Erwin tiene un hijo de 30 años que ya no vive él, él es ingeniero informático a pesar de que ya no vive con su papa aún mantiene una muy buena comunicación, Estos últimos días Erwin estuvo muy preocupado conversando con su hijo acerca de los peligros que ancianos como él y sus amigos tienen en la internet, y como si no fuera suficiente con el tema de la pandemia que se vivió todo se está volviendo digital obligando a los de la generación de Erwin a tener que entrar a la era digital. Las cosas no pintan a ser tan fáciles para nuestro amigo, los estafadores de internet están al acecho de personas como Erwin, esperando a encontrar a algún incauto y aprovecharse de su falta de conocimiento sobre este mundo tan gigante que es la internet. Pero Erwin decidió no me quedare con los brazos cruzados, él va a defenderse y a no caer en la trampa de los estafadores, tendrá que aprender mucha información, pero por fortuna su hijo dejo alguno de sus libros de la universidad, entonces podemos decir que Erwin tiene todo el tiempo del mundo y unas ganas de superar este reto que se propuso así que comencemos con esta aventura…"+ System.Environment.NewLine+" [PRESIONA CUALQUIER TECLA PARA CONTINUAR]";

    void Start(){
        titleText.enabled=false;
        mm = GameObject.FindGameObjectWithTag("Audio_Manager").GetComponent<Music_Manager>();
    }

    public void LoadGame(int currentDay){
        
        if(currentDay==0){
            titleText.text = tutorial;
            titleText.fontSize = 16;
            titleText.alignment = TextAlignmentOptions.TopJustified;
            StartCoroutine(TransitionTutorial(SceneManager.GetActiveScene().buildIndex + 1, currentDay));
        }else{
            titleText.text="DIA "+currentDay;
            titleText.fontSize = 50;
            titleText.alignment = TextAlignmentOptions.Center;
            StartCoroutine(Transition(SceneManager.GetActiveScene().buildIndex + 1));
        }
    }

    public void ReturnToStart(){
        titleText.text="GRACIAS POR JUGAR";
        StartCoroutine(Transition(SceneManager.GetActiveScene().buildIndex));
        mm.StartMain();
    }
    IEnumerator Transition(int levelIndex){
        transition.SetTrigger("Start");
        titleText.enabled=true;
        mm.SlowStop("Track0_MainMenu");
        yield return new WaitForSeconds(2);
        mm.StartMain();
        SceneManager.LoadScene(levelIndex);
    }
    IEnumerator TransitionTutorial(int levelIndex, int currentDay){
        transition.SetTrigger("Start");
        titleText.enabled=true;
        yield return new WaitForSeconds(1);
        transition.ResetTrigger("Start");
        yield return new WaitUntil(()=> Input.anyKey );
        transition.SetTrigger("Start");
        titleText.text="DIA "+currentDay;
        titleText.fontSize = 50;
        titleText.alignment = TextAlignmentOptions.Center;
        mm.SlowStop("Track0_MainMenu");
        yield return new WaitForSeconds(2);
        mm.StartMain();
        SceneManager.LoadScene(levelIndex);
    }
    void OnEnable(){
        SettingsMenu.loadtheNewGame += LoadGame;
        SettingsMenu.loadtheReturn += ReturnToStart;
    }
    void OnDisable(){
        SettingsMenu.loadtheNewGame -= LoadGame;
        SettingsMenu.loadtheReturn -= ReturnToStart;
    }

}
