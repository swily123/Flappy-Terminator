using TMPro;
using UnityEngine;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    public void ChangeValue(int value)
    {
        _scoreText.text = value.ToString();
    }
}