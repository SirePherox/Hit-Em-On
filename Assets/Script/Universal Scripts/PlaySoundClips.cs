using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundClips : MonoBehaviour
{
    private AudioSource audioSource;
    [SerializeField]
    private AudioClip deadSound, groundHitSound, fallSound, whooshSound;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
   
    void AttackFXSound()
    {
        audioSource.volume = 0.2f;
        audioSource.clip = whooshSound;
        audioSource.Play();
    }

    void CharDiedSound()
    {
        audioSource.volume = 1f;
        audioSource.clip = deadSound;
        audioSource.Play();
    }

    void EnemyKnockedDownSound()
    {
        audioSource.clip = fallSound;
        audioSource.Play();
    }

    void EnemyHitGroundSound()
    {
        audioSource.clip = groundHitSound;
        audioSource.Play();
    }
}
