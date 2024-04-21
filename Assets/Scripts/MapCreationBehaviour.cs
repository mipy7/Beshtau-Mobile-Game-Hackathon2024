using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class MapCreationBehaviour : MonoBehaviour
{
	[Header("Ground")]
	[SerializeField] private GameObject ground1;
	[SerializeField] private GameObject ground2;
	[SerializeField] private GameObject ground3;
	[SerializeField] private GameObject ground4;
	[SerializeField] private GameObject ground5;


	[Header("Barrier")]
	[SerializeField] private GameObject barrier;

	[Header("Bonuses")]
	[SerializeField] private GameObject shieldBonus;
	[SerializeField] private GameObject healthBonus;
	[SerializeField] private GameObject doubleBonus;

	[Header("Danger")]
	[SerializeField] private GameObject dangerSpikes;
	[SerializeField] private GameObject dangerWire;
	[SerializeField] private GameObject dangerMovingSpikes;
	[SerializeField] private GameObject dangerArc;
	[SerializeField] private GameObject dangerTransformer;

	[Header("Collectables")]
	[SerializeField] private GameObject scoreCollect;
	[SerializeField] private GameObject lifeCollect;

	[Header("WorkStations")]
	[SerializeField] private GameObject workStation1;
	[SerializeField] private GameObject workStation2;
	[SerializeField] private GameObject workStation3;

	[Header("Platform")]
	[SerializeField] private GameObject platform;

	[Header("Win Flag")]
	[SerializeField] private GameObject winFlag;

    private String[] map = { 
			"                                                                                                                                        0",
			"                                                                                                                       ? FP C           0",
			"                                                                                                                      *2333334*         0",
			"                                                                                                                      =    *  =  *      0",
			"                                                                                                                   R 2    ?=   4 = *    0",
			"                                                                                          *                     P  = 5  E =    5   =    0",
			"                                                                  * *  Y P*        F Z R E*      * C D Y *      =    5  =  =   5     D W0",
			"                                                                  * 2333334     ?2333333334      *23333334?      *2 *5= *  *  =5   *23340",
			"                                                                 *2411111114  * =5   P    5    *B25  P * 54*   *245 =5  =  =      C211110",
			"                                                             *   211      11  = *5   = =  5   *241 *2334  54   2115  5=         *2411111 ",
			"                                                    *     *  =         A        =14  * * =  * 255  25555D  * B21111= * *24BB C 241111111 ",
			"                                                    = *   = ?      R   =   *   = 5   = =  X =    Z * * *  233411111233341123334111111111 ",
			"                                                 D    =  4  =      = *   * =     54=  * *23333333333333334111111111111111111111111111111 ",
			"                                   P  ?        C24* =BRB 5  C 24     =   =   C2* 55  233411111111111111111111111111111111111111111111111 ",
			"                                   =  =   E B*24114  234*D*2345  F = B E B  2414*   21111111111111111111111111111111111111111111111      ",
			"                           *          *  23334111114 55523455   233333333334111123341111111111111111111111111111111111111111111          ",
			"                        E  *C         = A51111111115 * * * *  231111111111111111111111111111111111111111                                 ",
			"0                      233334 ?     2 R =111111111112333333334111111111111111111111111111111111111111                                    ",
			"0                    *25      =  *B25 = *5111111111111111111111111111111111111111111111111111111                                         ",
			"0             *      25 A       23415 Z =1111111111111111111111111111111111111111111111                                                  ",
			"0        R    = *   25  =    F 211111233411111111111111111111111111111                                                                   ",
			"0    *   =      =  D     *  23411111111111111111111111111                                                                                ",
			"0 *  =            2334   =  51111111111111111111111111                                                                                   ",
			"0 = *   *  *  *B*21115BB   21111111111111111111111                                                                                       ",
			"0   = C =  =  23411111233341111111111111111111                                                                                           ",
			"0233334  =   2111111111111111111111111111                                                                                                ",
			"0111115*  Z 2111111111111111111111111                                                                                                    ",
			" 111111233341111111111111111111111111                                                                                                    ",
			" 11111111111111111111111                                                                                                                 ",
			" 11111111111111111111                                                                                                                    ",
			" 11111111111111111111                                                                                                                    ",
			" 11111111111111111111                                                                                                                    "};

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < map.Length; ++i) {
			for (int j = 0; j < map[i].Length; ++j)
			{
				Vector3 spawnPos = new Vector3(j * 2f, -i * 2f, 0);
				Vector3 shiftPos = Vector3.zero;
				GameObject spawnObject;
				float scale = 1;

				switch (map[i][j])
				{
					case '0': spawnObject = barrier; scale = 2f; break;

					case '1': spawnObject = ground1; scale = 1.8f; break;
					case '2': spawnObject = ground2; scale = 1.8f; break;
					case '3': spawnObject = ground3; scale = 1.8f; break;
					case '4': spawnObject = ground4; scale = 1.8f; break;
					case '5': spawnObject = ground5; scale = 1.8f; break;

					case 'A': spawnObject = shieldBonus; scale = 0.25f; break;
					case 'P': spawnObject = healthBonus; scale = 0.25f; break;
					case 'R': spawnObject = doubleBonus; scale = 0.25f; break;

					case 'B': spawnObject = dangerSpikes; scale = 0.8f; shiftPos = new Vector3(0, -0.5f, 0); break;
					case 'C': spawnObject = dangerWire; scale = 0.6f; shiftPos = new Vector3(0, -1.2f, 0); break;
					case 'D': spawnObject = dangerMovingSpikes; scale = 0.7f; shiftPos = new Vector3(0, 0.7f, 0); break;
					case 'E': spawnObject = dangerArc; shiftPos = new Vector3(0, -1.1f, 0); break;
					case 'F': spawnObject = dangerTransformer; scale = 0.45f; break;

					case '*': spawnObject = scoreCollect; scale = 0.7f; shiftPos = new Vector3(0, -0.4f, 0); break;
					case '?': spawnObject = lifeCollect; break;

					case 'X': spawnObject = workStation1; shiftPos = new Vector3(0, -0.7f, 0); break;
					case 'Y': spawnObject = workStation2; shiftPos = new Vector3(0, -0.7f, 0); break;
					case 'Z': spawnObject = workStation3; shiftPos = new Vector3(0, -0.7f, 0); break;

					case '=': spawnObject = platform; scale = 0.9f; shiftPos = new Vector3(0, 0.75f, 0); break;
					case 'W': spawnObject = winFlag; shiftPos = new Vector3(0, -0.2f, 0); break;

					default: spawnObject = null; break;
				}

				if (spawnObject != null)
				{
					GameObject obj = Instantiate(spawnObject, spawnPos, Quaternion.identity, transform);
					obj.transform.localScale = Vector3.one * scale;
					obj.transform.localPosition += shiftPos;
				}
			}
		}
    }
}
