using UnityEngine;

public class CargoZones : MonoBehaviour
{
    private enum colors
    {
        Red,
        Green,
        Blue
    }

    [SerializeField] private colors cargoColor;
    [SerializeField] private int maxCargo = 3;

    private int cargoInThisZone = 0;
    private bool zoneIsFull = false;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(cargoColor.ToString()))
        {
            CheckCargoAmmount(+1);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(cargoColor.ToString()))
        {
            CheckCargoAmmount(-1);
        }
    }

    private void CheckCargoAmmount(int i)
    {
        cargoInThisZone += i;
        zoneIsFull = cargoInThisZone == maxCargo;
        print(cargoColor.ToString() + cargoInThisZone);
    }

    public bool FullZone()
    {
        return zoneIsFull;
    }
}
