using System.Windows.Forms;


namespace ControlAnalizing.DataEMF
{
    /// <summary>
    /// Основной класс который хранит все измерения "Сигнала" и "Шума"
    /// </summary>
    class EMField
    {



        #region
        /// <summary>
        /// Класс которые хранит все измерения (Сигналов)
        /// </summary>
        internal class UpMeasureLevel
        {
            // —————— /*Свойство - TableLayOutPanel со списком полученных измерений сигналов и управления ими*/ ——————
            private TableLayoutPanel layOutList;
            public TableLayoutPanel LayOutList { get => layOutList; }




        }
        #endregion

        public UpMeasureLevel Measure { get; } = new UpMeasureLevel();

        public EMField ()
        {
            //ActiveSelect.
            byte a = (byte)ActiveSelect.Noise;
        }
    }
}
