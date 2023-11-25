using TMPro;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    [Header("Dash BTN Configs")]
    public static int score;
    public static int highestScore;

    [SerializeField] private TextMeshProUGUI scoreText;

    private void Start()
    {
        score = 0;
        highestScore = score;
    }

    private void Update()
    {
        scoreText.GetComponentInChildren<TMP_Text>().text = $"Score: {score}";

        if (score > highestScore)
        {
            highestScore = score;
        }
    }

}
