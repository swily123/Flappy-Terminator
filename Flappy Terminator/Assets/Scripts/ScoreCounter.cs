using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private SpawnerBullets _spawnerBullets;
    [SerializeField] private ScoreViewer _scoreViewer;

    private int _score = 0;

    private void OnEnable()
    {
        _spawnerBullets.EnemyHittedr += IncreaseScore;
    }

    private void OnDisable()
    {
        _spawnerBullets.EnemyHittedr -= IncreaseScore;
    }

    private void IncreaseScore()
    {
        _score++;
        _scoreViewer.ChangeValue(_score);
    }
}