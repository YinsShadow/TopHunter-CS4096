using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashAnim : MonoBehaviour
{
    private ParticleSystem ps;

    private void Awake() {
        ps = GetComponent<ParticleSystem>();
    }

    private void Update() {
        if (ps && !ps.IsAlive()) { //Clean up  particles after death!
            DestroySelf();
        }
    }
    
    public void DestroySelf() { //Delete thyself
        Destroy(gameObject);
    }
}
