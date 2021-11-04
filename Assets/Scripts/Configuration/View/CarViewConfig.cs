using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityStandardAssets.Vehicles.Car;

namespace SergeyPchelintsev.Expedito.Configuration.View
{
    [CreateAssetMenu(fileName = "CarViewConfig", menuName = "Expedito/CarViewConfig")]
    public class CarViewConfig : ScriptableObject
    {
        [SerializeField] private List<CarViewData> carContainerList;

        public CarViewData GetById(int id) => carContainerList.FirstOrDefault(item => item.identifier == id);
        public IEnumerable<CarViewData> CarContainerList => carContainerList;

        [System.Serializable]
        public class CarViewData
        {
            public int identifier;
            public string carName;
            public string carDescription;
            public Sprite icon;
            public CarController carPrefab;
        }
    }
}