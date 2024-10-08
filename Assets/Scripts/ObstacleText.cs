using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using Random = UnityEngine.Random;

public class ObstacleText : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler
{
    [SerializeField] private TMP_Text _text;

    private string missionStr;
    private int missionNum;
    private string[] randomStr = new string[] { "L", "R" };

    private void Awake()
    {
        missionStr = randomStr[Random.Range(0, 2)];
        missionNum = Random.Range(1, 6);
        _text.text = missionStr + missionNum;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (missionStr == "L")
        {
            if (eventData.button == PointerEventData.InputButton.Left)
            {
                missionNum--;
            }
            else if (eventData.button == PointerEventData.InputButton.Right)
            {
                missionNum++;
            }
        }
        else if (missionStr == "R")
        {
            if (eventData.button == PointerEventData.InputButton.Right)
            {
                missionNum--;
            }
            else if (eventData.button == PointerEventData.InputButton.Left)
            {
                missionNum++;
            }
        }

        _text.text = missionStr + missionNum;
        if (missionNum < 1)
        {
            Destroy(this.gameObject);
        }
    }
}