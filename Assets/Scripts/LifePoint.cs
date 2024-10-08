using UnityEngine;
using UnityEngine.UI;

public class LifePoint : MonoBehaviour
{
    public Sprite emptyHeart;
    public Sprite heart;

    [SerializeField] private Image image;

    public bool isLife;

    public void Init()
    {
        image.sprite = heart;
        isLife = true;
    }

    public void OnDamaged()
    {
        image.sprite = emptyHeart;
        isLife = false;
    }

    public void OnHealing()
    {
        image.sprite = heart;
    }
}