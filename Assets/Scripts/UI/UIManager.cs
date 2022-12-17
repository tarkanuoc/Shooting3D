using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject _UIPlayer;
    [SerializeField] private GameObject _UIGun;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //  yield return new WaitForEndOfFrame();
        yield return new WaitForSeconds(0.1f);
        _UIPlayer.SetActive(true);
        _UIGun.SetActive(true);
    }

    public void ActiveUI()
    {
    
    }
}
