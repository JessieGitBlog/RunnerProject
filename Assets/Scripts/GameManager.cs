using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;

    [SerializeField] private Button _startButton;

    [SerializeField] private TMP_Text _count;

    [SerializeField] private TMP_Text _timer;
    
    public bool isPlay;

    private int min;
    private int sec;
    
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                return null;
            }

            return instance;
        }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }

        _startButton.onClick.AddListener(OnClickStartButton);
        Initialize();
    }

    private void Initialize()
    {
        _startButton.gameObject.SetActive(true);
        _count.gameObject.SetActive(false);
    }

    private void OnClickStartButton()
    {
        StartCoroutine(CoCount());
        _startButton.gameObject.SetActive(false);
        _count.gameObject.SetActive(true);
    }

    IEnumerator CoCount()
    {
        yield return new WaitForSeconds(1f);
        _count.text = "2";
        yield return new WaitForSeconds(1f);
        _count.text = "1";
        yield return new WaitForSeconds(1f);
        _count.text = "START!";
        isPlay = true;
        StartCoroutine(CoTimer());
        yield return new WaitForSeconds(1f);
        _count.gameObject.SetActive(false);
    }

    IEnumerator CoTimer()
    {
        while (isPlay)
        {
            yield return new WaitForSeconds(1f);
            sec++;
            
            if (sec == 60)
            {
                min++;
                sec = sec - 60;
            }

            _timer.text = string.Format("{0:D2} : {1:D2}", min, sec);
        }
    }

    private void OnDestroy()
    {
        isPlay = false;
    }
}