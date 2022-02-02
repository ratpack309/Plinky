using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ParticleSystem bounceParticle;
    private Vector3 bounceParticlePosition;
    private AudioSource bounceSound;
    // Start is called before the first frame update
    void Start()
    {
        bounceSound = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        bounceParticlePosition = new Vector3(transform.position.x, transform.position.y, transform.position.z);
    }

    void OnCollisionEnter(Collision collision)
    {
        bounceSound.Play();
        Instantiate(bounceParticle, bounceParticlePosition, Quaternion.identity);
    }
}
