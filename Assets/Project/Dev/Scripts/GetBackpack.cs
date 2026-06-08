using UnityEngine;

public class GetBackpack : MonoBehaviour
{
    [SerializeField] private GameObject backpackInPlayer;
    [SerializeField] private AudioClip getItem;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            backpackInPlayer.SetActive(true);
            Destroy(this.gameObject);
        }
        else if (other.gameObject.CompareTag("Backpack"))
        {
            AudioManager.Instance.PlaySFX(getItem);
        }
    }
}
