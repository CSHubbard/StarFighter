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

  // Start is called before the first frame update
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {

  }

  public void PlayShooingClip()
  {
    PlayClip(shootingClip, shootingVolume);
  }

  public void PlayDamageClip()
  {
    PlayClip(damageClip, damageVolume);
  }

  private void PlayClip(AudioClip audioClip, float volume)
  {
    if (damageClip != null)
    {
      AudioSource.PlayClipAtPoint(audioClip, Camera.main.transform.position, shootingVolume);
    }
  }
}
