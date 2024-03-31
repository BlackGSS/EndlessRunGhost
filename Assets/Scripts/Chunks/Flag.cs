using DG.Tweening;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField] Transform starsEffectTransform;
    [SerializeField] ParticleSystem starsEffectPrefab;

    void OnEnable()
    {
        transform.localScale = Vector3.zero;
        Sequence sequence = DOTween.Sequence();
        sequence.Append(transform.DOScale(new Vector3(1.3f, 1.3f, 1.3f), 0.2f));
        sequence.Append(transform.DOScale(new Vector3(0.8f, 0.8f, 0.8f), 0.1f));
        sequence.PrependCallback(() => GlobalParticleSystem.Play(starsEffectPrefab, starsEffectTransform));
        sequence.Append(transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.1f));
        sequence.Append(transform.DOScale(Vector3.one, 0.05f));
    }
}