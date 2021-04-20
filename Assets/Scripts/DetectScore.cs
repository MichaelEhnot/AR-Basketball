using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DetectScore : MonoBehaviour
{
    private int score;

    private AudioSource audioSource;

    private void Start()
    {
        score = 0;
        audioSource = gameObject.GetComponent<AudioSource>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "ball")
        {
            score++;
            audioSource.Play();
        }
    }


}
