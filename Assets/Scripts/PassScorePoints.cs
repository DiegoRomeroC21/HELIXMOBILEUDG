using UnityEngine;

public class PassScorePoints : MonoBehaviour
{
    
private void OnTriggerEnter(Collider other)
    {
        GameManager.singleton.addscore(1);
        FindAnyObjectByType<BallControl>().perfectPass++;
    }

}
