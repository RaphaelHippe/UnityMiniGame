using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    /*
     * PUBLIC Class Variables
     */
    public GameObject player;

    /*
     * PRIVATE Class Variables
     */

    private Vector3 offset;

    /*
     * UNITY Methods
     */

    private void Start () {
        offset = transform.position - player.transform.position;
    }
	
	private void LateUpdate() {
        transform.position = player.transform.position + offset;
    }

    /*
     * PRIVATE Class Methods
     */

    /*
     * PUBLIC Class Methods
     */
}
