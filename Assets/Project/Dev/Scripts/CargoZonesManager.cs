using UnityEngine;

public class CargoZonesManager : MonoBehaviour
{
    [SerializeField] private CargoZones[] cargoZones;
    [SerializeField] private GameManager gameManager;

    private void Update()
    {
        CheckForFullZones();
    }

    private void CheckForFullZones()
    {
        for (int i = 0; i < cargoZones.Length; i++)
        {
            if (cargoZones[i].FullZone() == false) return;
        }
        print("Todas as zonas cheias");
        gameManager.NextLevel();
    }
}
