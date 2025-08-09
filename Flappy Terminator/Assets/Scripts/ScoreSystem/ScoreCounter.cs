using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private SpawnerBullets _spawnerBullets;
    [SerializeField] private ScoreViewer _scoreViewer;

    private int _score = 0;

    private void OnEnable()
    {
        _spawnerBullets.EnemyHitted += IncreaseScore;
    }

    private void OnDisable()
    {
        _spawnerBullets.EnemyHitted -= IncreaseScore;
    }

    private void IncreaseScore()
    {
        _score++;
        _scoreViewer.ChangeValue(_score);
    }

    public void Reset()
    {
        _score = 0;
        _scoreViewer.ChangeValue(_score);
    }
}