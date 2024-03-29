using DG.Tweening;
using UnityEngine;

public class PlayerAnimStore : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Animation anim;

    public void PlayLevelUpAnim()
    {
        animator.Rebind();
        animator.Update(0);
        animator.Play("LevelUp");
    }
}
