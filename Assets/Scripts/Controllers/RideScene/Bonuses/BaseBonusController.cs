using System;
using System.Collections;
using Model;
using SergeyPchelintsev.Expedito.Model;
using SergeyPchelintsev.Expedito.Utils.DI;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

namespace SergeyPchelintsev.Expedito.Controllers.Bonuses
{
    public abstract class BaseBonusController : MonoBehaviour
    {
        [SerializeField] private float spawnYOffset;
        [SerializeField] private float timeToLive = 180f;

        protected IGameMediator gameMediator;

        public float SpawnYOffset => spawnYOffset;

        private void Awake()
        {
            var root = DependencyInjector.Root;
            gameMediator = root.Get<IGameMediator>();
        }

        private void Start()
        {
            StartCoroutine(DestroyItem());
        }

        private IEnumerator DestroyItem()
        {
            yield return new WaitForSeconds(timeToLive);
            Destroy(gameObject);
        }
        
        private void OnCollisionEnter(Collision collision)
        {
            if (!collision.gameObject.GetComponent<CarController>()) return;
            Sound.Get.PlayBonusPick();
            ApplyBonus();
            
            Destroy(gameObject);
        }

        protected abstract void ApplyBonus();
    }
}