using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HighscoreTable : MonoBehaviour
{
    [SerializeField] private HighscoreEntryUI _entryPrefab;
    [SerializeField] private TextMeshProUGUI _scoreUI;

    private List<HighscoreEntryUI> _tableEntries = new List<HighscoreEntryUI>();

    private readonly string JSON_KEY = "Highscores{0}";
   
    private int[] _scores = new int[5];

    private Transform _transform;

    private void Awake()
    {
        _transform = transform;

        LoadAndSortHighscoreTable();
        
        int currentScore = Score.GetScore();
        Score.Reset();

        _scoreUI.text = string.Format("Score: {0}", currentScore);

        // Write new Highscore and save list
        if (currentScore > _scores[0])
        {
            _scores[0] = currentScore;

            Array.Sort(_scores);

            SaveHighscoreTable();
        }

        for (int i = _scores.Length - 1; i >= 0; i--)
        {
            AddEntry(_scores.Length - i, _scores[i]);
        }
    }

    private void LoadAndSortHighscoreTable()
    {
        for (int i = 0; i < _scores.Length; i++)
        {
            _scores[i] = PlayerPrefs.GetInt(String.Format(JSON_KEY, i), 0);
        }
        Array.Sort(_scores);
    }

    private void SaveHighscoreTable()
    {
        for (int i = 0; i < _scores.Length; i++)
        {
            PlayerPrefs.SetInt(String.Format(JSON_KEY, i), _scores[i]);
        }
        PlayerPrefs.Save();
    }

    private void AddEntry(int position, int score)
    {
        HighscoreEntryUI entry = Instantiate(_entryPrefab, _transform);
        entry.Init(string.Format("{0}.", position.ToString()), score.ToString());

        entry.transform.SetParent(_transform);
        
        _tableEntries.Add(entry);
    }

}
