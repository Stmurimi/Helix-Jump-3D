using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody playerRb;
    public float bounceForce = 6;
    private AudioManager audioManager;
    public ParticleSystem levelCompleteEffect;


    private void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
    }
    private void OnCollisionEnter(Collision collision)
    {
        audioManager.Play("Bounce");

        
        playerRb.velocity = new Vector3(playerRb.velocity.x, bounceForce, playerRb.velocity.z);
        string materialName = collision.transform.GetComponent<MeshRenderer>().material.name;

        if(materialName == "Safe (Instance)")
        {

        }
        else if(materialName == "Unsafe (Instance)") {
            GameManager.gameOver = true;
            audioManager.Play("Game Over");
        }
        else if (materialName == "LastRing (Instance)" && !GameManager.levelComplete)
        {
            GameManager.levelComplete = true;
            audioManager.Play("Win Level");
            levelCompleteEffect.Play();
        }
    }
}
