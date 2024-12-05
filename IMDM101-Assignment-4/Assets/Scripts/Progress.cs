using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Progress : MonoBehaviour
{

    public static bool redStatus, pinkStatus, blueStatus;
    public static bool red2, pink2, blue2;
    public GameObject redSquare, pinkSquare, blueSquare;
    public GameObject fakeRed, fakePink, fakeBlue;
    private float time, target;
    public AudioSource Source;
    public AudioClip bells, kidney, alien, thunder, car;
    AudioClip[] clips = new AudioClip[4];

    void Awake()
    {
        redStatus = false;
        pinkStatus = false;
        blueStatus = false;

        red2 = false;
        pink2 = false;
        blue2 = false;

        redSquare.SetActive(false);
        pinkSquare.SetActive(false);
        blueSquare.SetActive(false);

        fakeRed.SetActive(true);
        fakePink.SetActive(true);
        fakeBlue.SetActive(true);

        time = 0;
        target = Random.Range(10f, 21f);

        Source = GetComponent<AudioSource>();
        clips[0] = thunder;
        clips[1] = car;
        clips[2] = bells;
        clips[3] = kidney;
 //       clips[4] = alien;
    }

    void Update()
    {

        time += Time.deltaTime;
        if(time >= target)
        {
            Source.clip = clips[Random.Range(0, clips.Length)];
            Source.Play();
            time -= target;
            target = Random.Range(29f, 102f);
        }

        if (redStatus)
        {
            fakeRed.SetActive(false);
            redSquare.SetActive(true);
        }
        else
        {
            redSquare.SetActive(false);
        }
        if (pinkStatus)
        {
            fakePink.SetActive(false);
            pinkSquare.SetActive(true);
        }
        else
        {
            pinkSquare.SetActive(false);
        }
        if (blueStatus)
        {
            fakeBlue.SetActive(false);
            blueSquare.SetActive(true);
        }
        else
        {
            blueSquare.SetActive(false);
        }
    }

}
