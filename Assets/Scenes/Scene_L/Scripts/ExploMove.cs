using UnityEngine;
using System.Collections;

public class ExploMove : MonoBehaviour
{
    public float speed = 5f; 
    public float lifetime = 5f; 
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.useGravity = false; 
            rb.constraints = RigidbodyConstraints.FreezeRotation; 
        }

        StartCoroutine(DestroyAfterTime());
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);
    }

    IEnumerator DestroyAfterTime()
    {
        yield return new WaitForSeconds(lifetime);

        Destroy(gameObject);
    }
}