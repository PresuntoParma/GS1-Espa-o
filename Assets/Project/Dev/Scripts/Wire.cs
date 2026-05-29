using UnityEngine;

public class Wire : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float pushForce;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 direction = (other.transform.position - transform.position).normalized;

            other.GetComponent<Rigidbody>().AddForce(direction * pushForce, ForceMode.Impulse);
        }

        if (other.gameObject.CompareTag("Backpack"))
        {
            gameManager.WireRepaired();
            Destroy(this.gameObject);
        }
    }
}
