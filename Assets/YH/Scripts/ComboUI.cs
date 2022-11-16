using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboUI : MonoBehaviour
{
    WaitForSeconds dotFiveSeconds;
    private void Awake()
    {
        dotFiveSeconds = new WaitForSeconds(0.5f);
    }
    private void OnEnable()
    {
        StartCoroutine(ShotOut());
    }
    IEnumerator ShotOut()
    {
        yield return dotFiveSeconds;
        gameObject.SetActive(false);
    }
}
