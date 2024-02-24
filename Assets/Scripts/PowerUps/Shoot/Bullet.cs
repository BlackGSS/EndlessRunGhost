using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed = 8;

    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        //TODO: Interface IDamagable
        if (other.tag == "Enemy")
        {
            //TODO: IDamagable.Apply();
        }
    }
}
