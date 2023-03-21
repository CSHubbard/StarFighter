using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
  [SerializeField] float shakeDuration = 0.25f;
  [SerializeField] float shakeMagnitude = 0.15f;
  Vector3 initialPosition;
  // Start is called before the first frame update
  void Start()
  {
    initialPosition = transform.position;
  }

  // Update is called once per frame
  void Update()
  {

  }

  public void Play()
  {
    StartCoroutine(Shake());
  }

  private IEnumerator Shake()
  {
    float elapsedTime = 0;
    while (elapsedTime < shakeDuration)
    {
      transform.position = initialPosition + (Vector3)UnityEngine.Random.insideUnitCircle * shakeMagnitude;
      elapsedTime += Time.deltaTime;
      yield return new WaitForEndOfFrame();
    }
    transform.position = initialPosition;
  }
}
