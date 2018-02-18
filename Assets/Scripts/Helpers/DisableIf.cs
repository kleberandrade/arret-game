using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using ANET.Networking;

public enum DisableIfEnum
{
    VR, Mobile
}

public class DisableIf : MonoBehaviour {

    [SerializeField]
    private DisableIfEnum disableIf;

	void Awake () {
        if(disableIf == DisableIfEnum.VR) // Se estiver selecionado para desabilitar quando for VR
        {
            if (Networking.Instance.Host) // Se for VR
            {
                gameObject.SetActive(false); // Desabilita
            }
        }
        else if (disableIf == DisableIfEnum.Mobile) // Se estiver selecionado para desabilitar quando for Mobile
        {
            if (!Networking.Instance.Host) // Se for Mobile
            {
                gameObject.SetActive(false); // Desabilita
            }
        }
    }
}
