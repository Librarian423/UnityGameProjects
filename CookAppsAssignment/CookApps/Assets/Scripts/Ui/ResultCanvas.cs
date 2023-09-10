using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResultCanvas : MonoBehaviour
{
    [SerializeField] private GameObject result;
	[SerializeField] private TextMeshProUGUI text;
	// Start is called before the first frame update
	void Start()
    {
        UiManager.instance.SetResult(result, text);
    }
}
