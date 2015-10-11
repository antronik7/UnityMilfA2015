using UnityEngine;
using System.Collections;

public class SpawnDisquettes : MonoBehaviour 
{
    public GameObject Pixel;
    public GameObject Pixel1;
    public GameObject Pixel2;

    public GameObject[] Positions;

	void Start () 
    {
        int Index = Random.Range(0, Positions.Length);

        switch (Random.Range(0, 45))
        {
            case 0:
            case 1:
            case 2:
            case 3:
            case 4:
            case 5:
                Instantiate(Pixel, Positions[Index].transform.position, Quaternion.identity);
                break;
            case 6:
            case 7:
            case 8:
                Instantiate(Pixel1, Positions[Index].transform.position, Quaternion.identity);
                break;
            case 9:
                Instantiate(Pixel2, Positions[Index].transform.position, Quaternion.identity);
                break;
            default:
                break;
        }
	}
}
