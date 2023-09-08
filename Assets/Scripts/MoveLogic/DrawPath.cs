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
        private List<LineRenderer> floorPaths = new List<LineRenderer>();
        public static Dictionary<int, Vector3[]> LineSegments = new Dictionary<int, Vector3[]>();

        public void Init(Vector3 pos)
        {
            CreateBrush(pos);
        }

        public void DeleteLine()
        {
            floorPaths.ForEach(x => Destroy(x));
        }

        public void NewPath()
        {
            LineSegments.Clear();
        }

        private void CreateBrush(Vector3 pos)
        {
            path = Instantiate(line);
            path.SetPosition(0, pos);
            path.SetPosition(1, pos);
            floorPaths.Add(path);
        }

        public void AddAPoint(Vector3 pointPos)
        {
            path.positionCount++;
            int positionIndex = path.positionCount - 1;
            path.SetPosition(positionIndex, pointPos);
        }

        public void SetPath(Vector3[] points)
        {
            LineSegments.Clear();
            List<Vector3> currentSegment = new List<Vector3>();

            foreach (var point in points)
            {
                if (currentSegment.Count > 0 && ((int)currentSegment[currentSegment.Count - 1].z) != ((int)point.z))
                {
                    if (LineSegments.ContainsKey((int)Math.Round(currentSegment[0].z)))
                    {
                        LineSegments.Add((int)Math.Round(currentSegment[0].z) + 1, currentSegment.ToArray());
                    }
                    else
                    {
                        LineSegments.Add((int)Math.Round(currentSegment[0].z), currentSegment.ToArray());
                    }

                    currentSegment.Clear();
                }

                currentSegment.Add(point);
            }
            if (LineSegments.ContainsKey((int)Math.Round(currentSegment[0].z)))
            {
                LineSegments.Add((int)Math.Round(currentSegment[0].z) + 1, currentSegment.ToArray());
            }
            else
            {
                LineSegments.Add((int)Math.Round(currentSegment[0].z), currentSegment.ToArray());
            }
        }
    }
}
