using DG.Tweening;
using UnityEngine;

public class Flag : MonoBehaviour
{
    void OnEnable()
    {
        transform.localScale = Vector3.zero;
        Sequence sequence = DOTween.Sequence();
        sequence.AppendInterval(1);
        sequence.Append(transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f), 0.3f));
        sequence.Append(transform.DOScale(Vector3.one, 0.2f));
        sequence.Append(transform.DOPunchScale(new Vector3(0.2f, 0.2f, 0.2f), 0.3f));
        
    }
}
