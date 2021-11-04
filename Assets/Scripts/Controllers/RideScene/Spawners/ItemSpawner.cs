using System.Collections;
using SergeyPchelintsev.Expedito.Controllers.Bonuses;
using SergeyPchelintsev.Expedito.Controllers.RideScene;
using SergeyPchelintsev.Expedito.Utils;
using UnityEngine;
using Random = UnityEngine.Random;

namespace SergeyPchelintsev.Expedito.Controllers.Spawners
{
    public class ItemSpawner : MonoBehaviour
    {
        [SerializeField] private Transform itemsRoot;
        
        [Header("Prefabs")]
        [SerializeField] private ToolboxController toolboxPrefab;
        [SerializeField] private CanisterBonusController canisterPrefab;
        [SerializeField] private TimerBonusController timerPrefab;
        
        [Header("Random params")]
        [SerializeField] private float maxPositionOffset = 40f;
        [SerializeField] private float minTimeToRandom = 10f;
        [SerializeField] private float maxTimeToRandom = 25f;

        private CameraFollow cameraFollow;
        
        public void Start()
        {
            cameraFollow = FindObjectOfType<CameraFollow>();
            
            StartCoroutine(SpawnCanister());
            StartCoroutine(SpawnTimer());
        }

        private IEnumerator SpawnCanister()
        {
            yield return new WaitForSeconds(Random.Range(minTimeToRandom, maxTimeToRandom));
            CreateBonusGO(canisterPrefab);
            StartCoroutine(SpawnCanister());
        }
        
        private IEnumerator SpawnTimer()
        {
            yield return new WaitForSeconds(Random.Range(minTimeToRandom, maxTimeToRandom));
            CreateBonusGO(timerPrefab);
            StartCoroutine(SpawnTimer());
        }

        private void CreateBonusGO(BaseBonusController bonusController)
        {
            var timer = Instantiate(bonusController.gameObject, itemsRoot);
            var dx = Random.Range(-maxPositionOffset, maxPositionOffset);
            var dz = Random.Range(-maxPositionOffset, maxPositionOffset);
            var position = cameraFollow.Target.position;
            timer.transform.position = new Vector3(position.x + dx, itemsRoot.position.y + bonusController.SpawnYOffset, position.z + dz);
        }
    }
}