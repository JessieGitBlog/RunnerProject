using System.Collections;
using TMPro;
using UnityEngine;

public class LevelDistance : MonoBehaviour
{
    public TMP_Text distanceDisplay;
    public int disRun;
    public bool addingDis = true;

    private void Update()
    {
        if (GameManager.Instance.isPlay)
        {
            if (addingDis == false)
            {
                addingDis = true;
                StartCoroutine(AddingDis());
            }
        }
    }

    private IEnumerator AddingDis()
    {
        disRun += 1;
        distanceDisplay.text = disRun.ToString();
        yield return new WaitForSeconds(0.5f);
        addingDis = false;
    }
}