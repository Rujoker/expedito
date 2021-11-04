using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

namespace SergeyPchelintsev.Expedito.Configuration.Model
{
    [CreateAssetMenu(fileName = "CarConfig", menuName = "Expedito/CarConfig")]
    public class CarConfig : ScriptableObject
    {
        [SerializeField] private List<CarData> carContainerList;

        public CarData GetById(int id) => carContainerList.FirstOrDefault(item => item.identifier == id);
        public IEnumerable<CarData> CarContainerList => carContainerList;

        [System.Serializable]
        public class CarData
        {
            public int identifier;
            public float fuelCapacity;
            public float fuelPerSecond;
        }
    }
}