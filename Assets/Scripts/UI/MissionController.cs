using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    public int requiredKill;
    public TextMeshProUGUI txtMission;

    private int currentKill;
        
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(VerifyMissions());
    }

    IEnumerator VerifyMissions()
    {
        yield return VerifyZombieKill();
        _uiManager.OnMissionCompleted();
    }

    IEnumerator VerifyZombieKill()
    {
        currentKill = 0;
        txtMission.text = $"Kill {requiredKill} zombies";
        yield return new WaitUntil(() => currentKill >= requiredKill);
    }


    public void OnZombieKilled(GameObject zombie)
    {
        currentKill++;
        Debug.Log("======== current Killed = " + currentKill);
    }

   
}
