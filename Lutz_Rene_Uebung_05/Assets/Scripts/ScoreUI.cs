using TMPro;
using UnityEngine;

public class ScoreUI : MonoBehaviour
{
    private TextMeshProUGUI _scoreUI;


    private void Awake()
    {
        _scoreUI = GetComponent<TextMeshProUGUI>();
    }
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _scoreUI.text = string.Format("Score:{0}", Score.GetScore());
    }
}
