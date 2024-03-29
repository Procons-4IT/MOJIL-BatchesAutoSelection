namespace BatchAutoSelection
{
    using SAPbouiCOM.Framework;
    using System;

    [FormAttribute("42", "Batch Number Selection.b1f")]
    class Batch_Number_Selection : SystemFormBase
    {
        private SAPbouiCOM.Button btnAutoSelectByDate;
        private SAPbouiCOM.Button btnMainAutoSelect;

        public Batch_Number_Selection()
        {
        }

        /// <summary>
        /// Initialize components. Called by framework after form created.
        /// </summary>
        public override void OnInitializeComponent()
        {
            this.btnMainAutoSelect = ((SAPbouiCOM.Button)(this.GetItem("16").Specific));
            this.btnAutoSelectByDate = ((SAPbouiCOM.Button)(this.GetItem("btnAuto").Specific));
            this.btnAutoSelectByDate.ClickBefore += new SAPbouiCOM._IButtonEvents_ClickBeforeEventHandler(this.btnAutoSelectByDate_ClickBefore);
            this.OnCustomInitialize();

        }

        /// <summary>
        /// Initialize form event. Called by framework before form creation.
        /// </summary>
        public override void OnInitializeFormEvents()
        {
        }

        private void OnCustomInitialize()
        {

        }

        private void btnAutoSelectByDate_ClickBefore(object sboObject, SAPbouiCOM.SBOItemEventArg pVal, out bool BubbleEvent)
        {
            BubbleEvent = true;
            try
            {
                var selectedBatches = this.GetItem("3").Specific as SAPbouiCOM.Matrix;
                for (int i = 1; i <= selectedBatches.RowCount; i++)
                {
                    selectedBatches.Columns.Item("0").Cells.Item(i).Click();
                    var availableBatches = this.GetItem("4").Specific as SAPbouiCOM.Matrix;
                    availableBatches.Columns.Item("15").TitleObject.Sort(SAPbouiCOM.BoGridSortType.gst_Ascending);
                    btnMainAutoSelect.Item.Click();
                }
            }
            catch (Exception ex)
            {
                Logger.Write(ex.Message);
                Application.SBO_Application.SetStatusBarMessage(ex.Message);
            }
        }
    }
}
