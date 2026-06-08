using UnityEngine;

public class Wire : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    [SerializeField] private float pushForce;
    [SerializeField] private GameObject fixedWires;
    [SerializeField] private AudioClip wireStatic, wireFix;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Vector3 direction = (other.transform.position - transform.position).normalized;

            other.GetComponent<Rigidbody>().AddForce(direction * pushForce, ForceMode.Impulse);
            AudioManager.Instance.PlaySFX(wireStatic);
        }

        if (other.gameObject.CompareTag("Backpack"))
        {
            gameManager.WireRepaired();
            Destroy(this.gameObject);
            fixedWires.SetActive(true);
            AudioManager.Instance.PlaySFX(wireFix);
        }
    }
}
