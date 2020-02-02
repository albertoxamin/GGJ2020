using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public void Respawn_Button()
    {
        GameManager.Instance.Respawn();
    }

    public void Quit()
    {
        Application.Quit();
    }
}
