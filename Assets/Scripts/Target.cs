using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpwanPos = -2;
    public int pointValue;
    private Rigidbody targetRb;
    private GameManager gameManager;
    public ParticleSystem explosionParticle;
    public ParticleSystem bullet;
    public List<ParticleCollisionEvent> collisionEvents;

    private AudioSource playerAudio;
    public AudioClip anikiSound;
    private GameObject playerCamera;
    
    // Start is called before the first frame update
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);
        transform.position = RandomSpawnPos();
        playerCamera = GameObject.Find("Main Camera");
        playerAudio = playerCamera.GetComponent<AudioSource>();
        collisionEvents = new List<ParticleCollisionEvent>();
    }
    private void OnParticleCollision(GameObject other)
    {
        if (!gameManager.isGameOver)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            playerAudio.PlayOneShot(anikiSound);
        }
    }
    private void OnMouseDown()
    {
        
       
    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpwanPos);
    }
}   
