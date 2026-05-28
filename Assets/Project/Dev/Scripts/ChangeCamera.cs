using UnityEngine;

public class ChangeCamera : MonoBehaviour
{
    [SerializeField] private GameObject[] cameras;
    [SerializeField] private int cameraToActivate;

    private void CameraChange()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].SetActive(false);
        }

        cameras[cameraToActivate].SetActive(true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
            CameraChange();
    }
}
