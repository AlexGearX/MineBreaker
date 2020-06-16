using System;
using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.WSA;
using Vector2 = UnityEngine.Vector2;

public class Ball : MonoBehaviour
{
    //config params
    [SerializeField] Paddle paddle1;
    [SerializeField] float xPush = 2f;
    [SerializeField] float yPush = 15f;
    [SerializeField] AudioClip[] ballSounds;

    //state
    Vector2 paddleToBallVector;
    bool hasStarted = false;

    //Cached component references

    AudioSource myAudioSouce;

    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle1.transform.position;
        myAudioSouce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasStarted == false)
        {
                LockBallToPaddle();
                LaunchOnMouseClick();
        }
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(xPush, yPush);
            hasStarted = true;
        }
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle1.transform.position.x, paddle1.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (hasStarted)
        {
            AudioClip clip = ballSounds[UnityEngine.Random.Range(0, ballSounds.Length)];
            GetComponent<AudioSource>().PlayOneShot(clip);
        } 
    }
}
