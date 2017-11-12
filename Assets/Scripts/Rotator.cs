using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour {
    /*
     * PUBLIC Class Variables
     */

    /*
    * PRIVATE Class Variables
    */

    /*
    * UNITY Methods
    */

    void Update () {
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
	}

    /*
     * PRIVATE Class Methods
     */

    /*
     * PUBLIC Class Methods
     */
}