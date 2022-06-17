using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleStart : MonoBehaviour
{
    [SerializeField] GameObject _firstText;
    [SerializeField] GameObject _firstButton;
    [SerializeField] GameObject _stageSelect;
    [SerializeField] GameObject _stageSelectButton;

    void Start()
    {
        _firstText.SetActive(true);
        _firstButton.SetActive(true);
        _stageSelect.SetActive(false);
        _stageSelectButton.SetActive(false);
    }
}
