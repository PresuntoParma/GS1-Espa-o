using UnityEngine;

public class BlowerCollisionImpulse : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRb;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Transform pipeTipTransform;

    [SerializeField] private float pushForce;

    private void OnCollisionEnter(Collision collision)
    {
        /*print("Bateu");
        Vector3 dir = new Vector3(pipeTipTransform.position.x, 0, playerTransform.position.z);
        dir.Normalize();
        if (playerTransform.position.x > pipeTipTransform.position.x) dir.x *= -1;
        print(dir);

        playerRb.AddForce(dir * -pushForce, ForceMode.Impulse);*/

        //Determina a direção que deve ser empurrado
        float x = playerTransform.position.x > pipeTipTransform.position.x ? 1 : -1;
        float z = playerTransform.position.z > pipeTipTransform.position.z ? 1 : -1;

        Vector3 dir = new Vector3(1 * x, 0, 1 * z);
        //Empurra
        playerRb.AddForce(dir * pushForce, ForceMode.Impulse);

    }
}
