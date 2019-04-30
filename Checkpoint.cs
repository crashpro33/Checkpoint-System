using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour {

    public HealthManager healthManager;

    public Renderer rend;

    public Material checkOff;
    public Material checkOn;

	// Use this for initialization
	void Start () {
        healthManager = FindObjectOfType<HealthManager>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void CheckpointOn() {
        Checkpoint[] checkpoints = FindObjectsOfType<Checkpoint>();
        foreach(Checkpoint cp in checkpoints) {
            cp.CheckpointOff();
        }
        rend.material = checkOn;
    }

    public void CheckpointOff() {
        rend.material = checkOff;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.tag.Equals("Player")) {
            Vector3 spawn = transform.position;
            spawn.y += 2;
            healthManager.SetSpawnPoint(spawn);
            CheckpointOn();
        }
    }
}
