using System.Collections.Generic;
using UnityEngine;

namespace SergeyPchelintsev.Expedito.Controllers.RideScene.Sectors
{
    public class Sector : MonoBehaviour
    {
        [SerializeField] private List<GameObject> props;
        [SerializeField] private AnimationCurve probabilitySpawn;
        [SerializeField] private float chanceToSaveProp = 0.75f;
        
        public AnimationCurve ProbabilitySpawn => probabilitySpawn;

        private void Awake()
        {
            foreach (var prop in props)
            {
                if (Random.value > chanceToSaveProp)
                {
                    Destroy(prop);
                }
            }
        }
    }
}