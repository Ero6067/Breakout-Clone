using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Menu : MonoBehaviour
{
    public GameObject mainMenuFirstButton, pauseFirstButton, optionsFirstButton, optionsClosedButton;

    // Start is called before the first frame update
    private void Start()
    {
        EventSystem.current.SetSelectedGameObject(null);

        EventSystem.current.SetSelectedGameObject(mainMenuFirstButton);
    }

    // Update is called once per frame
    private void Update()
    {
    }
}