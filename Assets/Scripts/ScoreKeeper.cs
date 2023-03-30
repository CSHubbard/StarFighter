using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreKeeper : MonoBehaviour
{
  ScoreKeeper instance;

  private void Awake()
  {
    ManageSingleton();
  }

  private void ManageSingleton()
  {
    int instanceCount = FindObjectsOfType(GetType()).Length;
    if (instanceCount > 1)
    {
      gameObject.SetActive(false);
      Destroy(gameObject);
    }
    else
    {
      DontDestroyOnLoad(gameObject);
    }
  }

  int score = 0;
  public int GetScore() { return score; }

  public void ModifyScore(int value)
  {
    score += value;
  }

  public void RestScore()
  {
    score = 0;
    Mathf.Clamp(score, 0, int.MaxValue);
  }

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }
}
