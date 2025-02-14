using UnityEngine;

public class Sword : MonoBehaviour
{
    public float damage = 20f;
    private Vector3 previousPosition;

    void Start()
    {
        previousPosition = transform.position;
    }

    void Update()
    {
        float speed = (transform.position - previousPosition).magnitude / Time.deltaTime;
        previousPosition = transform.position;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            float impactForce = (transform.position - previousPosition).magnitude * 10f;
            other.GetComponent<EnemyHealth>()?.TakeDamage(damage * impactForce);
        }
    }
}
