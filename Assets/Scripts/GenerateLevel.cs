using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GenerateLevel : MonoBehaviour
{
    public GameObject[] section;
    public int zPos = 140;
    public bool creatingSection = false;
    public int secNum;

    private void Update()
    {
        if (creatingSection == false)
        {
            creatingSection = transform;
            StartCoroutine(GenerateSection());
        }
    }
    IEnumerator GenerateSection()
    {
        secNum = Random.Range(0, 3);
        Instantiate(section[secNum], new Vector3(-3.5f, 0f, zPos), Quaternion.Euler(0f,90f,0f));
        zPos += 80;
        yield return new WaitForSeconds(10f);
        creatingSection = false;
    }
}