using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
  [SerializeField] float sceneLoadDelay = 2f;
  AudioPlayer audioPlayer;
  ScoreKeeper scoreKeeper;
  private void Awake()
  {
    audioPlayer = FindObjectOfType<AudioPlayer>();
    scoreKeeper = FindObjectOfType<ScoreKeeper>();
  }

  public void LoadGame()
  {
    scoreKeeper.RestScore();
    SceneManager.LoadScene("Game");
    audioPlayer.PlayBattleMusic();

  }

  public void LoadMainMenu()
  {
    SceneManager.LoadScene("MainMenu");
    audioPlayer.PlayMainMenuMusic();
  }

  public void LoadGameOver()
  {
    StartCoroutine(WaitAndLoad("GameOver", sceneLoadDelay));
    audioPlayer.PlayEndScreenMusic();
  }

  public void QuitGame()
  {
    Application.Quit();
  }

  IEnumerator WaitAndLoad(string sceneName, float delay)
  {
    yield return new WaitForSeconds(delay);
    SceneManager.LoadScene(sceneName);
  }

}
