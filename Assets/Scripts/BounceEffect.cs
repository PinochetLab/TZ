using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BounceEffect : MonoBehaviour
{
    Vector3 startScale;
    Vector3 objectInCellStartScale;
    Vector3 startPos;
    [SerializeField] Transform objectInCell;
    
    private void Start()
    {

        startScale = transform.localScale;
        objectInCellStartScale = objectInCell.localScale;
        Bounce();
    }

    public void IncorrectAnswer()
    {
        Sequence Seq = DOTween.Sequence();
        float delay = 0.1f;
        Seq.Append(objectInCell.DOMove(objectInCell.position + Vector3.right * 5f, delay, true));
        Seq.Append(objectInCell.DOMove(objectInCell.position - Vector3.right * 7.5f, delay, true));
        Seq.Append(objectInCell.DOMove(objectInCell.position + Vector3.right * 10f, delay, true));
        Seq.Append(objectInCell.DOMove(objectInCell.position - Vector3.right * 10f, delay, true));
        Seq.Append(objectInCell.DOMove(objectInCell.position + Vector3.right * 7.5f, delay, true));
        Seq.Append(objectInCell.DOMove(objectInCell.position - Vector3.right * 5, delay, true));
        Seq.Append(objectInCell.DOMove(objectInCell.position, delay, true));
    }

    public void Bounce()
    {
        Sequence Seq = DOTween.Sequence();
        Seq.Append(transform.DOScale(Vector3.zero, 0f));
        Seq.Append(transform.DOScale(1.1f * startScale, 0.4f));
        Seq.Append(transform.DOScale(0.95f * startScale, 0.2f));
        Seq.Append(transform.DOScale(1f * startScale, 0.1f));
    }

    public void CorrectAnswer()
    {
        Sequence Seq = DOTween.Sequence();
        Seq.Append(objectInCell.DOScale(0.85f * objectInCellStartScale, 0.1f));
        Seq.Append(objectInCell.DOScale(1.1f * objectInCellStartScale, 0.3f));
        Seq.Append(objectInCell.DOScale(0.95f * objectInCellStartScale, 0.2f));
        Seq.Append(objectInCell.DOScale(1f * objectInCellStartScale, 0.1f));
    }
}
