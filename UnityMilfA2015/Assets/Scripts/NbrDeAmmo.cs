using UnityEngine;
using System.Collections;

public class NbrDeAmmo : MonoBehaviour {

    public int modifierPositionXTest;
    public int modifierPositionYTest;
    public GUIStyle guiStylePoliceNbrAmmo;

    private int multiplicateurSelonLaDirection = 1;

    public int munition = 20;
    
    void OnGUI()
    {
        munition = this.GetComponent<PlayerShoot>().munition;

        //On doit verifer dans quel sens le joueur va
        if (this.GetComponent<PlayerController>().facingRight)
        {
            multiplicateurSelonLaDirection = 1;
        }
        else
        {
            multiplicateurSelonLaDirection = -1;
        }

        Vector3 getPixelPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
        getPixelPos.y = Screen.height - getPixelPos.y;

        GUI.Label(new Rect((getPixelPos.x - (modifierPositionXTest * multiplicateurSelonLaDirection * gameObject.transform.localScale.x)), getPixelPos.y - (modifierPositionYTest * gameObject.transform.localScale.y), 100f, 100f), munition.ToString(), guiStylePoliceNbrAmmo);

    }


}
