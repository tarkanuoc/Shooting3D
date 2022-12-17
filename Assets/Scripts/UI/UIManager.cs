using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _UIPlayer;
    [SerializeField] private GameObject _UIGun;

    [SerializeField] private GameObject _gameOverPanel;
    [SerializeField] private GameObject _gameWinPanel;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //  yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(0.1f);
        _UIPlayer.SetActive(true);
        _UIGun.SetActive(true);
    }

    public void OnPlayerDied()
    {
        StopGame();
        _gameOverPanel.SetActive(true);
    }

    public void OnMissionCompleted()
    {
        StopGame();
        _gameWinPanel.SetActive(true);
    }

    private void StopGame()
    {
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
}
