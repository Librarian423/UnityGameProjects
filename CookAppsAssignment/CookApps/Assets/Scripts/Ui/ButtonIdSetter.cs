using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ButtonIdSetter : MonoBehaviour
{
    private List<CharacterSelectButton> buttons = new List<CharacterSelectButton>();

    // Start is called before the first frame update
    void Start()
    {
        var childButtons = GetComponentsInChildren<CharacterSelectButton>().ToList();
        int num = 0;
        foreach (var button in childButtons)
        {
            button.SetId(num);
            num++;
            buttons.Add(button);
        }
    }

    
}
