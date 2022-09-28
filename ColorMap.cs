using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RIE_UI
{
    internal class ColorMap
    {
        //////////////////////////////////////////////////////////////////////////////////////////////////// Field
        ////////////////////////////////////////////////////////////////////////////////////////// Private

        #region Field

        /// <summary>
        /// 색상 카운트
        /// </summary>
        private int colorCount = 64;

        /// <summary>
        /// 불투명도
        /// </summary>
        private int alpha = 255;

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Constructor
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region 생성자 - ColorMap()

        /// <summary>
        /// 생성자
        /// </summary>
        public ColorMap()
        {
        }

        #endregion
        #region 생성자 - ColorMap(colorCount)

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="colorCount">색상 카운트</param>
        public ColorMap(int colorCount)
        {
            this.colorCount = colorCount;
        }

        #endregion
        #region 생성자 - ColorMap(colorCount, alpha)

        /// <summary>
        /// 생성자
        /// </summary>
        /// <param name="colorCount">색상 카운트</param>
        /// <param name="alpha">불투명도</param>
        public ColorMap(int colorCount, int alpha)
        {
            this.colorCount = colorCount;
            this.alpha = alpha;
        }

        #endregion

        //////////////////////////////////////////////////////////////////////////////////////////////////// Method
        ////////////////////////////////////////////////////////////////////////////////////////// Public

        #region SPRING 색상 값 배열 구하기 - GetSpringColorValueArray()

        /// <summary>
        /// SPRING 색상 값 배열 구하기
        /// </summary>
        /// <returns>SPRING 색상 값 배열</returns>
        public int[,] GetSpringColorValueArray()
        {
            int[,] colorValueArray = new int[this.colorCount, 4];
            float[] springArray = new float[this.colorCount];

            for (int i = 0; i < this.colorCount; i++)
            {
                springArray[i] = 1.0f * i / (this.colorCount - 1);

                colorValueArray[i, 0] = this.alpha;
                colorValueArray[i, 1] = 255;
                colorValueArray[i, 2] = (int)(255 * springArray[i]);
                colorValueArray[i, 3] = 255 - colorValueArray[i, 1];
            }

            return colorValueArray;
        }

        #endregion
        #region SUMMER 색상 값 배열 구하기 - GetSummerColorValueArray()

        /// <summary>
        /// SUMMER 색상 값 배열 구하기
        /// </summary>
        /// <returns>SUMMER 색상 값 배열</returns>
        public int[,] GetSummerColorValueArray()
        {
            int[,] colorValueArray = new int[this.colorCount, 4];
            float[] summerArray = new float[this.colorCount];

            for (int i = 0; i < this.colorCount; i++)
            {
                summerArray[i] = 1.0f * i / (this.colorCount - 1);

                colorValueArray[i, 0] = this.alpha;
                colorValueArray[i, 1] = (int)(255 * summerArray[i]);
                colorValueArray[i, 2] = (int)(255 * 0.5f * (1 + summerArray[i]));
                colorValueArray[i, 3] = (int)(255 * 0.4f);
            }

            return colorValueArray;
        }

        #endregion
        #region AUTUMN 색상 값 배열 구하기 - GetAutumnColorValueArray()

        /// <summary>
        /// AUTUMN 색상 값 배열 구하기
        /// </summary>
        /// <returns>AUTUMN 색상 값 배열</returns>
        public int[,] GetAutumnColorValueArray()
        {
            int[,] colorValueArray = new int[this.colorCount, 4];
            float[] autumnArray = new float[this.colorCount];

            for (int i = 0; i < this.colorCount; i++)
            {
                autumnArray[i] = 1.0f * i / (this.colorCount - 1);

                colorValueArray[i, 0] = this.alpha;
                colorValueArray[i, 1] = 255;
                colorValueArray[i, 2] = (int)(255 * autumnArray[i]);
                colorValueArray[i, 3] = 0;
            }

            return colorValueArray;
        }

        #endregion
        #region WINTER 색상 값 배열 구하기 - GetWinterColorValueArray()

        /// <summary>
        /// WINTER 색상 값 배열 구하기
        /// </summary>
        /// <returns>WINTER 색상 값 배열</returns>
        public int[,] GetWinterColorValueArray()
        {
            int[,] colorValueArray = new int[this.colorCount, 4];
            float[] winterArray = new float[this.colorCount];

            for (int i = 0; i < this.colorCount; i++)
            {
                winterArray[i] = 1.0f * i / (this.colorCount - 1);

                colorValueArray[i, 0] = this.alpha;
                colorValueArray[i, 1] = 0;
                colorValueArray[i, 2] = (int)(255 * winterArray[i]);
                colorValueArray[i, 3] = (int)(255 * (1.0f - 0.5f * winterArray[i]));
            }

            return colorValueArray;
        }

        #endregion
        #region GRAY 색상 값 배열 구하기 - GetGrayColorArray()

        /// <summary>
        /// GRAY 색상 값 배열 구하기
        /// </summary>
        /// <returns>GRAY 색상 값 배열</returns>
        public int[,] GetGrayColorArray()
        {
            int[,] colorValueArray = new int[this.colorCount, 4];
            float[] grayArray = new float[this.colorCount];

            for (int i = 0; i < this.colorCount; i++)
            {
                grayArray[i] = 1.0f * i / (this.colorCount - 1);

                colorValueArray[i, 0] = this.alpha;
                colorValueArray[i, 1] = (int)(255 * grayArray[i]);
                colorValueArray[i, 2] = (int)(255 * grayArray[i]);
                colorValueArray[i, 3] = (int)(255 * grayArray[i]);
            }

            return colorValueArray;
        }

        #endregion
        #region JET 색상 값 배열 구하기 - GetJetColorValueArray()

        /// <summary>
        /// JET 색상 값 배열 구하기
        /// </summary>
        /// <returns>JET 색상 값 배열</returns>
        public int[,] GetJetColorValueArray()
        {
            int[,] colorValueArray = new int[this.colorCount, 4];
            float[,] colorMatrix = new float[this.colorCount, 3];
            int partCount = (int)Math.Ceiling(this.colorCount / 4.0f);
            int partCountModular = 0;
            float[] jetArray = new float[3 * partCount - 1];
            int[] redArray = new int[jetArray.Length];
            int[] greenArray = new int[jetArray.Length];
            int[] blueArray = new int[jetArray.Length];

            if (this.colorCount % 4 == 1)
            {
                partCountModular = 1;
            }

            for (int i = 0; i < jetArray.Length; i++)
            {
                if (i < partCount)
                {
                    jetArray[i] = (float)(i + 1) / partCount;
                }
                else if (i >= partCount && i < 2 * partCount - 1)
                {
                    jetArray[i] = 1.0f;
                }
                else if (i >= 2 * partCount - 1)
                {
                    jetArray[i] = (float)(3 * partCount - 1 - i) / partCount;
                }

                greenArray[i] = (int)Math.Ceiling(partCount / 2.0f) - partCountModular + i;
                redArray[i] = greenArray[i] + partCount;
                blueArray[i] = greenArray[i] - partCount;
            }

            int blueCount = 0;

            for (int i = 0; i < blueArray.Length; i++)
            {
                if (blueArray[i] > 0)
                {
                    blueCount++;
                }
            }

            for (int i = 0; i < this.colorCount; i++)
            {
                for (int j = 0; j < redArray.Length; j++)
                {
                    if (i == redArray[j] && redArray[j] < this.colorCount)
                    {
                        colorMatrix[i, 0] = jetArray[i - redArray[0]];
                    }
                }

                for (int j = 0; j < greenArray.Length; j++)
                {
                    if (i == greenArray[j] && greenArray[j] < this.colorCount)
                    {
                        colorMatrix[i, 1] = jetArray[i - (int)greenArray[0]];
                    }
                }

                for (int j = 0; j < blueArray.Length; j++)
                {
                    if (i == blueArray[j] && blueArray[j] >= 0)
                    {
                        colorMatrix[i, 2] = jetArray[jetArray.Length - 1 - blueCount + i];
                    }
                }
            }

            for (int i = 0; i < this.colorCount; i++)
            {
                colorValueArray[i, 0] = this.alpha;

                for (int j = 0; j < 3; j++)
                {
                    colorValueArray[i, j + 1] = (int)(colorMatrix[i, j] * 255);
                }
            }

            return colorValueArray;
        }

        #endregion
        #region HOT 색상 값 배열 구하기 - GetHotColorValueArray()

        /// <summary>
        /// HOT 색상 값 배열 구하기
        /// </summary>
        /// <returns>HOT 색상 값 배열</returns>
        public int[,] GetHotColorValueArray()
        {
            int[,] colorValueArray = new int[this.colorCount, 4];
            int partCount = 3 * this.colorCount / 8;
            float[] redArray = new float[this.colorCount];
            float[] greenArray = new float[this.colorCount];
            float[] blueArray = new float[this.colorCount];

            for (int i = 0; i < this.colorCount; i++)
            {
                if (i < partCount)
                {
                    redArray[i] = 1.0f * (i + 1) / partCount;
                }
                else
                {
                    redArray[i] = 1.0f;
                }

                if (i < partCount)
                {
                    greenArray[i] = 0f;
                }
                else if (i >= partCount && i < 2 * partCount)
                {
                    greenArray[i] = 1.0f * (i + 1 - partCount) / partCount;
                }
                else
                {
                    greenArray[i] = 1f;
                }

                if (i < 2 * partCount)
                {
                    blueArray[i] = 0f;
                }
                else
                {
                    blueArray[i] = 1.0f * (i + 1 - 2 * partCount) / (this.colorCount - 2 * partCount);
                }

                colorValueArray[i, 0] = this.alpha;
                colorValueArray[i, 1] = (int)(255 * redArray[i]);
                colorValueArray[i, 2] = (int)(255 * greenArray[i]);
                colorValueArray[i, 3] = (int)(255 * blueArray[i]);
            }

            return colorValueArray;
        }

        #endregion
        #region COOL 색상 값 배열 구하기 - GetCoolColorValueArray()

        /// <summary>
        /// COOL 색상 값 배열 구하기
        /// </summary>
        /// <returns>COOL 색상 값 배열</returns>
        public int[,] GetCoolColorValueArray()
        {
            int[,] colorValueArray = new int[this.colorCount, 4];
            float[] coolArray = new float[this.colorCount];

            for (int i = 0; i < this.colorCount; i++)
            {
                coolArray[i] = 1.0f * i / (this.colorCount - 1);

                colorValueArray[i, 0] = this.alpha;
                colorValueArray[i, 1] = (int)(255 * coolArray[i]);
                colorValueArray[i, 2] = (int)(255 * (1 - coolArray[i]));
                colorValueArray[i, 3] = 255;
            }

            return colorValueArray;
        }

        #endregion
    }
}

