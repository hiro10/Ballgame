using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameClearDetector : MonoBehaviour
{
    [SerializeField] private Hole holeRed;
    [SerializeField] private Hole holeBlue;
    [SerializeField] private Hole holeGreen;

    [SerializeField] GameObject gameObject;

    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void OnGUI()
    {
        if (holeRed.IsHolding() && holeGreen.IsHolding() && holeBlue.IsHolding())
        {
            GUI.Label(new Rect(50, 50, 100, 30), "GAME CLEAR!!");
            StartCoroutine(FindRetryBurron());
        }
    }
    IEnumerator FindRetryBurron()
    {
        yield return new WaitForSeconds(1f);
        gameObject.SetActive(true);
    }

    public void OnButton()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
