using System.Collections.Generic;
using UnityEngine;

public class HelixControl : MonoBehaviour
{
    private Vector2 lastPointerPosition;
    private Vector3 startRotation;

    public Transform topTransform;
    public Transform goalTransform;

    public GameObject helixLevelPrefab;
    public List<Stage> allStages = new List<Stage>();

    public float helixDistance;
    private List<GameObject> spawnedLevels = new List<GameObject>();

    [SerializeField] private float rotationSpeed = 0.2f; // sensibilidad

    private void Awake()
    {
        startRotation = transform.localEulerAngles;

        helixDistance = topTransform.localPosition.y - (goalTransform.localPosition.y + .1f);
        LoadStage(0);
    }

    void Update()
    {
        HandlePointer();
    }

    void HandlePointer()
    {
        bool isPressed = false;
        Vector2 currentPos = Vector2.zero;

        // 1️⃣ TOUCH (móvil)
        if (Input.touchCount > 0)
        {
            Touch t = Input.GetTouch(0);

            if (t.phase == TouchPhase.Began ||
                t.phase == TouchPhase.Moved ||
                t.phase == TouchPhase.Stationary)
            {
                isPressed = true;
                currentPos = t.position;
            }
        }
        // 2️⃣ MOUSE (editor / PC)
        else if (Input.GetMouseButton(0))
        {
            isPressed = true;
            currentPos = Input.mousePosition;
        }

        if (isPressed)
        {
            if (lastPointerPosition == Vector2.zero)
            {
                // primer frame del toque/drag
                lastPointerPosition = currentPos;
                return;
            }

            float distance = lastPointerPosition.x - currentPos.x;
            lastPointerPosition = currentPos;

            float angle = -distance * rotationSpeed;
            transform.Rotate(Vector3.up, angle);
        }
        else
        {
            lastPointerPosition = Vector2.zero;
        }
    }

    public void LoadStage(int stageNumber)
    {
        Stage stage = allStages[Mathf.Clamp(stageNumber, 0, allStages.Count - 1)];
        if (stage == null)
        {
            Debug.Log("Stage not found: " + stageNumber);
            return;
        }
        Camera.main.backgroundColor = allStages[stageNumber].stagebackgroundColor;

        FindAnyObjectByType<BallControl>().GetComponent<Renderer>().material.color =
            allStages[stageNumber].stageBallColor;

        transform.localEulerAngles = startRotation;

        foreach (GameObject go in spawnedLevels)
        {
            Destroy(go);
        }

        float levelDistance = helixDistance / stage.levels.Count;
        float spawnPosY = topTransform.localPosition.y;

        for (int i = 0; i < stage.levels.Count; i++)
        {
            spawnPosY -= levelDistance;
            GameObject level = Instantiate(helixLevelPrefab, transform);

            level.transform.localPosition = new Vector3(0, spawnPosY, 0);
            spawnedLevels.Add(level);

            int partToDisable = 12 - stage.levels[i].partCount;
            List<GameObject> disabledParts = new List<GameObject>();
            while (disabledParts.Count < partToDisable)
            {
                GameObject randomPart =
                    level.transform.GetChild(Random.Range(0, level.transform.childCount)).gameObject;

                if (!disabledParts.Contains(randomPart))
                {
                    randomPart.SetActive(false);
                    disabledParts.Add(randomPart);
                }
            }

            List<GameObject> leftParts = new List<GameObject>();
            foreach (Transform t in level.transform)
            {
                t.GetComponent<Renderer>().material.color =
                    allStages[stageNumber].stagelevelPartColor;

                if (t.gameObject.activeInHierarchy)
                {
                    leftParts.Add(t.gameObject);
                }
            }

            List<GameObject> deathParts = new List<GameObject>();
            while (deathParts.Count < stage.levels[i].deathPartCount)
            {
                GameObject randomPart = leftParts[Random.Range(0, leftParts.Count)];

                if (!deathParts.Contains(randomPart))
                {
                    randomPart.gameObject.AddComponent<DeathPart>();
                    deathParts.Add(randomPart);
                }
            }
        }
    }
}
