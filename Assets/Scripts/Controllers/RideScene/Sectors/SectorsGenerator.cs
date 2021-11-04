using System.Collections;
using System.Linq;
using SergeyPchelintsev.Expedito.Configuration.View;
using SergeyPchelintsev.Expedito.Utils;
using UnityEngine;

namespace SergeyPchelintsev.Expedito.Controllers.RideScene.Sectors
{
    public class SectorsGenerator : MonoBehaviour
    {
        [SerializeField] private LocationViewConfig locationViewConfig;
        [SerializeField] private Transform sectorsRoot;
        [Min(3)]
        [SerializeField] private int count = 11;
        [SerializeField] private int width = 10;

        private Transform player;
        private Sector[,] spawnedSectors;
        private LocationViewConfig.LocationViewData locationViewData;
        
        private int currentX;
        private int currentY;
        
        private int highest;
        private int lowest;
        private int left;
        private int right;

        private void Start()
        {
            locationViewData = locationViewConfig.GetByType(LocationViewConfig.LocationType.forest);
            SpawnSectors();

            player = FindObjectOfType<CameraFollow>().Target;
            currentX = count / 2;
            currentY = count / 2;
            player.position = spawnedSectors[currentX, currentY].transform.position;

            highest = count - 1;
            right = count - 1;
            
            StartCoroutine(CheckPositionsCoroutine());
        }

        private void SpawnSectors()
        {
            spawnedSectors = new Sector[count, count];
            for (var x = 0; x < count; x++)
            {
                for (var y = 0; y < count; y++)
                {
                    var sector = Instantiate(GetRandomSector(), sectorsRoot);
                    sector.transform.position = new Vector3(x, 0, y) * width;
                    sector.transform.rotation = Quaternion.Euler(0, Random.Range(0, 4) * 90, 0);
                    spawnedSectors[x, y] = sector;
                }
            }
        }

        private Sector GetRandomSector()
        {
            var probabilities = locationViewData.sectorPrefabs
                .Select(sector => sector.ProbabilitySpawn.Evaluate(1f)).ToList();

            var value = Random.Range(0, probabilities.Sum());
            var sum = 0f;

            for (var i = 0; i < probabilities.Count; i++)
            {
                sum += probabilities[i];
                if (value < sum)
                {
                    return locationViewData.sectorPrefabs[i];
                }
            }
            return locationViewData.sectorPrefabs[Random.Range(0, locationViewData.sectorPrefabs.Length)];
        }
        
        private IEnumerator CheckPositionsCoroutine()
        {
            while (true)
            {
                CheckPositions();
                yield return new WaitForSeconds(1f);
            }
        }

        private void CheckPositions()
        {
            var centralPos = spawnedSectors[currentX, currentY].transform.position;
            
            if (player.position.z > centralPos.z + width / 2f) ShiftUp();
            if (player.position.z < centralPos.z - width / 2f) ShiftDown();
            if (player.position.x < centralPos.x - width / 2f) ShiftLeft();
            if (player.position.x > centralPos.x + width / 2f) ShiftRight();
        }

        private void ShiftUp()
        {
            var maxIndex = count - 1;

            CheckVerticalBorders();

            for (var x = 0; x < count; x++)
            {
                var position = spawnedSectors[x, highest].transform.position;
                spawnedSectors[x,lowest].transform.position = new Vector3(position.x, position.y, position.z + width);
            }
            
            currentY = (currentY != maxIndex ? currentY + 1 : 0);
            highest = lowest;
            lowest++;

        }

        private void ShiftDown()
        {
            var maxIndex = count - 1;
            
            CheckVerticalBorders();

            for (var x = 0; x < count; x++)
            {
                var position = spawnedSectors[x, lowest].transform.position;
                spawnedSectors[x, highest].transform.position = new Vector3(position.x, position.y, position.z - width);
            }
            
            currentY = (currentY != 0 ? currentY - 1 : maxIndex);
            lowest = highest;
            highest--;
        }

        private void ShiftLeft()
        {
            var maxIndex = count - 1;

            CheckHorizontalBorders();

            for (var y = 0; y < count; y++)
            {
                var position = spawnedSectors[left, y].transform.position;
                spawnedSectors[right, y].transform.position = new Vector3(position.x - width, position.y, position.z);
            }
            
            currentX =(currentX != 0 ? currentX - 1 : maxIndex);
            left = right;
            right--;
        }
        
        private void ShiftRight()
        {
            var maxIndex = count - 1;
            
            CheckHorizontalBorders();

            for (var y = 0; y < count; y++)
            {
                var position = spawnedSectors[right, y].transform.position;
                spawnedSectors[left, y].transform.position = new Vector3(position.x + width, position.y, position.z);
            }
            
            currentX = currentX != maxIndex ? currentX + 1 : 0;
            right = left;
            left++;
        }

        private void CheckHorizontalBorders()
        {
            if (right == -1 || left == count)
            {
                left = 0;
                right = count - 1;
            }
        }

        private void CheckVerticalBorders()
        {
            if (highest == -1 || lowest == count)
            {
                lowest = 0;
                highest = count - 1;
            }
        }
    }
}