using UnityEngine;
using System.Collections;

public class SelfDestruction : MonoBehaviour {
    [SerializeField]
    private int lifetime = 2;
	// Use this for initialization
	void Start () {
        Invoke("Destroy", lifetime);
	}


    void Destroy() {
        Destroy(gameObject);
    }
}
