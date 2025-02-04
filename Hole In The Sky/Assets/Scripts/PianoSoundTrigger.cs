﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PianoSoundTrigger : MonoBehaviour
{
    public GameObject piano;
    public AudioSource scaryPianoAudioSource;
    public AudioClip scarySound;
    public Light flashLight;
    public Light pianoLight;
    public PianoRiddle pianoRiddle;

    private bool hasPlayed;

    private bool exit;
    private bool readyToPlay;
    private int i = 1;
    private Random rand = new Random();

    private Dictionary<string, Transform> pianoKeys = new Dictionary<string, Transform>();

    void Start()
    {
        readyToPlay = false;
        foreach (Transform t in piano.transform)
        {
            pianoKeys.Add(t.name, t);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !hasPlayed)
        {
            scaryPianoAudioSource.PlayOneShot(scarySound);
            hasPlayed = true;
            pianoLight.enabled = true;

            if (flashLight.enabled)
            {
                flashLight.enabled = false;
            }
            StartCoroutine("WaitForStart");
        }
    }

    public void Update()
    {
        if (readyToPlay)
        {
            if (Random.Range(0, 10) % 2 == 0)
            {
                if (i % 2 == 0)
                {
                    StartCoroutine("WaitHalfQuater", "C7");
                }
                else if (i % 3 == 0)
                {
                    StartCoroutine("WaitQuater", "A#3");
                }
                else if (i % 4 == 0)
                {
                    StartCoroutine("WaitQuater", "C3");
                }
                else if (i % 5 == 0)
                {
                    StartCoroutine("WaitHalfQuater", "G#4");
                }
                else if (i % 7 == 0)
                {
                    StartCoroutine("WaitQuater", "F5");
                }
                else if (i % 9 == 0)
                {
                    StartCoroutine("WaitHalfQuater", "C6");
                }
                else
                {
                    StartCoroutine("WaitQuater", "G4");
                }
            }
            else
            {
                if (i % 2 == 0)
                {
                    StartCoroutine("WaitQuater", "D5");
                }
                else if (i % 3 == 0)
                {
                    StartCoroutine("WaitHalfQuater", "C#4");
                }
                else if (i % 4 == 0)
                {
                    StartCoroutine("WaitQuater", "D3");
                }
                else if (i % 5 == 0)
                {
                    StartCoroutine("WaitHalfQuater", "G#4");
                }
                else if (i % 7 == 0)
                {
                    StartCoroutine("WaitQuater", "A5");
                }
                else if (i % 9 == 0)
                {
                    StartCoroutine("WaitHalfQuater", "C1");
                }
                else
                {
                    StartCoroutine("WaitQuater", "D4");
                }
            }
        }
    }

    public IEnumerator WaitForStart()
    {
        yield return new WaitForSeconds(scarySound.length / 5);
        readyToPlay = true;
        i++;
    }

    public void CheckRiddle(string pianoKeyName)
    {
        /*pianoRiddle.CheckKeys(pianoKeyName);*/
    }

    public IEnumerator WaitWhole(string pianoKeyName)
    {
        Transform pianoKey = pianoKeys["key" + pianoKeyName];
        readyToPlay = false;        
        CheckRiddle(pianoKeyName);
        pianoKey.GetComponent<PianoKey>().playSound();
        yield return new WaitForSeconds(pianoKey.GetComponent<PianoKey>().pianoKeySound.length);
        i++;
        if (i < 41)
        {
            readyToPlay = true;
        }
    }

    public IEnumerator WaitHalf(string pianoKeyName)
    {
        Transform pianoKey = pianoKeys["key" + pianoKeyName];
        readyToPlay = false;
        CheckRiddle(pianoKeyName);
        pianoKey.GetComponent<PianoKey>().playSound();
        yield return new WaitForSeconds(pianoKey.GetComponent<PianoKey>().pianoKeySound.length / 6);
        i++;
        if (i < 41)
        {
            readyToPlay = true;
        }
    }

    public IEnumerator WaitQuater(string pianoKeyName)
    {
        Transform pianoKey = pianoKeys["key" + pianoKeyName];
        readyToPlay = false;
        CheckRiddle(pianoKeyName);
        pianoKey.GetComponent<PianoKey>().playSound();
        yield return new WaitForSeconds(pianoKey.GetComponent<PianoKey>().pianoKeySound.length / 8);
        i++;
        if (i < 41)
        {
            readyToPlay = true;
        }
    }

    public IEnumerator WaitHalfQuater(string pianoKeyName)
    {
        Transform pianoKey = pianoKeys["key" + pianoKeyName];
        readyToPlay = false;
        CheckRiddle(pianoKeyName);
        pianoKey.GetComponent<PianoKey>().playSound();
        yield return new WaitForSeconds(pianoKey.GetComponent<PianoKey>().pianoKeySound.length / 12);
        i++;
        if (i < 41)
        {
            readyToPlay = true;
        }
    }
    
}
