using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSetter : MonoBehaviour
{
    public void ConnectNetwork()
    {
        NetworkManager.instance.Connect();
    }
}
