using UnityEngine;

public class CamControll : MonoBehaviour
{
    public BallControl ball; // Reference to the BallControl script
    private float offset; // Initial offset between camera and ball on Z axis

void Start()
    {
       offset = transform.position.y - ball.transform.position.y;
    }

    void Update()
    {
       Vector3 actualpos = transform.position;
       actualpos.y = ball.transform.position.y + offset;
       transform.position = actualpos;
    }


}
