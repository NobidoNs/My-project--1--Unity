using UnityEngine;

public class SwordImpact : MonoBehaviour
{
    public GameObject impactPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            ContactPoint contact = collision.contacts[0];
            Quaternion rotation = Quaternion.LookRotation(contact.normal);
            Instantiate(impactPrefab, contact.point, rotation);
        }
    }
}
