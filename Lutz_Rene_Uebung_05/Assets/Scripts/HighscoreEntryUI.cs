using TMPro;
using UnityEngine;

public class HighscoreEntryUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _position;
    [SerializeField] private TextMeshProUGUI _score;

    public virtual HighscoreEntryUI Init(string position, string score)
    {
        _position.text = position;
        _score.text = score;

        return this;
    }
}
