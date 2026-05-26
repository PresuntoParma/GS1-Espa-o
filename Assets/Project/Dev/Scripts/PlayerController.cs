using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Rigidbody rb;

    [Header("Action References")]
    [SerializeField] private InputActionReference spinAction;
    [SerializeField] private InputActionReference blowAction;

    [Header("Control Settings")]
    [SerializeField] private float blowPower;
    [SerializeField] private float spinSpeed;

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
        Spin();
        Blow();
    }

    private void Spin()
    {
        float dir = spinAction.action.ReadValue<float>();
        Vector3 rotation = transform.eulerAngles;

        rotation.x = rotation.z = 0;
        rotation.y += Time.deltaTime * dir * spinSpeed;

        transform.eulerAngles = rotation;
    }

    private void Blow()
    {
        if (blowAction.action.IsPressed())
        {
            rb.AddForce(transform.forward.normalized * -1 * blowPower, ForceMode.Acceleration);
        }
    }
}
