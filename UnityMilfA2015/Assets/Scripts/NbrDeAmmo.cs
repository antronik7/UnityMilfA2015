using UnityEngine;
using System.Collections;

public class NbrDeAmmo : MonoBehaviour {

    public int modifierPositionXTest;
    public int modifierPositionYTest;
    public GUIStyle guiStylePoliceNbrAmmo;

    private int multiplicateurSelonLaDirection = 1;

    public int munition = 20;

    public GameObject iconePostionDuJoueur;
    public float modifierPositionXCicone;
    public float modifierPositionYCicone = 9.5f;
    
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

            //Pour le nombre d'ammo sur la tete du personnage
            Vector3 getPixelPos = Camera.main.WorldToScreenPoint(gameObject.transform.position);
            getPixelPos.y = Screen.height - getPixelPos.y;

            GUI.Label(new Rect((getPixelPos.x - (modifierPositionXTest * multiplicateurSelonLaDirection * gameObject.transform.localScale.x)), getPixelPos.y - (modifierPositionYTest * gameObject.transform.localScale.y), 100f, 100f), munition.ToString(), guiStylePoliceNbrAmmo);

            //Pour le nombre d'ammo a coter de l'icone de position
            Vector3 getPixelPosIcone = Camera.main.WorldToScreenPoint(iconePostionDuJoueur.transform.position);
            getPixelPosIcone.y = Screen.height - getPixelPosIcone.y;

            GUI.Label(new Rect((getPixelPosIcone.x - (modifierPositionXCicone * iconePostionDuJoueur.transform.localScale.x)), getPixelPosIcone.y - (modifierPositionYCicone * iconePostionDuJoueur.transform.localScale.y), 100f, 100f), munition.ToString(), guiStylePoliceNbrAmmo);
    }


}
