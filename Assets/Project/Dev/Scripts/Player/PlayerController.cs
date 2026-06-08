using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;
    [SerializeField] private BoxCollider blowCollider;
    [SerializeField] private ParticleSystem windParticles;
   

    [Header("Action References")]
    [SerializeField] private InputActionReference spinAction;
    [SerializeField] private InputActionReference blowAction;

    [Header("Control Settings")]
    [SerializeField] private float blowPower;
    [SerializeField] private float spinSpeed;

    [Header("Audio Clips")]
    [SerializeField] private AudioClip[] sfxclips;
    

    

    private void OnEnable()
    {
        spinAction.action.Enable();
        blowAction.action.Enable();
    }

    private void OnDisable()
    {
        spinAction.action.Disable();
        blowAction.action.Disable();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Blow();
    }

    private void FixedUpdate()
    {
        Spin();
    }

    private void Spin()
    {
        float dir = spinAction.action.ReadValue<float>();
        Vector3 rotation = transform.eulerAngles;

        rotation.x = rotation.z = 0;
        rotation.y += dir * spinSpeed;

        rb.MoveRotation(Quaternion.Euler(rotation)
);
    }

    private void Blow()
    {
        if (blowAction.action.IsPressed())
        {
            rb.AddForce(transform.forward.normalized * -1 * blowPower, ForceMode.Acceleration);
            blowCollider.enabled = true;
        }
        else
        {
            blowCollider.enabled = false;
        }

        BlowParticle();
    }

    private void BlowParticle()
    {
        if (blowAction.action.WasPressedThisFrame())
        {
            windParticles.Play();
        }

        if (blowAction.action.WasReleasedThisFrame())
        {
            windParticles.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            AudioManager.Instance.PlaySFX(sfxclips[0]);

        }
        else if (collision.gameObject.CompareTag("Metal"))
        {
            AudioManager.Instance.PlaySFX(sfxclips[1]);
        }
        else if (collision.gameObject.CompareTag("Cloth"))
        {
            AudioManager.Instance.PlaySFX(sfxclips[2]);
        }
        else if (collision.gameObject.CompareTag("Spiffo"))
        {
            AudioManager.Instance.PlaySFX(sfxclips[3]);
        }
        else if (collision.gameObject.CompareTag("MetalBox"))
        {
            AudioManager.Instance.PlaySFX(sfxclips[4]);
        }
        else if (collision.gameObject.CompareTag("MetalToolBox"))
        {
            AudioManager.Instance.PlaySFX(sfxclips[5]);
        }
        else if (collision.gameObject.CompareTag("Table"))
        {
            AudioManager.Instance.PlaySFX(sfxclips[6]);
        }
        else if (collision.gameObject.CompareTag("Chair"))
        {
            AudioManager.Instance.PlaySFX(sfxclips[7]);
        }
        else if (collision.gameObject.CompareTag("Bed"))
        {
            AudioManager.Instance.PlaySFX(sfxclips[8]);
        }
        else if (collision.gameObject.CompareTag("Lever"))
        {
            AudioManager.Instance.PlaySFX(sfxclips[9]);
        }
        else if (collision.gameObject.CompareTag("MetalPanel"))
        {
            AudioManager.Instance.PlaySFX(sfxclips[10]);
        }
        else if (collision.gameObject.CompareTag("CardBox"))
        {
            AudioManager.Instance.PlaySFX(sfxclips[11]);
        }
        
    }
}
