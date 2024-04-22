using UnityEngine;
using UnityEngine.Events;

public class PlayerCollision : MonoBehaviour
{
    [SerializeField] UnityEvent callbackOnCollision;

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy" && !other.isTrigger)
            callbackOnCollision.Invoke();
    }
}
