using System.Collections.Generic;
using TirUtilities.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace TirUtilities.UI.Layout
{
    //[System.Flags]
    public enum FitType
    {
        Uniform,
        Width,
        Height,
        FixedRows,
        FixedColumns,

        //DistributesEvenly       = Width | Height | Uniform,
        //DistributesColumnwise   = Height | FixedRows,
        //DistributesRowise       = Width | FixedColumns,
        //FixedRowsOrColumns      = FixedColumns | FixedRows
    }

    public static class FitTypeExtensions
    {
        public static bool DistributesEvenly(this FitType fitType) =>
            fitType == FitType.Width || fitType == FitType.Height || fitType == FitType.Uniform;

        public static bool DistributesColumnwise(this FitType fitType) =>
            fitType == FitType.Height || fitType == FitType.FixedRows;

        public static bool DistributesRowise(this FitType fitType) =>
            fitType == FitType.Width || fitType == FitType.FixedColumns;
    }

    public class FlexibleGridLayoutGroup : LayoutGroup
    {
        #region Inspector Fields

        [Header("Layout Settings")]
        [Tooltip("How the child elements are distributed.\n" +
                 "Uniform:  The number of columns and rows will be the same.\n" +
                 "Width:  Prioritizes columns.\n" +
                 "Height:  Prioritizes rows.\n" +
                 "Fixed:  Either rows or columns will remain a fixed number.")]
        [SerializeField] private FitType _fitType;
        [Space]

        [Tooltip("The dimensions of each grid cell.")]
        [SerializeField, Min(0)] private Vector2 _cellSize;

        [Min(1)]
        [Tooltip("The number of rows that children are divided into.")]
        [SerializeField] private int _rows;
        
        [Tooltip("The number of columns that children are divided into.")]
        [Min(1)]
        [SerializeField] private int _columns;
        [Space]

        [Min(0)]
        [SerializeField] private Vector2 _spaceAround;
        [Space]
        [SerializeField] private bool _fitX;
        [SerializeField] private bool _fitY;

        [Header("Debug")]
        [SerializeField, DisplayOnly] private Vector2 _gridArea = new Vector2();

        #endregion

        #region Layout Overrides
        
        public override void CalculateLayoutInputHorizontal()
        {
            base.CalculateLayoutInputHorizontal();

            ClampColumnsAndRows();
            if (_fitType.DistributesEvenly())
                DistributeCellsEvenly();

            if (_fitType.DistributesColumnwise())
                DestributeColumns();

            CalculateCellWidth();
        }


        public override void CalculateLayoutInputVertical()
        {
            if (_fitType.DistributesRowise())
                DestributeRows();

            CalculateCellHeight();
        }


        public override void SetLayoutHorizontal() => SetChildrenAlongAxis(0);

        public override void SetLayoutVertical() => SetChildrenAlongAxis(1);

        #endregion

        #region Private Methods

        private void ClampColumnsAndRows()
        {
            _columns = _columns > transform.childCount ? transform.childCount : _columns;
            _rows = _rows > transform.childCount ? transform.childCount : _rows;
        }

        private void DestributeColumns() => _columns = Mathf.CeilToInt(transform.childCount / (float)_rows);

        private void DestributeRows() => _rows = Mathf.CeilToInt(transform.childCount / (float)_columns);

        private void DistributeCellsEvenly()
        {
            _fitX = true;
            _fitY = true;

            float sqrtChildCount = Mathf.Sqrt(transform.childCount);
            _rows = Mathf.RoundToInt(sqrtChildCount);
            _columns = Mathf.CeilToInt(sqrtChildCount);
        }

        private void CalculateCellWidth()
        {
            float parentWidth = rectTransform.rect.width;

            _gridArea.x = parentWidth + _spaceAround.x - padding.left - padding.right;

            float cellWidth = _gridArea.x / _columns - _spaceAround.x;

            _cellSize.x = _fitX ? cellWidth : _cellSize.x;
        }

        private void CalculateCellHeight()
        {
            float parentHeight = rectTransform.rect.height;

            _gridArea.y = parentHeight + _spaceAround.y - padding.top - padding.bottom;

            float cellHeight = _gridArea.y / _rows - _spaceAround.y;

            _cellSize.y = _fitY ? cellHeight : _cellSize.y;
        }

        private void SetChildrenAlongAxis(int axis)
        {
            RectTransform child;

            for (int i = 0; i < rectChildren.Count; i++)
            {
                child = rectChildren[i];

                if (axis == 0)
                {
                    int columnCount = i % _columns;

                    float xPos = _cellSize.x * columnCount 
                                 + _spaceAround.x * columnCount 
                                 + padding.left;

                    SetChildAlongAxis(child, axis, xPos, _cellSize.x);
                    continue;
                }

                if (axis == 1)
                {
                    int rowCount = i / _columns;

                    float yPos = _cellSize.y * rowCount
                                 + _spaceAround.y * rowCount
                                 + padding.top;

                    SetChildAlongAxis(child, axis, yPos, _cellSize.y);
                }
            }
        }

        #endregion
    }
}