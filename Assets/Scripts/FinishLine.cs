using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float delayTime = 0.5f;
    [SerializeField] ParticleSystem finishEffect;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Bruh")
        {
            finishEffect.Play();
            GetComponent<AudioSource>().Play();
            Invoke("ReloadScene", delayTime);
        }
    }
    
    void ReloadScene()
    {
        SceneManager.LoadScene(0);
    }
}
