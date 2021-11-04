using UnityEngine;

namespace SergeyPchelintsev.Expedito.Controllers.RideScene.Sectors
{
    public class RandomObjectRotator : MonoBehaviour
    {
        private void Start()
        {
            transform.rotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
        }
    }
}