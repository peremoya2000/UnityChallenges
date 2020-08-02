using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficulyButton : MonoBehaviour
{
    [Range(0.1f,5.0f)]
    public float difficulty;
    private Button _button;
    private GameManager manager;
    // Start is called before the first frame update
    void Start()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(SetDifficulty);

        manager = FindObjectOfType<GameManager>();
    }

    void SetDifficulty()
    {
        manager.StartGame(difficulty);
    }
}
