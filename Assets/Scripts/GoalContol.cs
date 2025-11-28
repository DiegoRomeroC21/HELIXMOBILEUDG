using UnityEngine;

public class GoalContol : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        GameManager.singleton.nextLevel();
    }
}
