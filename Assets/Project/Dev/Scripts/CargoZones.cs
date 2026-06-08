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

            ChangeOutlineColor(other, Color.green);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(cargoColor.ToString()))
        {
            CheckCargoAmmount(-1);

            ChangeOutlineColor(other, Color.red);
        }
    }


    // pego a referência da mesh renderer, procuro pelo material que tem o shader, pego a referência do S.Graph e aplico a mudança de cor

    private void ChangeOutlineColor(Collider other, Color color)
    {
        Renderer rend = other.GetComponent<Renderer>();

        if (rend == null)
            return;

        foreach (Material mat in rend.materials)
        {
            if (mat.name.Contains("Outline"))
            {
                mat.SetColor("_OutlineColor", color);
            }
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