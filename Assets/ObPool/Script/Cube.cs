using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float livingTime = 3.0f;

    public void ResetAfterTime()
    {
        StartCoroutine(Co_RestAfterTime(livingTime));
    }

    private IEnumerator Co_RestAfterTime(float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        Pool.Instance.ResetForPool(this);
    }
}
