using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructible : MonoBehaviour {
    public GameObject Debris;

    public float _hp = 100f;
    public float HP {
        get
        {
            return _hp;
        }
        set
        {
            _hp = value;
            if (_hp <= 0)
            {
                Destruct();
            }
        }
    }
	
	void Destruct()
    {
        if (Debris != null)
        {
            Instantiate(Debris, gameObject.transform.position, gameObject.transform.rotation, transform.parent);
        }
        Destroy(gameObject);
    }
}
