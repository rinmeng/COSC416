using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;

    // A reference to our ballController
    [SerializeField] private BallController ball;

    // A reference for our PinCollection prefab we made in Section 2.2
    [SerializeField] private GameObject pinCollection;

    // use to spawn our pin collection prefab
    // A reference for an empty GameObject which we'll
    [SerializeField] private Transform pinAnchor;

    // A reference for our input manager
    [SerializeField] private InputManager inputManager;

    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] fallTriggers;
    private GameObject pinObjects;

    void Start()
    {
        inputManager.OnResetPressed.AddListener(HandleReset);
        SetPins();
    }

    private void HandleReset()
    {
        ball.ResetBall();
        SetPins();
    }


    private void SetPins()
    {
        Debug.Log("SetPins called at: " + Time.time);
        if (pinObjects)
        {
            foreach (Transform child in pinObjects.transform)
            {
                Destroy(child.gameObject);
            }
            Destroy(pinObjects);
        }

        pinObjects = Instantiate(pinCollection, pinAnchor.transform.position, Quaternion.identity, transform);

        fallTriggers = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (FallTrigger pin in fallTriggers)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }
    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }

}
