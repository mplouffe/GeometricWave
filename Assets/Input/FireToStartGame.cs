using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

/// <summary>
/// Simple script attached to the main menu that lets you press the fire button to start the game, and the escape button to quit.
/// </summary>
public class FireToStartGame : MonoBehaviour {

    public InputAction select;
    public InputAction cancel;

    private void OnEnable()
    {
        select.Enable();
        cancel.Enable();
    }

    private void OnDisable()
    {
        select.Disable();
        cancel.Disable();
    }

    // Update is called once per frame
    void Update () {
        if(select.triggered)
        {
            SceneManager.LoadScene(1);
        }

        if(cancel.triggered)
        {
            Application.Quit();
        }
    }



}
