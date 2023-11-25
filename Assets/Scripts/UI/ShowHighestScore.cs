using TMPro;
using UnityEngine;

public class ShowHighestScore : MonoBehaviour
{
    [Header("Dependências")]
    [SerializeField] private TextMeshProUGUI highestScoreText;

    void Start()
    {
        int recordScore = PlayerPrefs.GetInt("highest");
        highestScoreText.text = $"{recordScore}";
    }
}
