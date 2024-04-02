using DG.Tweening;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] Transform starsEffectTransform;
    [SerializeField] ParticleSystem starsEffectPrefab;
    Vector3 originalScale;

    void OnEnable()
    {
        originalScale = transform.localScale;
        transform.localScale = Vector3.zero;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(originalScale + new Vector3(0.3f, 0.3f, 0.3f), 0.2f));
        sequence.Append(transform.DOScale(originalScale - new Vector3(0.2f, 0.2f, 0.2f), 0.1f));
        sequence.PrependCallback(() => GlobalParticleSystem.Play(starsEffectPrefab, starsEffectTransform));
        sequence.Append(transform.DOScale(originalScale + new Vector3(0.1f, 0.1f, 0.1f), 0.1f));
        sequence.Append(transform.DOScale(originalScale, 0.05f));
    }
}