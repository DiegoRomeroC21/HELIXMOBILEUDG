using UnityEngine;

public class GameManager : MonoBehaviour
{
   
public int bestScore;
public int currentScore;

public int currentLevel = 0;

public static GameManager singleton;


    void Awake()
    {
        if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != this)
        {
            Destroy(gameObject);
        } 

        bestScore = PlayerPrefs.GetInt("HighScore"); 
    }

public void nextLevel()
    {
currentLevel ++;
FindAnyObjectByType<BallControl>().resetball();
FindAnyObjectByType<HelixControl>().LoadStage(currentLevel);


Debug.Log ("Pasamos de nivel");
    }


public void restartLevel()
    {
Debug.Log ("Reinicio");
singleton.currentScore = 0;

FindObjectsByType<BallControl>(FindObjectsSortMode.None)[0].resetball();
FindAnyObjectByType<HelixControl>().LoadStage(currentLevel);


//agregue dificultad extra al reiniciar nivel haciendo que el stage recarge aleatoriamente despues de reiniciar, asi no se sabe que deathpart va a tocar
if (singleton == null)
        {
            singleton = this;
        }
        else if (singleton != this)
        {
            Destroy(gameObject);
        } 

        bestScore = PlayerPrefs.GetInt("HighScore"); 

    }


public void addscore(int scoreToAdd)
    {
        currentScore += scoreToAdd;
        if (currentScore > bestScore)
        {
            bestScore = currentScore;
            PlayerPrefs.SetInt("HighScore", currentScore);
        }
    }




    void Update()
    {
        
    }
}
