using SergeyPchelintsev.Expedito.Controllers.RideScene;
using SergeyPchelintsev.Expedito.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SergeyPchelintsev.Expedito.Controllers.Spawners
{
    public class CheckpointSpawner : MonoBehaviour
    {
        [SerializeField] private Transform root;
        [SerializeField] private CheckpointController checkpointPrefab;
        [SerializeField] private float maxPositionOffset = 200f;

        private CameraFollow cameraFollow;
        
        public void Start()
        {
            cameraFollow = FindObjectOfType<CameraFollow>();
            SpawnCheckpoint();
        }

        private void SpawnCheckpoint()
        {
            var checkpoint = Instantiate(checkpointPrefab, root);
            var dx = Random.Range(-maxPositionOffset, maxPositionOffset);
            var dz = Random.Range(-maxPositionOffset, maxPositionOffset);
            var position = cameraFollow.Target.position;
            checkpoint.transform.position = new Vector3(position.x + dx, root.position.y, position.z + dz);

            checkpoint.OnCheckpointTaken = SpawnCheckpoint;
        }
    }
}