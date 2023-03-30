using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
  [Header("Shooting")]
  [SerializeField] AudioClip shootingClip;
  [SerializeField][Range(0, 1)] float shootingVolume = 1f;

  [Header("Damage")]
  [SerializeField] AudioClip damageClip;
  [SerializeField][Range(0, 1)] float damageVolume = 1f;
  AudioSource musicSource;

  [Header("Music")]
  [SerializeField] AudioClip mainMenuTrack;
  [SerializeField] AudioClip battleTrack;
  [SerializeField] AudioClip endScreenTrack;
  float mainMenuVolume = .05f;
  float battleVolume = .05f;
  float endScreenVolume = .05f;

  AudioPlayer instance;

  private void Awake()
  {
    musicSource = GetComponent<AudioSource>();
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

  public void PlayShooingClip()
  {
    PlayClip(shootingClip, shootingVolume);
  }

  public void PlayDamageClip()
  {
    PlayClip(damageClip, damageVolume);
  }

  public void PlayBattleMusic()
  {
    PlayMusic(battleTrack, battleVolume);

  }

  public void PlayMainMenuMusic()
  {
    PlayMusic(mainMenuTrack, mainMenuVolume);
  }

  public void PlayEndScreenMusic()
  {
    PlayMusic(endScreenTrack, endScreenVolume);
  }

  private void PlayMusic(AudioClip track, float v)
  {
    musicSource.clip = track;
    musicSource.volume = v;
    musicSource.Play();
  }

  private void PlayClip(AudioClip audioClip, float volume)
  {
    if (damageClip != null)
    {
      AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, shootingVolume);
    }
  }
}
