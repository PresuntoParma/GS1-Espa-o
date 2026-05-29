using UnityEngine;

public class GetBackpack : MonoBehaviour
{
    [SerializeField] private GameObject backpackInPlayer;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            backpackInPlayer.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}
