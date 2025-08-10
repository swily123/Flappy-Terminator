using Spawners;
using UnityEngine;

namespace ScoreSystem
{
    public class ScoreCounter : MonoBehaviour
    {
        [SerializeField] private SpawnerEnemies _spawnerEnemies;
        [SerializeField] private ScoreViewer _scoreViewer;

        private int _score;

        private void OnEnable()
        {
            _spawnerEnemies.EnemyHitted += IncreaseScore;
        }

        private void OnDisable()
        {
            _spawnerEnemies.EnemyHitted -= IncreaseScore;
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
}