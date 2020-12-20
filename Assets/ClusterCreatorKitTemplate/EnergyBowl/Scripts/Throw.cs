using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public float weight, power, angle, spin;
    public GameObject ball;
    public AudioClip AC;
    public AudioSource AS; //https://dova-s.jp/bgm/download13494.html

    public void change(SelectedBall selectedBall)
    {
        ball.GetComponent<Ball>().changeBall(selectedBall);
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T)) {
            ThrowBowl();
        }
    }

    void ThrowBowl()
    {
        Debug.Log("throw");
        if (ball.GetComponent<Ball>().isThrowed == false)
        {
            AS.PlayOneShot(AC);
            ball.GetComponent<Ball>().isThrowed = true;
            ball.GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.02f, -power);
        }
    }
}
