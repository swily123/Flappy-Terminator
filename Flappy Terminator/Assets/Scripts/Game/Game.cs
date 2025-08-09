using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField] private Bird _bird;
    [SerializeField] private InputReader _inputReader;
    [SerializeField] private StartScreen _startScreen;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private EndGameScreen _endGameScreen;
    [SerializeField] private SpawnerEnemies _spawnerEnemies;
    [SerializeField] private SpawnerBullets _playerSpawnersBullets;

    private void OnEnable()
    {
        _startScreen.PlayButtonClicked += OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked += OnRestartButtonClick;
    }

    private void OnDisable()
    {
        _startScreen.PlayButtonClicked -= OnPlayButtonClick;
        _endGameScreen.RestartButtonClicked -= OnRestartButtonClick;
    }

    private void Start()
    {
        _inputReader.RestoreDefaultCursor();
        _startScreen.Open();
        _endGameScreen.Close();
        Time.timeScale = 0;
    }

    public void GameOver()
    {
        _inputReader.RestoreDefaultCursor();
        _endGameScreen.Open();
        _spawnerEnemies.StopSpawning();
        _inputReader.StopWorking();
        Time.timeScale = 0;
    }

    private void OnRestartButtonClick()
    {
        _endGameScreen.Close();
        StartGame();
    }
    private void OnPlayButtonClick()
    {
        _startScreen.Close();
        StartGame();
    }

    private void StartGame()
    {
        Time.timeScale = 1;
        _bird.Reset();
        _scoreCounter.Reset();
        _inputReader.SetGameCursor();
        _spawnerEnemies.StartSpawning();
        _inputReader.StartWorking();
        ClearAllEnemiesAndBullets();
    }
    private void ClearAllEnemiesAndBullets()
    {
        _playerSpawnersBullets.DisableAllActiveBullets();
        _spawnerEnemies.DisableAllActiveBulletsEnemies();
        _spawnerEnemies.DisableAllActiveEnemies();
    }
}
