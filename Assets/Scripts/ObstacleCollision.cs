using System.Collections;
using UnityEngine;

public class ObstacleCollision : MonoBehaviour
{
    private Animator _animator;
    private bool isCrash;
    private GameObject player;
    private Vector3 stopPoint;

    private void OnTriggerEnter(Collider other)
    {
        GameManager.Instance.isPlay = false;
        isCrash = true;
        player = other.gameObject;
        player.GetComponent<PlayerMovement>().enabled = false;
        stopPoint = player.transform.position;
        _animator = other.GetComponentInChildren<Animator>();
        player.GetComponent<CapsuleCollider>().enabled = false;
        _animator.Play("Stumble Backwards");
        StartCoroutine(AnimationCheck());
    }

    IEnumerator AnimationCheck()
    {
        while (isCrash)
        {
            yield return new WaitForSeconds(0.25f);
            var animTime = _animator.GetCurrentAnimatorStateInfo(0).normalizedTime;
            if (animTime >= 1.0f)
            {
                isCrash = false;
                player.GetComponent<CapsuleCollider>().enabled = true;
                player.GetComponent<PlayerMovement>().enabled = true;
                Destroy(gameObject);
                player.transform.position = new Vector3(stopPoint.x, 1f, stopPoint.z);
                GameManager.Instance.isPlay = true;
            }
        }
    }
}