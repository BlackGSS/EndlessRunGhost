using UnityEngine;

public class PlayerAnimStore : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void PlayLevelUpAnim()
    {
        animator.Play("LevelUp");
    }
}
