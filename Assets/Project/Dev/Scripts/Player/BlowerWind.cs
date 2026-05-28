using UnityEngine;

public class BlowerWind : MonoBehaviour
{

    [SerializeField] private float blowPower = 3f;

    private void OnTriggerStay(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>()?.AddForce(transform.up.normalized * blowPower, ForceMode.Acceleration);
    }

}
