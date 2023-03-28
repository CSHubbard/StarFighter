using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
  [Header("General")]
  [SerializeField] GameObject projectilePrefab;
  [SerializeField] float projectileSpeed = 10f;
  [SerializeField] float projectileLifetime = 5f;
  [SerializeField] float baseFiringRate = .2f;

  [Header("AI")]
  [SerializeField] bool useAI;
  [SerializeField] float enemyFiringRateVariance = 0f;
  [SerializeField] float minimumEnemyFiringRate = 0.2f;


  [HideInInspector] public bool isFiring;
  private Coroutine firingCoroutine;
  AudioPlayer audioPlayer;

  private void Awake()
  {
    audioPlayer = FindObjectOfType<AudioPlayer>();
  }

  // Start is called before the first frame update
  void Start()
  {
    if (useAI)
    {
      isFiring = true;
    }
  }

  // Update is called once per frame
  void Update()
  {
    Fire();
  }

  private void Fire()
  {
    if (isFiring && firingCoroutine == null)
    {
      firingCoroutine = StartCoroutine(FireContinuously());
    }
    else if (!isFiring && firingCoroutine != null)
    {
      StopCoroutine(firingCoroutine);
      firingCoroutine = null;
    }
  }

  private IEnumerator FireContinuously()
  {
    while (true)
    {
      GameObject pojectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
      Rigidbody2D rb = pojectile.GetComponent<Rigidbody2D>();
      if (rb != null)
      {
        rb.velocity = transform.up * projectileSpeed;
      }
      Destroy(pojectile, projectileLifetime);

      float timeToNextProjectile = UnityEngine.Random.Range(baseFiringRate - enemyFiringRateVariance, baseFiringRate + enemyFiringRateVariance);
      timeToNextProjectile = Mathf.Clamp(timeToNextProjectile, minimumEnemyFiringRate, float.MaxValue);
      audioPlayer.PlayShooingClip();
      yield return new WaitForSeconds(timeToNextProjectile);
    }
  }
}
