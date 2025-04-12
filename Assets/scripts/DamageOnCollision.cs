using UnityEngine;


public class DamageOnCollision : MonoBehaviour
{
    public string targetTag;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(targetTag))
        {
            collision.gameObject.GetComponent<Health>().TakeDamage(1);
        }
    }
}
