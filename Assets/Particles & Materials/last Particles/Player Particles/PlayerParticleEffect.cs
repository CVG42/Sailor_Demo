using UnityEngine;

public class PlayerParticleEffect : MonoBehaviour
{
    [SerializeField] private ParticleSystem movementParticle;
    [SerializeField] private ParticleSystem movementParticle2;
    [SerializeField] private ParticleSystem movementParticle3;
    [SerializeField] private float minVelocityToPlayEffect = 1.0f; 
    [SerializeField] private Rigidbody playerRb;

    private bool isPlaying = false; 
    private Vector3 lastPosition; 

    private void Start()
    {
        if (movementParticle == null)
        {
            Debug.Log("Particle System no esta asignado.");
        }

        if (playerRb == null)
        {
            Debug.Log("Rigidbody no esta asigando.");
        }

        lastPosition = transform.position; 
    }

    private void Update()
    {
        
        if (movementParticle == null || playerRb == null)
        {
            return;
        }

        Vector3 displacement = transform.position - lastPosition;
        float horizontalSpeed = new Vector3(displacement.x, 0, displacement.z).magnitude / Time.deltaTime;


        if (horizontalSpeed >= minVelocityToPlayEffect && !isPlaying)
        {
            movementParticle.Play();
            movementParticle2.Play();
            movementParticle3.Play();
            isPlaying = true;
        }
       
        else if (horizontalSpeed < minVelocityToPlayEffect && isPlaying)
        {
            movementParticle.Stop();
            movementParticle2.Stop();
            movementParticle3.Stop();
            isPlaying = false;
        }

        lastPosition = transform.position;
    }
}
