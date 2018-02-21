using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ClientMaturity
{
    MATURITY_ALPHA, MATURITY_BETA, MATURITY_RC, MATURITY_STABLE
}

public class SemVer : MonoBehaviour {
    /**
     * MAJOR version when you make incompatible API changes,
     * MINOR version when you add functionality in a backwards-compatible manner, and
     * PATCH version when you make backwards-compatible bug fixes.
     */
    [SerializeField]
    [Tooltip("Client major version, when you make incompatible API changes.")]
    private uint major = 0;
    [SerializeField]
    [Tooltip("Client minor version, when you add functionality in a backwards-compatible manner.")]
    private uint minor = 1;
    [SerializeField]
    [Tooltip("Client patch version, when you make backwards-compatible bug fixes.")]
    private uint patch = 0;
    [SerializeField]
    [Tooltip("Client maturity level, defines in a verbose way how much stable is the client. How far the client is from being a prototype or being a release version.")]
    private ClientMaturity maturity;

    [SerializeField]
    private float width = 100f;
    [SerializeField]
    private float height = 20f;

    public string SEMVER
    {
        get
        {
            string mat = "";
            switch (maturity)
            {
                case ClientMaturity.MATURITY_ALPHA:
                    mat = "alpha";
                    break;
                case ClientMaturity.MATURITY_BETA:
                    mat = "beta";
                    break;
                case ClientMaturity.MATURITY_RC:
                    mat = "release_candidate";
                    break;
                case ClientMaturity.MATURITY_STABLE:
                    mat = "stable";
                    break;
                default:
                    mat = "alpha";
                    break;
            }
            return "Arret " + major+ "." + minor + "." + patch + " " + mat;
        }
    }

    private void OnGUI()
    {
        GUIStyle style = new GUIStyle();
        style.alignment = TextAnchor.LowerRight;
        style.fontStyle = FontStyle.Bold;
        style.fontSize = 12;
        style.richText = true;
        GUI.Label(new Rect(Screen.width - width - 5, Screen.height - height - 5, width, height), "<color=white>"+SEMVER+"</color>", style);
    }
}
