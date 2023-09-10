using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BattleInfoSideButton : MonoBehaviour
{
    public void NextStage()
    {
		UiManager.instance.OnClickBattleInfoNext();
	}

    public void PrevStage()
    {
		UiManager.instance.OnClickBattleInfoPrev();
	}
}
