namespace Dragonfly
{
    using System.Linq;
    using Skybrud.Umbraco.GridData;

    class GridHelper
    {
        public static bool GridHasContent(GridDataModel GridControlData)
        {
            var hasContent = false;
            var keepLooking = true;

            while (keepLooking)
            {
                if (GridControlData.Sections.Any())
                {
                    foreach (var section in GridControlData.Sections)
                    {
                        if (section.Rows.Any())
                        {
                            foreach (var row in section.Rows)
                            {
                                if (row.Areas.Any())
                                {
                                    foreach (var col in row.Areas)
                                    {
                                        if (col.Controls.Any())
                                        {
                                            hasContent = true;
                                            keepLooking = false;
                                            break;
                                        }
                                    }
                                }
                                else
                                { keepLooking = false; }
                            }
                        }
                        else
                        { keepLooking = false; }
                    }
                }
                else
                { keepLooking = false; }
            }


            //var allControls = new List<GridControl>();
            //foreach (var section in GridControlData.Sections)
            //{
            //    foreach (var row in section.Rows)
            //    {
            //        foreach (var col in row.Areas)
            //        {
            //            foreach (var control in col.Controls)
            //            {
            //                allControls.Add(control);
            //            }
            //        }
            //    }
            //}

            //if (allControls.Any())
            //{ hasContent = true; }

            return hasContent;
        }
    }
}
