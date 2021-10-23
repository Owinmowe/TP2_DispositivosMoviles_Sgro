using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    SpinningTop top;
    Vector3 startingPosition;
    [SerializeField] float offsetToCenter = 1f;
    private void Awake()
    {
        top = GetComponent<SpinningTop>();
    }

    private void Start()
    {
        startingPosition = transform.position;
        StartCoroutine(RandomMovement());
    }
    
    IEnumerator RandomMovement() 
    {
        while (true)
        {
            float t = 0;
            while (Vector3.Distance(startingPosition, transform.position) > offsetToCenter)
            {
                Vector3 dir = startingPosition - transform.position;
                t += Time.deltaTime;
                top.Move(dir);
                yield return null;
            }
            yield return null;
        }
    }
}
