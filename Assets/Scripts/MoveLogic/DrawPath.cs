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
        [SerializeField] private LineRenderer path;
        
        private Vector3 lastPos;

        public void Init(Vector3 pos)
        {
            CreateBrush(pos);
        }

        private void CreateBrush(Vector3 pos)
        {
            path.SetPosition(0, pos);
            path.SetPosition(1, pos);
        }

        private void AddAPoint(Vector3 pointPos)
        {
            path.positionCount++;
            int positionIndex = path.positionCount - 1;
            path.SetPosition(positionIndex, pointPos);
        }

        public void PointToMousePos(Vector3[] position)
        {
            /*if (lastPos != position)
            {
                AddAPoint(position);
                lastPos = position;
            }*/
            foreach (var point in position)
            {
                AddAPoint(point);
            }
            
        }
    }
}
