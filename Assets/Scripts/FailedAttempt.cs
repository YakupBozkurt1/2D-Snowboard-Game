using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FailedAttempt : MonoBehaviour
{
    private CircleCollider2D playerHead;
    [SerializeField] float delayTime = 0.5f;
    [SerializeField] private ParticleSystem failedEffect;
    [SerializeField] private AudioClip crashedSFX;
    [SerializeField] private bool doublePlay = true;
    private void Start()
    {
        playerHead = GetComponent<CircleCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Ground" && playerHead.IsTouching(other.collider) && doublePlay)
        {
            FindObjectOfType<BallTorque>().StopMovement();
            failedEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashedSFX);
            Invoke("ReloadScene", delayTime);
            doublePlay = false;
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
