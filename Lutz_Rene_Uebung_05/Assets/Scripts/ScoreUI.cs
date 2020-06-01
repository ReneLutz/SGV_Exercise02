using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI _scoreUI;

    private void Awake()
    {
        _scoreUI = GetComponent<TextMeshProUGUI>();
    }

    void Start() { }

    void Update()
    {
        _scoreUI.text = string.Format("Score: {0}", Score.GetScore());
    }
}
