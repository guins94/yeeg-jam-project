using System.Collections;
using System.Collections.Generic;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.UI;

public class BasicNetworkHandlerUI : MonoBehaviour
{
    [SerializeField] Button hostButton = null;
    [SerializeField] Button clientButton = null;
    
    private void Start()
    {
        hostButton.onClick.AddListener(() => {
            Debug.Log("HOST");
            NetworkManager.Singleton.StartHost();
            Hide();
        });

        clientButton.onClick.AddListener(() => {
            Debug.Log("HOST");
            NetworkManager.Singleton.StartClient();
            Hide();
        });
    }

    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
