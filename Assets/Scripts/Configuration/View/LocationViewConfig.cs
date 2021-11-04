using System.Collections.Generic;
using System.Linq;
using SergeyPchelintsev.Expedito.Controllers.RideScene.Sectors;
using UnityEngine;

namespace SergeyPchelintsev.Expedito.Configuration.View
{
    [CreateAssetMenu(fileName = "LocationViewConfig", menuName = "Expedito/LocationViewConfig")]
    public class LocationViewConfig : ScriptableObject
    {
        [SerializeField] private List<LocationViewData> locationList;

        public LocationViewData GetByType(LocationType locationType) => locationList.FirstOrDefault(item => item.type == locationType);
        public IEnumerable<LocationViewData> LocationList => locationList;

        [System.Serializable]
        public class LocationViewData
        {
            public LocationType type;
            public Sector[] sectorPrefabs;
        }

        public enum LocationType
        {
            forest
        }
    }
}