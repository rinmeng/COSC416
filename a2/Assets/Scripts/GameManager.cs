using UnityEngine;
using TMPro;
public class GameManager : MonoBehaviour
{
    [SerializeField] private float score = 0;
    [SerializeField] private TextMeshProUGUI scoreText;
    private FallTrigger[] pins;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        pins = FindObjectsByType<FallTrigger>(FindObjectsInactive.Include, FindObjectsSortMode.None);

        foreach (FallTrigger pin in pins)
        {
            pin.OnPinFall.AddListener(IncrementScore);
        }

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void IncrementScore()
    {
        score++;
        scoreText.text = $"Score: {score}";
    }

}
