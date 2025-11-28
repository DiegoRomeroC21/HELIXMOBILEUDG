using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{

public Text CurrentScoreText;
public Text BestScoreText;

public Slider slider;

public Text actualLevel;
public Text nextLevel;


public Transform topTransform;
public Transform goalTransform;
public Transform ball;

   
    void Start()
    {
        
    }

   
    void Update()
    {
        CurrentScoreText.text = "Score: " + GameManager.singleton.currentScore;
        BestScoreText.text = "Best: " + GameManager.singleton.bestScore;
        ChangeSliderLevelAndProgress();
    }

    public void ChangeSliderLevelAndProgress()
    {
        actualLevel.text = "" + (GameManager.singleton.currentLevel + 1);
        nextLevel.text = "" + (GameManager.singleton.currentLevel + 2);

        float totalDistance = (topTransform.position.y - goalTransform.position.y);

        float distanceLeft= totalDistance - (ball.position.y - goalTransform.position.y);

        float value = (distanceLeft / totalDistance);
        slider.value = Mathf.Lerp(slider.value, value, 5f);   
    }
}
