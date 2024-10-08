using System.Collections;
using UnityEngine;

public class Destroyer : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(DestroyClone());
    }

    IEnumerator DestroyClone()
    {
        yield return new WaitForSeconds(50f);
        Destroy(this.gameObject);
    }
}
