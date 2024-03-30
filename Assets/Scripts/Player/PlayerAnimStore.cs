using DG.Tweening;
using UnityEngine;

public class PlayerAnimStore : MonoBehaviour
{
    [SerializeField] Animator animator;

    public void PlayLevelUpAnim()
    {
        animator.Rebind();
        animator.Update(0);
        animator.Play("LevelUp");
    }
}
