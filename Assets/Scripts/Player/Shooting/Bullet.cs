using UnityEngine;

public class Bullet : MonoBehaviour
{
    void Update()
    {
        if (Mathf.Abs(transform.position.x) > 12.65f ||
            Mathf.Abs(transform.position.y) > 5.12f)
        {
            Destroy(gameObject);
        }       
    }
}
