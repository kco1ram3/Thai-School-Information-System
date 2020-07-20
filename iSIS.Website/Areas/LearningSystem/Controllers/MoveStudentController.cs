using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace iSIS.Website.Areas.LearningSystem.Controllers
{
    public class MoveStudentController : Controller
    {
        // GET: LearningSystem/MoveStudent
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AdvancedCustomBinding()
        {
            return View("AdvancedCustomBinding");
        }

        public ActionResult AdvancedCustomBindingPartial()
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            if (viewModel == null)
                viewModel = CreateGridViewModelWithSummary();
            return AdvancedCustomBindingCore(viewModel);
        }
        // Paging
        public ActionResult AdvancedCustomBindingPagingAction(GridViewPagerState pager)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplyPagingState(pager);
            return AdvancedCustomBindingCore(viewModel);
        }
        // Filtering
        public ActionResult AdvancedCustomBindingFilteringAction(GridViewFilteringState filteringState)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplyFilteringState(filteringState);
            return AdvancedCustomBindingCore(viewModel);
        }
        // Sorting
        public ActionResult AdvancedCustomBindingSortingAction(GridViewColumnState column, bool reset)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplySortingState(column, reset);
            return AdvancedCustomBindingCore(viewModel);
        }
        // Grouping
        public ActionResult AdvancedCustomBindingGroupingAction(GridViewColumnState column)
        {
            var viewModel = GridViewExtension.GetViewModel("gridView");
            viewModel.ApplyGroupingState(column);
            return AdvancedCustomBindingCore(viewModel);
        }

        PartialViewResult AdvancedCustomBindingCore(GridViewModel viewModel)
        {
            /*viewModel.ProcessCustomBinding(
                GridViewCustomBindingHandlers.GetDataRowCountAdvanced,
                GridViewCustomBindingHandlers.GetDataAdvanced,
                GridViewCustomBindingHandlers.GetSummaryValuesAdvanced,
                GridViewCustomBindingHandlers.GetGroupingInfoAdvanced,
                GridViewCustomBindingHandlers.GetUniqueHeaderFilterValuesAdvanced
            );*/
            return PartialView("AdvancedCustomBindingPartial", viewModel);
        }

        static GridViewModel CreateGridViewModelWithSummary()
        {
            var viewModel = new GridViewModel();
            viewModel.KeyFieldName = "ID";
            viewModel.Columns.Add("ห้อง");
            viewModel.Columns.Add("เลขที่บัตร");
            viewModel.Columns.Add("ชื่อ - นามสกุล");
            viewModel.Columns.Add("ระดับการศึกษาใหม่");
            viewModel.Columns.Add("ห้องใหม่");

            /*viewModel.TotalSummary.Add(new GridViewSummaryItemState() { FieldName = "Size", SummaryType = SummaryItemType.Sum });
            viewModel.TotalSummary.Add(new GridViewSummaryItemState() { FieldName = "Subject", SummaryType = SummaryItemType.Count });
            viewModel.GroupSummary.Add(new GridViewSummaryItemState() { FieldName = string.Empty, SummaryType = SummaryItemType.Count });*/
            return viewModel;
        }
    }
}