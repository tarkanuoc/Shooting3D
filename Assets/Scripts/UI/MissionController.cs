using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MissionController : MonoBehaviour
{
    [SerializeField] private UIManager _uiManager;
    [SerializeField] private Transform _exitDoor;
    [SerializeField] private Gate _gate;
    public int requiredKill;
    public TextMeshProUGUI txtMission;
    private int currentKill;
    private bool _isPlayerExit;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(VerifyMissions());
    }

    IEnumerator VerifyMissions()
    {
        yield return VerifyZombieKill();
        yield return VerifyPlayerExit();
        _uiManager.OnMissionCompleted();
    }

    IEnumerator VerifyZombieKill()
    {
        currentKill = 0;
        txtMission.text = $"Kill {requiredKill} zombies";
        yield return new WaitUntil(() => currentKill >= requiredKill);
    }

    IEnumerator VerifyPlayerExit()
    {
        txtMission.text = $"Find exit door";
        _gate.onPlayerEnter.AddListener(OnPlayerExit);
        yield return new WaitUntil(()=>_isPlayerExit);
        _gate.onPlayerEnter.RemoveListener(OnPlayerExit);
    }

    public void OnZombieKilled(GameObject zombie)
    {
        currentKill++;
        Debug.Log("======== current Killed = " + currentKill);
    }

    private void OnPlayerExit()
    {
        Debug.Log("=========== On Player Exit");
        _isPlayerExit = true;
    }

    private bool IsPlayerExit()
    {
        float distance = Vector3.Distance(Player.Instance.PlayerFoot.position, _exitDoor.position);
        return distance < 1f;
    }
}
