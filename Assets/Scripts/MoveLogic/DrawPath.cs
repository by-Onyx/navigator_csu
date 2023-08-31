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
        
        private Vector3 lastPos;

        public void Init(Vector3 pos)
        {
            CreateBrush(pos);
            //path.GetPositions();
        }

        private void CreateBrush(Vector3 pos)
        {
            path = Instantiate(line);
            path.SetPosition(0, pos);
            path.SetPosition(1, pos);
        }

        private void AddAPoint(Vector3 pointPos)
        {
            path.positionCount++;
            int positionIndex = path.positionCount - 1;
            path.SetPosition(positionIndex, pointPos);
        }

        public void PointToPos(Vector3[] position)
        {
            foreach (var point in position)
            {
                AddAPoint(point);
            }
        }
    }
}
