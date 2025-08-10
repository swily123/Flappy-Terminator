using TMPro;
using UnityEngine;

namespace ScoreSystem
{
    public class ScoreViewer : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI _scoreText;

        public void ChangeValue(int value)
        {
            _scoreText.text = value.ToString();
        }
    }
}