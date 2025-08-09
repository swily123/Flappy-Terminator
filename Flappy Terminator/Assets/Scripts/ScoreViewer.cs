using TMPro;
using UnityEngine;

public class ScoreViewer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private void Start()
    {
        ChangeValue(0);
    }

    public void ChangeValue(int value)
    {
        _scoreText.text = value.ToString();
    }
}