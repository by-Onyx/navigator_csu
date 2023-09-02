using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.MoveLogic
{
    public class DrawPath : MonoBehaviour
    {
        [SerializeField] private LineRenderer line;
        private LineRenderer path;
        public static Dictionary<int, Vector3[]> lineSegments = new Dictionary<int, Vector3[]>();

        public void Init(Vector3 pos)
        {
            CreateBrush(pos);
        }

        public void DeleteLine()
        {
            Destroy(path);
        }

        private void CreateBrush(Vector3 pos)
        {
            path = Instantiate(line);
            path.SetPosition(0, pos);
            path.SetPosition(1, pos);
        }

        public void AddAPoint(Vector3 pointPos)
        {
            path.positionCount++;
            int positionIndex = path.positionCount - 1;
            path.SetPosition(positionIndex, pointPos);
        }

        public void SetPath(Vector3[] points)
        {
            lineSegments.Clear();
            List<Vector3> currentSegment = new List<Vector3>();

            foreach (var point in points)
            {
                if (currentSegment.Count > 0 && ((int)currentSegment[currentSegment.Count - 1].z) != ((int)point.z))
                {
                    lineSegments.Add((int)Math.Round(currentSegment[0].z), currentSegment.ToArray());
                    currentSegment.Clear();
                }

                currentSegment.Add(point);
            }
            lineSegments.Add((int)Math.Round(currentSegment[0].z), currentSegment.ToArray());
        }
    }
}
