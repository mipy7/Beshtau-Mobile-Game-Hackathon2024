using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudController : MonoBehaviour
{
	public int cloudCount = 1;

	[SerializeField]
	private GameObject cloudPrefub;

	// Start is called before the first frame update
	void Start()
    {
        for(int i = 0; i < cloudCount; i++)
        {
            Instantiate(cloudPrefub);
        }
    }
}
